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
using WPFResumeBuilder;

namespace WPFResumeBuilder
{
    /// <summary>
    /// Interaction logic for UpdatePersonWindow.xaml
    /// </summary>
    public partial class UpdatePersonWindow : Window
    {


        Person person;
        public UpdatePersonWindow(Person person)
        {
            InitializeComponent();

            this.person = person;
            firstNameTextBox.Text = person.FirstName;
            lastNameTextBox.Text = person.LastName;
            titleTextBox.Text = person.Title;
            cityTextBox.Text = person.City;
            ageTextBox.Text = person.Age.ToString();
            phoneNumberTextBox.Text = person.PhoneNumber;
            addressTextBox.Text = person.Address;
            languagesTextBox.Text = person.Languages;
            emailTextBox.Text = person.Email;
            educationTextBox.Text = person.Education;
        }

    

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(ageTextBox.Text) || ageTextBox.Text.Any(char.IsLetter))
            {

                MessageBox.Show("Please enter a valid age");


            }

            else
            {
                person.FirstName = firstNameTextBox.Text;
                person.LastName = lastNameTextBox.Text;
                person.Title = titleTextBox.Text;
                person.City = cityTextBox.Text;
                person.Age = Convert.ToInt32(ageTextBox.Text);
                person.PhoneNumber = phoneNumberTextBox.Text;
                person.Address = addressTextBox.Text;
                person.Languages = languagesTextBox.Text;
                person.Email = emailTextBox.Text;
                person.Education = educationTextBox.Text;

                PersonDBHandler db = PersonDBHandler.Instance;
                db.UpdatePerson(person);
                Close();

            }
        }
    }
}