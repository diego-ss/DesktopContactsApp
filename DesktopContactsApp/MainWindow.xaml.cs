using DesktopContactsApp.Domain;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts = new List<Contact>();

        public MainWindow()
        {
            InitializeComponent();
            FillContactsList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            FillContactsList();
        }

        private void FillContactsList()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().OrderBy(c => c.Name).ToList();
            }

            if(contacts != null)
            {
                contactsListView.ItemsSource = contacts;
            }
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (sender as TextBox);
            
            var filteredList = contacts.Where(c => c.Name.ToUpper().Contains(textBox.Text.ToUpper())).ToList();
            contactsListView.ItemsSource = filteredList;
        }
    }
}
