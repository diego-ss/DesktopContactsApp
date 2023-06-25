using DesktopContactsApp.Domain;
using SQLite;
using System.Collections.Generic;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            List<Contact> contacts;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList();
            }

            if(contacts != null)
            {
                contactsListView.ItemsSource = contacts;
            }
        }
    }
}
