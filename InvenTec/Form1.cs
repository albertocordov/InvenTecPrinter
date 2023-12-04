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
using System.Reflection;
using Zebra.Sdk.Comm;

namespace InvenTec
{
    public partial class Form1 : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private DriverPrinterConnection labelPrinter;
        string zplData;
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
            string connectionString = "Server=inventec.database.windows.net;Database=inventec;User=adminsql;Password=Inventec2023;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Create a SQL query to retrieve department data from your database
                    string query = "SELECT Depalias FROM departamentos";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataReader reader = cmd.ExecuteReader();

                    // Clear any existing items in the ComboBox
                    cmbDeptos.Items.Clear();

                    while (reader.Read())
                    {
                        // Add each department name to the ComboBox
                        cmbDeptos.Items.Add(reader["depalias"].ToString());
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

        private void vistaPreviaEtiqueta(string prog, string depto, string nombre, string descripcion)
        {
            DateTime fechaActual = DateTime.Now;
            string fechaFormateada = fechaActual.ToString("dd/MM/yyyy");

            var zplData = "^XA" +
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
             "^BY4,3,80^FT141,242^BCN,,Y,N" +
             "^FH\\^FD>:" + prog + "^FS" +
             "^FT16,41^A0N,28,28^FH\\^CI28^FDT.N.M./ INSTITUTO TECNOLOGICO DE CULIACAN^FS^CI27" +
             "^FT16,76^A0N,28,28^FH\\^CI28^FDDEPTO: " + depto + "^FS^CI27" +
             "^FT16,111^A0N,28,28^FH\\^CI28^FD" + nombre + "^FS^CI27" +
             "^FT16,146^A0N,28,28^FH\\^CI28^FD" + descripcion + "^FS^CI27" +
             "^FT513,308^A0N,28,28^FH\\^CI28^FD" + fechaFormateada + "^FS^CI27" +
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
                string connectionString = "Server=inventec.database.windows.net;Database=inventec;User=adminsql;Password=Inventec2023;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Crea una consulta SQL para obtener los datos de los activos en el área seleccionada
                        string query = @"SELECT 
                        A.ActId as ID,
                        A.ActNombre as NOMBRE,
                        A.ActCaracteristicas as CARACTERISTICAS,
                        J.JefeNombre as ENCARGADO,
                        D.depalias AS DEPARTAMENTO
                        FROM Activos AS A
                        INNER JOIN Areas AS AR ON A.AreaId = AR.AreaId
                        INNER JOIN Departamentos AS D ON AR.Depclave = D.Depclave
                        LEFT JOIN Jefes AS J ON D.JefeId = J.JefeId
                        WHERE A.AreaId = (SELECT AreaId FROM areas WHERE AreaNombre = @AreaNombre)
                        ";

                        // Crea un comando SQL con parámetros
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@AreaNombre", areaSeleccionada);

                        // Crea un adaptador de datos y un conjunto de datos para llenar el DataGridView
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna el conjunto de datos al DataGridView
                        dataGridActivos.DataSource = dataTable;

                        // Configura la propiedad AutoSizeColumnsMode a Fill
                        dataGridActivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Configura la propiedad AutoSizeRowsMode a AllCells
                        dataGridActivos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


                        if (dataTable.Rows.Count > 0)
                        {
                            string prog = dataTable.Rows[0]["ID"].ToString().ToUpper();
                            string depto = dataTable.Rows[0]["DEPARTAMENTO"].ToString().ToUpper();
                            string encargado = dataTable.Rows[0]["ENCARGADO"].ToString().ToUpper();
                            string nombre = dataTable.Rows[0]["NOMBRE"].ToString().ToUpper();
                            string descripcion = dataTable.Rows[0]["CARACTERISTICAS"].ToString().ToUpper();

                            // Llamar al método vistaPreviaEtiqueta con los valores de la base de datos
                            vistaPreviaEtiqueta(prog, depto, nombre, descripcion);
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
            string connectionString = "Server=inventec.database.windows.net;Database=inventec;User=adminsql;Password=Inventec2023;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT AreaNombre " +
                    "FROM areas " +
                    "WHERE depclave = (SELECT depclave " +
                    "FROM departamentos " +
                    "WHERE depalias = @DepartamentoAlias)";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@DepartamentoAlias", departamentoSeleccionado);

                    SqlDataReader reader = cmd.ExecuteReader();

                    cmbArea.Items.Clear();

                    while (reader.Read())
                    {
                        // Agrega cada área al ComboBox cmbAreas
                        cmbArea.Items.Add(reader["areanombre"].ToString());
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
                    lblConectividad.Text = "Conectando...";
                    lblConectividad.ForeColor = Color.DarkOrange;
                    // Impresora seleccionada.
                    string impresoraSeleccionada = cmbImpresoraZebra.SelectedItem.ToString();
                    
                    // Instantiate connection for ZPL USB port for given printer name.
                    Connection thePrinterConn = new DriverPrinterConnection(impresoraSeleccionada);
                    thePrinterConn.Open();
                    thePrinterConn.Close();

                    // Si se conecta, se pone en verde el label de conectividad.
                    lblConectividad.Text = "Conectado";
                    lblConectividad.ForeColor = Color.DarkGreen;
                }
                catch (Exception ex)
                {
                    lblConectividad.Text = "No conectado";
                    lblConectividad.ForeColor = Color.DarkRed;
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
                string connectionString = "Server=inventec.database.windows.net;Database=inventec;User=adminsql;Password=Inventec2023;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = @"SELECT A.ActId as ID, 
                        A.ActNombre as NOMBRE,    
                        A.ActCaracteristicas as CARACTERISTICAS, 
                        D.depalias AS DEPARTAMENTO, 
                        J.JefeNombre as ENCARGADO
                        FROM Activos A
                        JOIN Departamentos D ON A.depclave = D.depclave
                        JOIN Jefes J ON J.JefeId = D.JefeId
                        WHERE A.ActId = @Activo";

                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Activo", activo);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridActivos.DataSource = dataTable;

                        // Configura la propiedad AutoSizeColumnsMode a Fill
                        dataGridActivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Configura la propiedad AutoSizeRowsMode a AllCells
                        dataGridActivos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


                        if (dataTable.Rows.Count > 0)
                        {
                            string prog = dataTable.Rows[0]["ID"].ToString().ToUpper();
                            string depto = dataTable.Rows[0]["DEPARTAMENTO"].ToString().ToUpper();
                            string encargado = dataTable.Rows[0]["ENCARGADO"].ToString().ToUpper();
                            string nombre = dataTable.Rows[0]["NOMBRE"].ToString().ToUpper();
                            string descripcion = dataTable.Rows[0]["CARACTERISTICAS"].ToString().ToUpper();

                            // Llamar al método vistaPreviaEtiqueta con los valores de la base de datos
                            vistaPreviaEtiqueta(prog, depto, nombre, descripcion);
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
            if (cmbImpresoraZebra.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una impresora antes de continuar.", "Advertencia");
                return;
            }

            if (dataGridActivos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir.", "Advertencia");
                return;
            }

            var result = MessageBox.Show($"¿Está seguro de imprimir {(dataGridActivos.Rows.Count)-1} etiquetas?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                DateTime fechaActual = DateTime.Now;
                string fechaFormateada = fechaActual.ToString("dd/MM/yyyy");

                string impresoraSeleccionada = cmbImpresoraZebra.SelectedItem.ToString();

                Connection thePrinterConn = new DriverPrinterConnection(impresoraSeleccionada);
                thePrinterConn.Open();

                lblConectividad.Text = "Conectado";
                lblConectividad.ForeColor = Color.DarkGreen;

                try
                {
                    foreach (DataGridViewRow row in dataGridActivos.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string id = row.Cells["ID"].Value.ToString();
                        string nombre = row.Cells["NOMBRE"].Value.ToString();
                        string caracteristicas = row.Cells["CARACTERISTICAS"].Value.ToString();
                        string departamento = row.Cells["DEPARTAMENTO"].Value.ToString();

                        int idFormat;
                        if (!int.TryParse(id, out idFormat)) continue;


                        var zplData = $"^XA" +
                                $"~TA000" +
                                $"~JSN" +
                                $"^LT0" +
                                $"^MNW" +
                                $"^MTT" +
                                $"^PON" +
                                $"^PMN" +
                                $"^LH0,0" +
                                $"^JMA" +
                                $"^PR8,8" +
                                $"~SD15" +
                                $"^JUS" +
                                $"^LRN" +
                                $"^CI27" +
                                $"^PA0,1,1,0" +
                                $"^MMT" +
                                $"^PW559" +
                                $"^LL400" +
                                $"^LS0" +
                                $"^FT11,41^A0N,25,25^FH\\^CI28^FDT.N.M./ INSTITUTO TECNOLOGICO DE CULIACAN^FS^CI27" +
                                $"^FT16,73^A0N,25,25^FH\\^CI28^FDDEPTO:{departamento}^FS^CI27" +
                                $"^FT16,108^A0N,25,25^FH\\^CI28^FD{nombre}^FS^CI27" +
                                $"^FT16,143^A0N,25,25^FH\\^CI28^FD{caracteristicas}^FS^CI27" +
                                $"^BY4,3,104^FT101,275^BCN,,Y,N" +
                                $"^FH\\^FD>:{idFormat}^FS" +
                                $"^FT417,357^A0N,25,25^FH\\^CI28^FD{fechaFormateada}^FS^CI27" +
                                $"^XZ";



                        thePrinterConn.Write(Encoding.UTF8.GetBytes(zplData));
                        insertaDatosImpresion(idFormat);
                    }
                }
                finally
                {
                    thePrinterConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la conexión con la impresora: " + ex.Message, "Error");
            }
        }

        public void insertaDatosImpresion(int id)
        {
            string connectionString = "Server=inventec.database.windows.net;Database=inventec;User=adminsql;Password=Inventec2023;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Utiliza un comando parametrizado para evitar la inyección de SQL
                    string query = "INSERT INTO impresiones (ActId) VALUES (@id)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    // Ejecuta la consulta sin necesidad de un DataReader
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Maneja cualquier excepción aquí, por ejemplo, muestra un mensaje de error
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void txtActivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Ejecuta el evento del botón
                btnConsultarIndividual.PerformClick();

                // Suprime el carácter de retorno de carro para evitar que se muestre en el TextBox
                e.Handled = true;
            }
        }
    }
}




