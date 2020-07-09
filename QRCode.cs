using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRCode
{
    public partial class QRCode : Form
    {
        public QRCode()
        {
            InitializeComponent();
        }

        public string Nome { get; set; }
        public string Setor { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string ID_Func { get; set; }

        private void QRCode_Load(object sender, EventArgs e)
        {
            string unicodeString = Setor;

            // You can convert a string into a byte array
            byte[] asciiBytes = Encoding.UTF8.GetBytes(unicodeString);

            // You can convert a byte array into a char array
            char[] asciiChars = Encoding.UTF8.GetChars(asciiBytes);
            string asciiString = new string(asciiChars);

            var qrcode =  Nome + ';' +  asciiString + ';' + Email + ';' + Telefone + ';' + ID_Func + ';';

            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();

            var MyData = QG.CreateQrCode(qrcode, QRCoder.QRCodeGenerator.ECCLevel.H);

            var code = new QRCoder.QRCode(MyData);

            pb_qrcode.Image = code.GetGraphic(300);
        }
    }
}
