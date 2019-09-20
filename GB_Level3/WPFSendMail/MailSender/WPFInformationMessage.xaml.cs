using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for InformationMessage.xaml
    /// </summary>
    public partial class WPFInformationMessage : Window
    {
        public WPFInformationMessage(string title, string message)
        {
            InitializeComponent();
            this.Title = title;
            this.InfoMessageBox.Text = message;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
