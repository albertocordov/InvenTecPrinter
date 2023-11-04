using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;

namespace InvenTec
{
    internal class ZebraLabelPrinter
    {
        private Connection printerConnection;

        public ZebraLabelPrinter(string printerName)
        {
            printerConnection = new UsbConnection(printerName);
        }

        public void Open()
        {
            printerConnection.Open();
        }

        public void Close()
        {
            printerConnection.Close();
        }

        public void PrintLabel(string zplData)
        {
            byte[] zplBytes = System.Text.Encoding.Default.GetBytes(zplData);
            printerConnection.Write(zplBytes, 0, zplBytes.Length);
        }
    }
}
