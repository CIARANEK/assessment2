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
//Invoice GUI

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
    {
        //Passes through variables
        public Invoice(int bookref, DateTime bookstart, DateTime bookend, DateTime hirestart, DateTime hireend, int breakna, int breakveg,
             int breaknut,int evena, int eveveg, int evenut, int guest)
        {
            InitializeComponent();
            //Works out cost
            TimeSpan ts = bookend - bookstart;
            int caldays = ts.Days;
            int dayguest = caldays * guest;
            TimeSpan tss = hireend - hirestart;
            int calhire = tss.Days;
            int nights = caldays * 50;
            int breakfast = (breakna + breakveg) + breaknut;
            int evening = (evena + eveveg) + evenut;
            int mealsb = breakfast * 5;
            int mealse = evening * 15;
            
         
            int costnights = nights * guest;            
            int breakmeals = mealsb * caldays;
            int evemeals = mealse * caldays;            
            int hire = calhire * 50;
            int sub1 = costnights + breakmeals;
            int sub2 = evemeals + hire;
            int total = sub1 + sub2;

            //displays cost breakdown in labels
            lblbookref.Content = bookref;
            lblnodays.Content = costnights;
            lblbreakcost.Content = breakmeals;
            lblevecost.Content = evemeals;
            lblguests.Content = guest;
            lblhirecost.Content = hire;
            lblTotal.Content = total;
            lbldiet.Content = (breakveg+eveveg) +" Vegetarian and " + (breaknut+evenut) + " nut allegery meals";
        }
        
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //Closes the invoice form
            this.Hide();
        }
    }
}
