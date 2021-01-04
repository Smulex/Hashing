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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hashing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConversionHandler myConverter = new ConversionHandler();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComputeMACBTN_Click(object sender, RoutedEventArgs e)
        {
            MACHandler mh = new MACHandler(selectionBox.Text);
            byte[] mac = mh.ComputeMAC(myConverter.StringToByteArray(plainTextTXT.Text), myConverter.StringToByteArray(keyTXT.Text));

            macASCIITXT.Text = myConverter.ByteArrayToString(mac);
            macHEXTXT.Text = myConverter.ByteArrayToHexString(mac);
        }

        private void VerifyMACBTN_Click(object sender, RoutedEventArgs e)
        {
            MACHandler mh = new MACHandler(selectionBox.Text);
            if (mh.CheckAuthenticity(myConverter.StringToByteArray(plainTextTXT.Text), myConverter.HexStringToByteArray(macHEXTXT.Text), myConverter.StringToByteArray(keyTXT.Text)) == true)
            {
                MessageBox.Show("MAC er validt");
            }
            else
            {
                MessageBox.Show("MAC er ikke validt");
            }
        }
    }
}
