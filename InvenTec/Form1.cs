using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace InvenTec
{
    public partial class Form1 : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private ZebraLabelPrinter labelPrinter;
        public Form1()
        {

            InitializeComponent();
            llenaCmbDeptos();
            LlenarComboImpresoras();
        }

        private void LlenarComboImpresoras()
        {
            // Obtiene una colección de todas las impresoras instaladas en el sistema
            PrinterSettings.StringCollection impresoras = PrinterSettings.InstalledPrinters;

            cmbImpresoraZebra.Items.Clear();

            foreach (string impresora in impresoras)
            {
                cmbImpresoraZebra.Items.Add(impresora);
            }

            // Selecciona la primera impresora por defecto si hay impresoras disponibles
            /*if (cmbImpresoraZebra.Items.Count > 0)
            {
                cmbImpresoraZebra.SelectedIndex = 0;
            }*/
        }

        private void llenaCmbDeptos()
        {
            // Define your SQL connection string
            string connectionString = "Server=DAVID-D14\\SQLEXPRESS;Database=inventec;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Create a SQL query to retrieve department data from your database
                    string query = "SELECT alias FROM departamentos";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataReader reader = cmd.ExecuteReader();

                    // Clear any existing items in the ComboBox
                    cmbDeptos.Items.Clear();

                    while (reader.Read())
                    {
                        // Add each department name to the ComboBox
                        cmbDeptos.Items.Add(reader["alias"].ToString());
                    }

                    // Close the data reader and connection
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions here, e.g., display an error message
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void vistaPreviaEtiqueta(string prog, string depto, string encargado, string nombre, string descripcion)
        {
            string zplData = "^XA" +
                "~TA000" +
                "~JSN" +
                "^LT0" +
                "^MNW" +
                "^MTT" +
                "^PON" +
                "^PMN" +
                "^LH0,0" +
                "^JMA" +
                "^PR8,8" +
                "~SD15" +
                "^JUS" +
                "^LRN" +
                "^CI27" +
                "^PA0,1,1,0" +
                "^MMT" +
                "^LS0" +
                "^BY4,3,65^FT145,256^BCN,,Y,N" +
                "^FH\\^FD>:" + prog + "^FS" +
                "^FT16,41^A0N,28,28^FH\\^CI28^FDT.N.M./ INSTITUTO TECNOLOGICO DE CULIACAN^FS^CI27" +
                "^FT16,76^A0N,28,28^FH\\^CI28^FDDEPTO: " + depto + "^FS^CI27" +
                "^FT16,111^A0N,28,28^FH\\^CI28^FDENCARGADO: " + encargado + "^FS^CI27" +
                "^FT16,146^A0N,28,28^FH\\^CI28^FD" + nombre + "^FS^CI27" +
                "^FT16,181^A0N,28,28^FH\\^CI28^FD" + descripcion + "^FS^CI27" +
                "^FT513,308^A0N,28,28^FH\\^CI28^FD25/10/2023^FS^CI27" +
                "^XZ";

            // URL que contiene el código ZPL (asegúrate de que sea una URL válida)
            string zplUrl = "http://api.labelary.com/v1/printers/8dpmm/labels/4x6/0/";
            byte[] zpl = Encoding.UTF8.GetBytes(zplData);

            // Configura la solicitud HTTP
            var request = (HttpWebRequest)WebRequest.Create(zplUrl);
            request.Method = "POST";
            request.Accept = "image/png"; // Solicita una imagen PNG
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = zpl.Length;

            var requestStream = request.GetRequestStream();
            requestStream.Write(zpl, 0, zpl.Length);
            requestStream.Close();

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseStream = response.GetResponseStream();

                // Redimensiona la imagen a 80 mm x 40 mm antes de cargarla en el PictureBox
                int nuevoAncho = 330;  // 80 mm a 203 dpi
                int nuevoAlto = 500;   // 40 mm a 203 dpi
                pictureBoxEtiqueta.Image = RedimensionarImagen(Image.FromStream(responseStream), nuevoAncho, nuevoAlto);

                responseStream.Close();
            }
            catch (WebException ex)
            {
                Console.WriteLine("Error: {0}", ex.Status);
            }
        }

        // Función para redimensionar una imagen
        private Image RedimensionarImagen(Image imagen, int nuevoAncho, int nuevoAlto)
        {
            Bitmap nuevaImagen = new Bitmap(nuevoAncho, nuevoAlto);
            using (Graphics g = Graphics.FromImage(nuevaImagen))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imagen, 0, 0, nuevoAncho, nuevoAlto);
            }
            return nuevaImagen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbArea.SelectedItem != null)
            {
                // Obtén el nombre del área seleccionada en cmbArea
                string areaSeleccionada = cmbArea.SelectedItem.ToString();

                // Define tu conexión a la base de datos
                string connectionString = "Server=DAVID-D14\\SQLEXPRESS;Database=inventec;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Crea una consulta SQL para obtener los datos de los activos en el área seleccionada
                        string query = @"SELECT A.PROG, A.NOMBRE, A.CARACTERISTICA_DEL_BIEN as CARACTERISTICAS, D.DEPARTAMENTO AS DEPARTAMENTO, A.JEFE_DE_DEPARTAMENTO
                        FROM Activos A
                        JOIN Departamentos D ON A.CLAVE_DEPTO = D.CLAVE
                        WHERE A.CLAVE_DEPTO = (SELECT clave FROM areas WHERE nombre = @AreaNombre)";

                        // Crea un comando SQL con parámetros
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@AreaNombre", areaSeleccionada);

                        // Crea un adaptador de datos y un conjunto de datos para llenar el DataGridView
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna el conjunto de datos al DataGridView
                        dataGridActivos.DataSource = dataTable;

                        if (dataTable.Rows.Count > 0)
                        {
                            string prog = dataTable.Rows[0]["PROG"].ToString().ToUpper();
                            string depto = dataTable.Rows[0]["DEPARTAMENTO"].ToString().ToUpper();
                            string encargado = dataTable.Rows[0]["JEFE_DE_DEPARTAMENTO"].ToString().ToUpper();
                            string nombre = dataTable.Rows[0]["NOMBRE"].ToString().ToUpper();
                            string descripcion = dataTable.Rows[0]["CARACTERISTICAS"].ToString().ToUpper();

                            // Llamar al método vistaPreviaEtiqueta con los valores de la base de datos
                            vistaPreviaEtiqueta(prog, depto, encargado, nombre, descripcion);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Maneja cualquier excepción que ocurra, por ejemplo, muestra un mensaje de error
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            } else {
                MessageBox.Show("Por favor, selecciona un área antes de continuar.", "Advertencia");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbDeptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbArea.SelectedIndex = -1;
            string departamentoSeleccionado = cmbDeptos.SelectedItem.ToString();
            string connectionString = "Server=DAVID-D14\\SQLEXPRESS;Database=inventec;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT nombre " +
                    "FROM areas " +
                    "WHERE clave = (SELECT clave " +
                    "FROM departamentos " +
                    "WHERE alias = @DepartamentoAlias)";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@DepartamentoAlias", departamentoSeleccionado);

                    SqlDataReader reader = cmd.ExecuteReader();

                    cmbArea.Items.Clear();

                    while (reader.Read())
                    {
                        // Agrega cada área al ComboBox cmbAreas
                        cmbArea.Items.Add(reader["nombre"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cmbImpresoraZebra.SelectedItem != null)
            {
                try
                {
                    string impresoraSeleccionada = cmbImpresoraZebra.SelectedItem.ToString();
                    labelPrinter = new ZebraLabelPrinter(impresoraSeleccionada);
                    // Se abre y cierra la conexión para testear que funcione.
                    labelPrinter.Open();
                    labelPrinter.Close();
                    lblConectividad.Text = "Conectado";
                    lblConectividad.ForeColor = Color.DarkGreen;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir la conexión con la impresora: " + ex.Message, "Error");
                }
            } else {
                MessageBox.Show("Por favor, selecciona una impresora antes de continuar.", "Advertencia");
            }
        }

        private void btnConsultarIndividual_Click(object sender, EventArgs e)
        {
            string activo = txtActivo.Text;

            // Verifica si el campo de texto no está vacío
            if (!string.IsNullOrWhiteSpace(activo))
            {
                string connectionString = "Server=DAVID-D14\\SQLEXPRESS;Database=inventec;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = @"SELECT A.PROG, 
                        A.NOMBRE, 
                        A.CARACTERISTICA_DEL_BIEN as CARACTERISTICAS, 
                        D.DEPARTAMENTO AS DEPARTAMENTO, 
                        A.JEFE_DE_DEPARTAMENTO
                        FROM Activos A
                        JOIN Departamentos D ON A.CLAVE_DEPTO = D.CLAVE
                        WHERE A.PROG = @Activo";

                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Activo", activo);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridActivos.DataSource = dataTable;

                        if (dataTable.Rows.Count > 0)
                        {
                            string prog = dataTable.Rows[0]["PROG"].ToString().ToUpper();
                            string depto = dataTable.Rows[0]["DEPARTAMENTO"].ToString().ToUpper();
                            string encargado = dataTable.Rows[0]["JEFE_DE_DEPARTAMENTO"].ToString().ToUpper();
                            string nombre = dataTable.Rows[0]["NOMBRE"].ToString().ToUpper();
                            string descripcion = dataTable.Rows[0]["CARACTERISTICAS"].ToString().ToUpper();

                            // Llamar al método vistaPreviaEtiqueta con los valores de la base de datos
                            vistaPreviaEtiqueta(prog, depto, encargado, nombre, descripcion);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                // Muestra un mensaje de error o realiza alguna acción apropiada si el campo de texto está vacío
                MessageBox.Show("Por favor, ingresa un valor en el campo de activo antes de continuar.","Advertencia");
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtActivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (cmbImpresoraZebra.SelectedItem != null)
            {
                // Los datos ZPL que deseas imprimir
                string zplData = "^XA^FO100,100^AD^FDOLA K ASE^FS^XZ";

                // Nombre de la impresora Zebra
                string printerName = "NombreDeTuImpresora"; // Reemplaza con el nombre de tu impresora

                // Crea una instancia de ZebraLabelPrinter
                ZebraLabelPrinter labelPrinter = new ZebraLabelPrinter(printerName);

                try
                {
                    // Abre la conexión con la impresora
                    labelPrinter.Open();

                    // Imprime la etiqueta
                    labelPrinter.PrintLabel(zplData);

                    // Cierra la conexión con la impresora
                    labelPrinter.Close();
                }
                catch (Exception ex)
                {
                    // Maneja cualquier excepción que pueda ocurrir durante la impresión
                    MessageBox.Show("Error al imprimir: " + ex.Message);
                }
            } else {
                MessageBox.Show("Por favor, selecciona una impresora antes de continuar.", "Advertencia");
            }
        }
    }
}




