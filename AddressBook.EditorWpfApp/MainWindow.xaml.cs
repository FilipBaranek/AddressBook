using AddressBook.CommonLibrary;
using Microsoft.Win32;
using System.IO;
using System.Windows;



namespace AddressBook.EditorWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeList employees;
        bool fileIsChanged;


        public MainWindow()
        {
            InitializeComponent();

            employees = new EmployeeList();

            fileIsChanged = false;
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (fileIsChanged)
            {
                ConfirmationWindow confirmationWindow = new ConfirmationWindow("Uložiť adresár", "Adresár bol zmenený, chcete ho uložiť?", "yes");
                confirmationWindow.ShowDialog();
                if (confirmationWindow.DialogResult == true)
                {
                    SaveFile_Click(sender, e);
                }
            }

            Application.Current.Shutdown();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (fileIsChanged && employees.Count != 0)
            {
                ConfirmationWindow confirmationWindow = new ConfirmationWindow("Uložiť adresár", "Adresár bol zmenený, chcete ho uložiť?", "yes");
                confirmationWindow.ShowDialog();
                if (confirmationWindow.DialogResult == true)
                {
                    SaveFile_Click(sender, e);
                }
                fileIsChanged = false;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            bool? dialog = openFileDialog.ShowDialog();
            if (dialog == true)
            {
                string fileName = openFileDialog.FileName;

                var employeeFile = EmployeeList.LoadFromJson(new FileInfo(fileName));
                if (employeeFile != null)
                {
                    employees = employeeFile;
                }

                if (employees != null)
                {
                    employeeListView.ItemsSource = employees;
                    countTextBlock.Text = $"{employees.Count}";
                }
            }

            if (employees != null)
            {
                if (employees.Count > 0)
                {
                    editButton.IsEnabled = true;
                    removeButton.IsEnabled = true;
                    searchButton.IsEnabled = true;
                }
            }

        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (employees != null && employees.Count > 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();

                saveFile.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFile.FilterIndex = 1;

                bool? dialog = saveFile.ShowDialog();

                if (dialog == true)
                {
                    string fileName = saveFile.FileName;
                    employees.SaveToJson(new FileInfo(fileName));
                }
            }
        }

        private void NewFile_Click(object sender, RoutedEventArgs e)
        {
            if (employees != null)
            {
                ConfirmationWindow confirmationWindow = new ConfirmationWindow("Uložiť adresár", "Adresár bol zmenený, chcete ho uložiť?", "yes");
                confirmationWindow.ShowDialog();
                if (fileIsChanged && employees.Count != 0)
                {
                    if (confirmationWindow.DialogResult == true)
                    {
                        SaveFile_Click(sender, e);
                    }
                }

                employees.Clear();

                fileIsChanged = false;

                countTextBlock.Text = "0";

                editButton.IsEnabled = false;
                removeButton.IsEnabled = false;
                searchButton.IsEnabled = false;
            }
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            EditEmployeeWindow addEmployeeWindow = new EditEmployeeWindow();
            addEmployeeWindow.ShowDialog();

            if (addEmployeeWindow.DialogResult == true)
            {
                if (employees == null || employees.Count == 0)
                {
                    employees = new EmployeeList();

                    editButton.IsEnabled = true;
                    removeButton.IsEnabled = true;
                    searchButton.IsEnabled = true;
                }
                if (addEmployeeWindow.NewEmployee != null)
                {
                    employees.Add(addEmployeeWindow.NewEmployee);
                }

                employeeListView.ItemsSource = employees;
                countTextBlock.Text = $"{employees.Count}";

                fileIsChanged = true;

                addEmployeeWindow.Close();
            }

        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = employeeListView.SelectedItem as Employee;
            employeeListView.SelectedItem = null;

            if (selectedEmployee != null)
            {
                ConfirmationWindow confirmationWindow = new ConfirmationWindow("Odstrániť zamestnanca", "Chcete odstrániť vybratého zamestnanca?", "no");
                confirmationWindow.ShowDialog();
                if (confirmationWindow.DialogResult == true)
                {
                    employees.Remove(selectedEmployee);

                    countTextBlock.Text = $"{employees.Count}";

                    if (employees.Count == 0)
                    {
                        editButton.IsEnabled = false;
                        removeButton.IsEnabled = false;
                        searchButton.IsEnabled = false;
                    }

                    fileIsChanged = true;
                }
            }
            else
            {
                InfoDialog("Nebol označený žiadný zamestnanec");
            }
        }

        private void InfoDialog(string message)
        {
            MessageBoxResult result = MessageBox.Show(message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = employeeListView.SelectedItem as Employee;
            employeeListView.SelectedItem = null;

            if (selectedEmployee != null)
            {
                Employee? refEmployee = null;
                foreach (Employee employee in employees)
                {
                    if (employee.Name == selectedEmployee.Name)
                    {
                        refEmployee = employee;
                        break;
                    }
                }

                if (refEmployee != null)
                {
                    EditEmployeeWindow editEmployeeWindow = new EditEmployeeWindow(ref refEmployee);
                    editEmployeeWindow.ShowDialog();

                    if (editEmployeeWindow.DialogResult == true)
                    {
                        fileIsChanged = true;
                    }
                }
            }
            else
            {
                InfoDialog("Nebol označený žiadný zamestnanec");
            }
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            AppInformationWindow appInformationWindow = new AppInformationWindow();
            appInformationWindow.ShowDialog();
        }

        private void SearchEmployees_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow(employees);
            searchWindow.ShowDialog();
        }
    }
}