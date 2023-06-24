using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Lógica interna para NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save contact
            Close();
        }
    }
}
