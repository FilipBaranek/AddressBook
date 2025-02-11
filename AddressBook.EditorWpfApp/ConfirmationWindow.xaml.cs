using System.Windows;

namespace AddressBook.EditorWpfApp
{
    /// <summary>
    /// Interaction logic for ConfirmationWindow.xaml
    /// </summary>
    public partial class ConfirmationWindow : Window
    {
        public ConfirmationWindow(string title, string message, string button)
        {
            InitializeComponent();
            
            Title = title;
            messageTextBlock.Text = message;

            if (button == "yes")
            {
                yesButton.Focus();
            }
            else if (button == "no")
            {
                noButton.Focus();
            }
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
            Close();
        }
    }
}
