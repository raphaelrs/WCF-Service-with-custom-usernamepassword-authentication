using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Desktop.ServiceReference1;
using System.ServiceModel;
using System.ServiceModel.Security;

namespace Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string time = String.Empty;

            //metodo1 criando o cliente pelo arquivo de configuracao
            //Service1Client c = new Service1Client();
            //c.ClientCredentials.UserName.UserName = "oi";
            //c.ClientCredentials.UserName.Password = "oi";
            //c.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;

            //time = c.GetServerTime();
            //MessageBox.Show(time);

            // Method 2: Creating the client by creating endpoint and binding through coding
            var ServiceendPoint = new EndpointAddress(new Uri(textBox1.Text),
                                  EndpointIdentity.CreateDnsIdentity("MyWebSite"));
            var binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

            var result = new Service1Client(binding, ServiceendPoint);
            result.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                     X509CertificateValidationMode.None;
            result.ClientCredentials.UserName.UserName = "oi";
            result.ClientCredentials.UserName.Password = "oo";
            time = result.GetServerTime();
            MessageBox.Show(time);

        }
    }
}
