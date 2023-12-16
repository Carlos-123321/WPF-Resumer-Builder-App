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
    /// Interaction logic for PersonDetailsWindow.xaml
    /// </summary>
    public partial class PersonDetailsWindow : Window
    {
        Person person;

        PersonDBHandler db = PersonDBHandler.Instance;
        List<Person> people;

        public PersonDetailsWindow(Person person)
        {
            InitializeComponent();

            this.person = person;

            //display the user
            firstNameTextBox.Text = person.FirstName;
            lastNameTextBox.Text = person.LastName;
            titleTextBox.Text = person.Title;
            cityTextBox.Text = person.City;
            ageTextBox.Text = person.Age.ToString();
            phoneNumberTextBox.Text = person.PhoneNumber.ToString();
            addressTextBox.Text = person.Address.ToString();
            languagesTextBox.Text = person.Languages.ToString();
            emailTextBox.Text = person.Email.ToString();
            educationTextBox.Text = person.Education.ToString();
        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {

            
            UpdatePersonWindow updatePersonWindow = new UpdatePersonWindow(person);
            updatePersonWindow.ShowDialog();
            RefreshAllPeopleList();

        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
        
                PersonDBHandler db = PersonDBHandler.Instance;
                db.DeletePerson(person);
                Close();

         }

  

        private void RefreshAllPeopleList()
        {
           
            people = db.ReadAllPersons();
            
        }

        private void ShowResume_Click(object sender, RoutedEventArgs e)
        {

            ResumeBuilder resumeBuilder = new ResumeBuilder(person);
            resumeBuilder.ShowDialog();
            

        }
    }


}
