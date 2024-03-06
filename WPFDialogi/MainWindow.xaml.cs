using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPFDialogi
{
    public partial class MainWindow : Window
    {
        private ListOfPersons pList = new ListOfPersons();

        public MainWindow()
        {
            InitializeComponent();
            pListView.ItemsSource = pList.persons;
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            PersonWindow personWindow = new PersonWindow();
            personWindow.person = new Person();
            personWindow.DataContext = personWindow.person;
            if (personWindow.ShowDialog() == true)
            {
                pList.AddPerson(personWindow.person);
            }
        }

        private void EditPerson_Click(object sender, RoutedEventArgs e)
        {
            Person per = pListView.SelectedItem as Person;
            if (per != null)
            {
                PersonWindow personWindow = new PersonWindow();
                personWindow.person = new Person(per.FirstName, per.LastName, per.Education);
                personWindow.DataContext = personWindow.person;
                if (personWindow.ShowDialog() == true)
                {
                    pList.EditPerson(pList.persons.IndexOf(per), personWindow.person);
                }
            }
            else
            {
                MessageBox.Show("Wybierz osobę do edycji.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            Person per = pListView.SelectedItem as Person;
            if (per != null)
            {
                pList.RemovePerson(per);
            }
            else
            {
                MessageBox.Show("Wybierz osobę do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Sort(string sortBy)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(pListView.ItemsSource);
            dataView.SortDescriptions.Clear();
            dataView.SortDescriptions.Add(new SortDescription(sortBy, ListSortDirection.Ascending));
            dataView.Refresh();
        }

        private void SortByName_Click(object sender, RoutedEventArgs e)
        {
            Sort("FirstName");
        }

        private void SortByLastName_Click(object sender, RoutedEventArgs e)
        {
            Sort("LastName");
        }

        private void SortByEducation_Click(object sender, RoutedEventArgs e)
        {
            Sort("Education");
        }
    }
}