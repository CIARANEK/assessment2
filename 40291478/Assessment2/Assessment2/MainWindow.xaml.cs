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

//Ciaran McMahon 
//40291478
//Assessment 2
//Customer GUI

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        //Creates singleton object
        CustomerSingleton cusSingle = new CustomerSingleton();

        Customer cus ;

        //Sets Ref Num to start at 0
        static int refno = 0;
        public MainWindow()
        {
            InitializeComponent();
            //Sets Ref Num to 1
            refno = refno + 1;
            txtCustRef.Text = refno.ToString();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //Clears the form of data
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCustRef.Text = string.Empty;
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            //Shows the Booking form
            Booking newWin = new Booking();
            newWin.Show();
        }

        private void btnCustAdd_Click(object sender, RoutedEventArgs e)
        {   
            try
        
        {
            //Creates new instance of customers
            cus = new Customer();               
            cus.CustName = txtName.Text;
            cus.CustAddress = txtAddress.Text;
            cus.CustRef = int.Parse(txtCustRef.Text);
            cusSingle.listofcustomers.Add(cus);

            //Clears the data after created
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;

            }

            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);

            }
            refno = refno + 1;
            txtCustRef.Text = refno.ToString();
            
         }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (cusSingle.listofcustomers.Contains(new Customer { CustRef = int.Parse(txtCustRef.Text) }))
                {
                    txtName.Text = cus.CustName;
                    txtAddress.Text = cus.CustAddress;
                    txtCustRef.Text = Convert.ToString(cus.CustRef);
                }
                else
                {
                    throw new Exception("Customer doesnt exist"); 
                }
                }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }       
      }
    }
