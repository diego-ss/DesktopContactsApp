using DesktopContactsApp.Domain;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Interação lógica para ContactControl.xam
    /// </summary>
    public partial class ContactControl : UserControl
    {

        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // dependence property permite o binding direto com xml
        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", 
                typeof(Contact), typeof(ContactControl), 
                new PropertyMetadata(null /* valor inicial da propriedade*/, SetText));

        /// <summary>
        /// Método de callback para as mudanças na propriedade relacionada
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = (ContactControl)d;

            if(control != null)
            {
                // pegando o contato atualizado
                var contact = (e.NewValue as Contact);
                control.nameTextBlock.Text = contact.Name;
                control.emailTextBlock.Text = contact.Email;
                control.phoneTextBlock.Text = contact.Phone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
