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

namespace WPFUsersSQLite
{
    /// <summary>
    /// Interaction logic for PersonDetailsWindow.xaml
    /// </summary>
    public partial class PersonDetailsWindow : Window
    {
        Person person;

        public PersonDetailsWindow(Person person)
        {
            InitializeComponent();
            this.person = person;

            //display the user
            firstNameTextBox.Text = person.FirstName;
            lastNameTextBox.Text = person.LastName;
            cityTextBox.Text = person.City;
            ageTextBox.Text = person.Age.ToString();
        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
