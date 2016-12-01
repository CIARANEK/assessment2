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

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    /// //Ciaran McMahon
    /// //402914
    /// //Assessment 2
    /// //Booking GUI
    public partial class Booking : Window
    {
        static int refno = 0;
        public Booking()
        {
            InitializeComponent();
            
            txtBookRef.Text = refno.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuests_Click(object sender, RoutedEventArgs e)
        {
            Guest newWin = new Guest();
            newWin.Show();
        }

        private void btnInvoice_Click(object sender, RoutedEventArgs e)
        {
            Invoice newWin = new Invoice();
            newWin.Show();
        }

        private void chkHire_Checked(object sender, RoutedEventArgs e)
        {
            if (chkHire.IsChecked == true)
            {
                dpStart.IsEnabled = true;
                dpEnd.IsEnabled = true;
                txtDriver.IsEnabled = true;
            }
        }
    }
}
