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
        
        Customer cus;
        Booking newWin = null;
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
            //if an instance of booking doesnt exists it will create one            
            if (newWin == null)
            {
                newWin = new Booking();
                newWin.Show();
            }
            else
            {
                //If it does exist it will be shown
                newWin.Visibility = Visibility.Visible;
                
            }
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
            //Increments the customer refernce number
            refno = refno + 1;
            txtCustRef.Text = refno.ToString();

        }
                  
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            //finds that object in the list based on reference number
            try
            {
                Customer result = cusSingle.listofcustomers.Find(cus => cus.CustRef == int.Parse(txtCustRef.Text));
                if (result == null)
                {
                    //if that object doesnt exists then return message
                    throw new Exception("Customer doesnt exist");
                }
                else
                {
                    //set fields to display the object that was found
                    txtName.Text = result.CustName;
                    txtAddress.Text = result.CustAddress;
                    txtCustRef.Text = Convert.ToString(result.CustRef);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btnDelCust_Click(object sender, RoutedEventArgs e)
        {
            //Deletes customer only if they dont have a booking
            try
            {
                Customer result = cusSingle.listofcustomers.Find(cus => cus.CustRef == int.Parse(txtCustRef.Text));
                if (result == null)
                {
                    //if it doesnt exists return message
                    throw new Exception("Customer doesnt exist");
                }
                else
                {
                    //Removes customer from list
                    cusSingle.listofcustomers.Remove(cus);

                    //clears the fields
                    txtName.Text = string.Empty;
                    txtAddress.Text = string.Empty;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btnUpCust_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //finds that object in the list based on reference number
                Customer result = cusSingle.listofcustomers.Find(cus => cus.CustRef == int.Parse(txtCustRef.Text));
                if (result == null)
                {
                    throw new Exception("Customer doesnt exist");
                }
                else
                {
                    //Update dates the object 
                    result.CustName = txtName.Text;
                    result.CustAddress = txtAddress.Text;
                    result.CustRef = int.Parse(txtCustRef.Text);

                    //Clears the data after created
                    txtName.Text = string.Empty;
                    txtAddress.Text = string.Empty;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }              
    }
    }