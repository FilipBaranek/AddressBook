using AddressBook.CommonLibrary;
using Microsoft.Win32;
using System.IO;
using System.Windows;




namespace AddressBook.ViewerWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeList? employees;
        private SearchResult? result;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            bool? dialog = openFileDialog.ShowDialog();


            if (dialog == true)
            {
                string fileName = openFileDialog.FileName;
                employees = EmployeeList.LoadFromJson(new FileInfo(fileName));

                if (employees != null)
                {
                    comboBoxPositions.ItemsSource = employees.GetPositions();
                    comboBoxWorkplaces.ItemsSource = employees.GetMainWorkplaces();
                }
            }
        }

        private void SearchEmployees_Click(object sender, RoutedEventArgs e)
        {
            if (employees != null)
            {
                string? name = null;
                if (nameTextBox.Text != "")
                {
                    name = nameTextBox.Text;
                }
                string? position = (string)comboBoxPositions.SelectedItem;
                string? workplace = (string)comboBoxWorkplaces.SelectedItem;

                result = employees.Search(workplace ?? null, position ?? null, name ?? null);
                EmployeeListBox.ItemsSource = result.Employees;
                countTextBlock.Text = $"{result.Employees.Length}";
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            nameTextBox.Text = "";
            comboBoxPositions.SelectedItem = null;
            comboBoxWorkplaces.SelectedItem = null;
            EmployeeListBox.ItemsSource = null;
            countTextBlock.Text = "0";

            result = null;
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            if (result != null)
            {
                SaveFileDialog saveFile = new SaveFileDialog();

                saveFile.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFile.FilterIndex = 1;

                bool? dialog = saveFile.ShowDialog();

                if (dialog == true)
                {
                    string fileName = saveFile.FileName;
                    result.SaveToCsv(new FileInfo(fileName));
                }
            }
        }
    }
}