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

//Ciaran McMahon
//40291478
//Assessment 2
//Guest GUI

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for Guest.xaml
    /// </summary>
    public partial class Guest : Window
    {
        Bookings guslist = new  Bookings();
        Guests gus;
        
        public Guest(int noofguests)
        {
            InitializeComponent();
            //Set maximum character length to 10
            txtPassNum.MaxLength = 10;
            txtAge.Text = "0";
            lblguestno.Content = noofguests;

            //If no guests have been selected it will ask you to go back
            if (noofguests <= 0)
            {
                MessageBox.Show("You have selceted 0 guests return to the booking screen");
                
            }
        }
        
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {   
                //Count the number of guests and check that it is equal and if so return
                int result = guslist.listofguests.Count();
                if (result == Convert.ToInt32(lblguestno.Content))
                {
                    //Back to the booking window
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    throw new Exception("You have only entered " +result +" out of " +lblguestno.Content + " guests");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        } 
       
        private void btnAddGuest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if number of objects is less than maximum of 4 i can be added to the list
                int result = guslist.listofguests.Count();
                if (result < 4)
                   
                {
                    //Adds to the guest list
                    gus = new Guests();
                    gus.Guestname = txtGuestName.Text;
                    gus.PassportNum = txtPassNum.Text;
                    gus.Age = int.Parse(txtAge.Text);
                    guslist.listofguests.Add(gus);
                    
                    //Clear data
                    txtGuestName.Text = string.Empty;
                    txtPassNum.Text = string.Empty;
                    txtAge.Text = string.Empty;
                }
                else
                {
                    throw new Exception("Maximum of 4 guests reached");
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //If the guest with that passport number exists it will be deleted
                Guests result = guslist.listofguests.Find(gus => gus.PassportNum == txtPassNum.Text);
                if (result == null)
                {
                    //if it doesnt exists return message
                    throw new Exception("Guest doesnt exist");
                }
                else
                {
                    //Delete guest 
                    guslist.listofguests.Remove(gus);

                    //Clear fields
                    txtGuestName.Text = string.Empty;
                    txtPassNum.Text = string.Empty;
                    txtAge.Text = "0";

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btnAmend_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    //I guest with that passport number exists it will be updated
                    Guests result = guslist.listofguests.Find(gus => gus.PassportNum == txtPassNum.Text);
                    if (result == null)
                    {
                        //if it doesnt exists return message
                        throw new Exception("Guest doesnt exist");
                    }
                    else
                    {
                        //updates the object
                        result.Guestname = txtGuestName.Text;
                        result.PassportNum = txtPassNum.Text;
                        result.Age = int.Parse(txtAge.Text);

                        //Clear fields
                        txtGuestName.Text = string.Empty;
                        txtPassNum.Text = string.Empty;
                        txtAge.Text = "0";

                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }

        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            {
                {
                    try
                    {
                        //If the guest with that passport number exists it will return the guests info
                        Guests result = guslist.listofguests.Find(gus => gus.PassportNum == txtPassNum.Text);
                        if (result == null)
                        {
                            //if it doesnt exists return message
                            throw new Exception("Guest doesnt exist");
                        }
                        else
                        {
                            //Show that guest
                            txtGuestName.Text = result.Guestname;
                            txtPassNum.Text = Convert.ToString(result.PassportNum);
                            txtAge.Text = Convert.ToString(result.Age);                           
                        }
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.Message);
                    }
                }

            }
        }          
    }
}
