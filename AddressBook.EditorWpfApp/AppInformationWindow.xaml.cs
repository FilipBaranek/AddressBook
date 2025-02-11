using System.Windows;

namespace AddressBook.EditorWpfApp
{
    /// <summary>
    /// Interaction logic for AppInformationWindow.xaml
    /// </summary>
    public partial class AppInformationWindow : Window
    {
        public AppInformationWindow()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
