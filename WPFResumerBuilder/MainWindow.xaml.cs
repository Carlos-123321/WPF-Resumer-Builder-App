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

namespace WPFUsersSQLite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        PersonDBHandler db = PersonDBHandler.Instance;
        List<Person> people;
        public MainWindow()
        {
            InitializeComponent();

            RefreshAllPeopleList();
        }

        private void RefreshAllPeopleList() 
        {
            AllPeopleDataGrid.ItemsSource = null;
            people = db.ReadAllPersons();
            AllPeopleDataGrid.ItemsSource = people;
        }

       

        private void AllPeopleDataGrid_SelectionChanged(object sender, 
            SelectionChangedEventArgs e)
        {
            Person person = (Person)AllPeopleDataGrid.SelectedItem;

            if (person != null)
            { 
                PersonDetailsWindow personDetailsWindow = new PersonDetailsWindow(person);
                personDetailsWindow.ShowDialog();
                RefreshAllPeopleList();
            }

        }


        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {
            AddPersonWindow addPersonWindow = new AddPersonWindow();
            addPersonWindow.ShowDialog();
            RefreshAllPeopleList();

        }
    }
}
