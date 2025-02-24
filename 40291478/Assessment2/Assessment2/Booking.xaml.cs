﻿using System;
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
        //Creates new instance 
        Customer cuslist= new Customer(); 
        Bookings book ;
        Guest newWin = null;
        //Sets Ref Num to start at 0
        static int refno = 0;
        public Booking()
        {
            InitializeComponent();
            
            //Sets Ref Num to 1
            refno = refno + 1;
            txtBookRef.Text = refno.ToString();
            
            //Sets extras to zero
            txtBreakNA.Text = "0";
            txtBreakVeg.Text = "0";
            txtBreakNut.Text = "0";
            txtEveNA.Text = "0";
            txtEveVeg.Text = "0";
            txtEveNut.Text = "0";
            
        }

        private void btnCust_Click(object sender, RoutedEventArgs e)
        {
            //Shows the customer window 
            this.Visibility = Visibility.Hidden;
                       
        }

        private void btnGuests_Click(object sender, RoutedEventArgs e)
        {
            
                    //Hides the guest window
                    if (newWin == null)
                    {
                        newWin = new Guest(int.Parse(txtnoguest.Text));
                        newWin.Show();
                    }
                    else
                    {
                        newWin.Visibility = Visibility.Visible;

                    }
                    newWin.Show();
        }
                
        
        private void btnInvoice_Click(object sender, RoutedEventArgs e)
        {
            
                             
            //Shows the invoice window
            Invoice newWin = new Invoice(book.BookRef, book.Arrive, book.Depart, book.HireStart, book.HireEnd, book.BreakNA, book.BreakVeg,
                book.BreakNut, book.EveNA, book.EveVeg, book.EveNut, book.NoOfGuest);
            newWin.Show();
            
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                       
                //Creates new instance of bookings
                //Adds to the list of bookings               
                book = new Bookings();                
                book.Arrive = Convert.ToDateTime(dpArrive.Text);
                book.Depart = Convert.ToDateTime(dpDepart.Text);
                book.BookRef = int.Parse(txtBookRef.Text);
                book.NoOfGuest = int.Parse(txtnoguest.Text);
                cuslist.listofbookings.Add(book);
                
                
                //Clear data
                dpArrive.Text = string.Empty;
                dpDepart.Text = string.Empty;

                //increment booking ref
                refno = refno + 1;
                txtBookRef.Text = refno.ToString();

            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }



        private void btnAddExtra_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int sum = Convert.ToInt32(txtBreakNA.Text) + Convert.ToInt32(txtBreakVeg.Text) + Convert.ToInt32(txtBreakNut.Text);

                //Checks to see too many meals have been selected
                if (sum ==  book.NoOfGuest)
                {
                    //Adds to the list of bookings
                    book.BreakNA = int.Parse(txtBreakNA.Text);
                    book.BreakVeg = int.Parse(txtBreakVeg.Text);
                    book.BreakNut = int.Parse(txtBreakNut.Text);
                    book.EveNA = int.Parse(txtEveNA.Text);
                    book.EveVeg = int.Parse(txtEveVeg.Text);
                    book.EveNut = int.Parse(txtEveNut.Text);
                    cuslist.listofbookings.Add(book);
                }
                else
                {
                    
                    throw new Exception("Too many Breakfast meals added. Only a total of " +book.NoOfGuest + " are allowed");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                int summ = Convert.ToInt32(txtEveNA.Text) + Convert.ToInt32(txtEveVeg.Text) + Convert.ToInt32(txtEveNut.Text);
                if (summ == book.NoOfGuest)
                {
                    //Adds to the list of bookings                   
                    book.EveNA = int.Parse(txtEveNA.Text);
                    book.EveVeg = int.Parse(txtEveVeg.Text);
                    book.EveNut = int.Parse(txtEveNut.Text);
                    cuslist.listofbookings.Add(book);
                }
                else
                {
                    throw new Exception("Too many Evening meals added. Only a total of " + book.NoOfGuest +" are allowed");
                    
                }
            }
            catch (Exception z)
            {
                MessageBox.Show(z.Message);
            }

            //Clear fields
            txtBreakNA.Text = "0";
            txtBreakVeg.Text = "0";
            txtBreakNut.Text = "0";
            txtEveNA.Text = "0";
            txtEveVeg.Text = "0";
            txtEveNut.Text = "0";
        }


        private void btnHireAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Adds to list
                book.HireStart = Convert.ToDateTime(dpStart.Text);
                book.HireEnd = Convert.ToDateTime(dpEnd.Text);
                book.DriverName = txtDriver.Text;
                cuslist.listofbookings.Add(book);

                //Clears info
                dpStart.Text = string.Empty;
                dpEnd.Text = string.Empty;
                txtDriver.Text = string.Empty;

            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Looks for a booking with the booking reference id
                Bookings result = cuslist.listofbookings.Find(book => book.BookRef == int.Parse(txtBookRef.Text));
                if (result == null)
                {
                    //if it doesnt exists return message
                    throw new Exception("Booking doesnt exist");
                }
                else
                {
                    //Set fields with that object 
                    dpArrive.Text = Convert.ToString(result.Arrive);
                    dpDepart.Text = Convert.ToString(result.Depart);
                    txtBookRef.Text = Convert.ToString(result.BookRef);
                    txtnoguest.Text = Convert.ToString(result.NoOfGuest);
                    txtBreakNA.Text = Convert.ToString(result.BreakNA);
                    txtBreakVeg.Text = Convert.ToString(result.BreakVeg);
                    txtBreakNut.Text = Convert.ToString(result.BreakNut);
                    txtEveNA.Text = Convert.ToString(result.EveNA);
                    txtEveVeg.Text = Convert.ToString(result.EveVeg);
                    txtEveNut.Text = Convert.ToString(result.EveNut);
                    dpStart.Text = Convert.ToString(result.HireStart);
                    dpEnd.Text = Convert.ToString(result.HireEnd);
                    txtDriver.Text = Convert.ToString(result.DriverName);


                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btnUpBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bookings result = cuslist.listofbookings.Find(book => book.BookRef == int.Parse(txtBookRef.Text));
                if (result == null)
                {
                    //if it doesnt exists return message
                    throw new Exception("Booking doesnt exist");
                }
                else
                {
                    //Set fields with that object 
                    result.Arrive = Convert.ToDateTime(dpArrive.Text);
                    result.Depart = Convert.ToDateTime(dpDepart.Text);
                    result.BookRef = int.Parse(txtBookRef.Text);
                    result.NoOfGuest = int.Parse(txtnoguest.Text);

                    //Clear fields
                    dpArrive.Text = string.Empty;
                    dpDepart.Text = string.Empty;

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }

        private void btnUpExtras_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bookings result = cuslist.listofbookings.Find(book => book.BookRef == int.Parse(txtBookRef.Text));
                if (result == null)
                {
                    //if it doesnt exists return message
                    throw new Exception("Booking doesnt exist");
                }
                else
                {
                    //Set fields with that object 
                    result.BreakNA = int.Parse(txtBreakNA.Text);
                    result.BreakVeg = int.Parse(txtBreakVeg.Text);
                    result.BreakNut = int.Parse(txtBreakNut.Text);
                    result.EveNA = int.Parse(txtEveNA.Text);
                    result.EveVeg = int.Parse(txtEveVeg.Text);
                    result.EveNut = int.Parse(txtEveNut.Text);


                    //Clear fields
                    txtBreakNA.Text = "0";
                    txtBreakVeg.Text = "0";
                    txtBreakNut.Text = "0";
                    txtEveNA.Text = "0";
                    txtEveVeg.Text = "0";
                    txtEveNut.Text = "0";

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }

        private void btnHireUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bookings result = cuslist.listofbookings.Find(book => book.BookRef == int.Parse(txtBookRef.Text));
                if (result == null)
                {
                    //if it doesnt exists return message
                    throw new Exception("Booking doesnt exist");
                }
                else
                {
                    //Set fields with that object 
                    result.HireStart = Convert.ToDateTime(dpStart.Text);
                    result.HireEnd = Convert.ToDateTime(dpEnd.Text);
                    result.DriverName = txtDriver.Text;


                    //Clear fields
                    dpStart.Text = string.Empty;
                    dpEnd.Text = string.Empty;
                    txtDriver.Text = string.Empty;

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }

        private void btnDelBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bookings result = cuslist.listofbookings.Find(book => book.BookRef == int.Parse(txtBookRef.Text));
                if (result == null)
                {
                    //if it doesnt exists return message
                    throw new Exception("Booking doesnt exist");
                }
                else
                {
                    //Removes booking from list
                    cuslist.listofbookings.Remove(book);

                    //clears the fields
                    dpArrive.Text = string.Empty;
                    dpDepart.Text = string.Empty;
                    txtnoguest.Text = string.Empty;
                    txtBreakNA.Text = "0";
                    txtBreakVeg.Text = "0";
                    txtBreakNut.Text = "0";
                    txtEveNA.Text = "0";
                    txtEveVeg.Text = "0";
                    txtEveNut.Text = "0";
                    dpStart.Text = string.Empty;
                    dpEnd.Text = string.Empty;
                    txtDriver.Text = string.Empty;

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btnDelHire_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bookings result = cuslist.listofbookings.Find(book => book.BookRef == int.Parse(txtBookRef.Text));
                if (result == null)
                {
                    //if it doesnt exists return message
                    throw new Exception("Booking doesnt exist");
                }
                else
                {
                    //Reset/Delete hire from booking
                    result.HireStart = Convert.ToDateTime(string.Empty);
                    result.HireEnd = Convert.ToDateTime(string.Empty);
                    result.DriverName = string.Empty;
                    
                    //Clear hire fields
                    dpStart.Text = string.Empty;
                    dpEnd.Text = string.Empty;
                    txtDriver.Text = string.Empty;
                }
            }
                catch (Exception x)
                {
                MessageBox.Show(x.Message);
                }
            }

        private void btnDelExtra_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bookings result = cuslist.listofbookings.Find(book => book.BookRef == int.Parse(txtBookRef.Text));
                if (result == null)
                {
                    //if it doesnt exists return message
                    throw new Exception("Booking doesnt exist");
                }
                else
                {
                    //Reset/Delete extras from booking
                    result.BreakNA = int.Parse(string.Empty);
                    result.BreakVeg = int.Parse(string.Empty);
                    result.BreakNut = int.Parse(string.Empty);
                    result.EveNA = int.Parse(string.Empty);
                    result.EveVeg = int.Parse(string.Empty);
                    result.EveNut = int.Parse(string.Empty);

                    //Clear hire fields
                    txtBreakNA.Text = "0";
                    txtBreakVeg.Text = "0";
                    txtBreakNut.Text = "0";
                    txtEveNA.Text = "0";
                    txtEveVeg.Text = "0";
                    txtEveNut.Text = "0";
                }
            }
                catch (Exception x)
                {
                MessageBox.Show(x.Message);
                }
            }       
        }
       }

        
    
    

