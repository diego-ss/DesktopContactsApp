using DesktopContactsApp.Domain;
using SQLite;
using System;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Lógica interna para ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private Contact _contact;

        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            _contact = contact;
            FillFields();
        }

        private void FillFields()
        {
            nameTextBox.Text = _contact.Name;
            emailTextBox.Text = _contact.Email;
            phoneTextBox.Text = _contact.Phone;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var messageResult = MessageBox.Show("Are you sure to delete thiscontact? This operation can't be undone!",
                "Delete contact", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Question);

            if (messageResult == MessageBoxResult.Yes)
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    connection.CreateTable<Contact>();
                    connection.Delete(_contact);
                }

                this.Close();
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            _contact.Name = nameTextBox.Text;
            _contact.Email = emailTextBox.Text;
            _contact.Phone = phoneTextBox.Text; 

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(_contact);
            }
        }
    }
}
