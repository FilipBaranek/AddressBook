
using System.Text;

namespace AddressBook.CommonLibrary
{
    public class SearchResult
    {
        public Employee[] Employees { get; }

        public SearchResult(Employee[] Employees)
        {
            this.Employees = Employees;
        }

        public void SaveToCsv(FileInfo csvFile, string delimiter = "\t")
        {
            if (csvFile.Exists)
            {
                if (Employees.Length != 0)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("Name" + delimiter + "MainWorkplace" + delimiter + "Workplace" + delimiter + "Room" + delimiter + "Phone" + delimiter + "Email" + delimiter + "Position");

                    foreach (var employee in Employees)
                    {
                        sb.AppendLine($"{employee.Name}{delimiter}{employee.MainWorkplace}{delimiter}{employee.Workplace}{delimiter}{employee.Room}{delimiter}{employee.Phone}{delimiter}{employee.Email}{delimiter}{employee.Position}");
                    }
                    File.WriteAllText(csvFile.FullName, sb.ToString());
                }
                else
                {
                    Console.WriteLine("Do súboru by neboli uložený žiadný zamestnanci, pretože žiadného nenašlo");
                }
            }
            else
            {
                Console.WriteLine("CSV Súbor neexistuje, zamestnanci neboli uložení.");
            }
        }

    }
}
