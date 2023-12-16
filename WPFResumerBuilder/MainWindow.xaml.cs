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

namespace WPFResumeBuilder
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


        private bool selectionHandler = false;
        private void AllPeopleDataGrid_SelectionChanged(object sender, 
            SelectionChangedEventArgs e)
        {

            if (!selectionHandler)
            {
                selectionHandler = true;

                if (AllPeopleDataGrid.SelectedItem is Person selectedPerson)
                {

                    PersonDetailsWindow personDetailsWindow = new PersonDetailsWindow(selectedPerson);
                    personDetailsWindow.ShowDialog();
                    RefreshAllPeopleList();
                }
                else
                {
                    AddPersonWindow addPersonWindow = new AddPersonWindow();
                    addPersonWindow.ShowDialog();
                    RefreshAllPeopleList();
                }
                selectionHandler = false;
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
