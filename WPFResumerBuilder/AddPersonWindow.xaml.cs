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

namespace WPFResumeBuilder
{
    /// <summary>
    /// Interaction logic for AddPersonWindow.xaml
    /// </summary>
    public partial class AddPersonWindow : Window
    {
        public AddPersonWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(ageTextBox.Text) || ageTextBox.Text.Any(char.IsLetter))
            {

                MessageBox.Show("Please enter a valid age");


            }

            else
            {

                Person newPerson = new Person();
                newPerson.FirstName = firstNameTextBox.Text;
                newPerson.LastName = lastNameTextBox.Text;
                newPerson.Title = titleTextBox.Text;
                newPerson.City = cityTextBox.Text;
                newPerson.Age = Convert.ToInt32(ageTextBox.Text);
                newPerson.PhoneNumber = phoneNumberTextBox.Text;
                newPerson.Address = addressTextBox.Text;
                newPerson.Languages = languagesTextBox.Text;
                newPerson.Email = emailTextBox.Text;
                newPerson.Education = educationTextBox.Text;

                PersonDBHandler db = PersonDBHandler.Instance;
                db.AddPerson(newPerson);
                Close();
            }

        }
    }
}
