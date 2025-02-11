using AddressBook.CommonLibrary;
using System.Windows;

namespace AddressBook.EditorWpfApp
{
    /// <summary>
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {

        public Employee? NewEmployee {  get; set; }

        public EditEmployeeWindow()
        {
            InitializeComponent();
        }

        public EditEmployeeWindow(ref Employee employee)
        {
            InitializeComponent();

            nameTextBox.Text = employee.Name;
            positionTextBox.Text = employee.Position;
            emailTextBox.Text = employee.Email;
            phoneTextBox.Text = employee.Phone;
            roomTextBox.Text = employee.Room;
            mainWorkplaceTextBox.Text = employee.MainWorkplace;
            workplaceTextBox.Text = employee.Workplace;

            NewEmployee = employee;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text) || string.IsNullOrEmpty(positionTextBox.Text) || string.IsNullOrEmpty(emailTextBox.Text))
            {
                InfoDialog("Neboli zadané potrebné údaje");
                return;
            }

            if (NewEmployee != null)
            {
                NewEmployee.Name = nameTextBox.Text;
                NewEmployee.Position = positionTextBox.Text;
                NewEmployee.Email = emailTextBox.Text;
                NewEmployee.Phone = phoneTextBox.Text;
                NewEmployee.Room = roomTextBox.Text;
                NewEmployee.MainWorkplace = mainWorkplaceTextBox.Text;
                NewEmployee.Workplace = workplaceTextBox.Text;
            }
            else
            {
                string name = nameTextBox.Text;
                string position = positionTextBox.Text;
                string email = emailTextBox.Text;
                string? phone = phoneTextBox.Text;
                string? room = roomTextBox.Text;
                string? mainWorkplace = mainWorkplaceTextBox.Text;
                string? workplace = workplaceTextBox.Text;

                NewEmployee = new Employee(name, position, email, phone, room, mainWorkplace, workplace);
            }

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }


        private void InfoDialog(string message)
        {
            MessageBoxResult result = MessageBox.Show(message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Question);
        }

    }


}
