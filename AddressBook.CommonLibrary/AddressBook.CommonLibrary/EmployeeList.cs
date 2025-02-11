using System.Collections.ObjectModel;
using System.Text.Json;

namespace AddressBook.CommonLibrary
{
    public class EmployeeList : ObservableCollection<Employee>
    {
        public static EmployeeList? LoadFromJson(FileInfo jsonFIle)
        {
            if (!jsonFIle.Exists)
            {
                Console.Error.WriteLine("Súbor so zamestanancami sa nenašiel");
                return null;
            }

            string jsonData = File.ReadAllText(jsonFIle.FullName);

            var employees = JsonSerializer.Deserialize<ObservableCollection<Employee>>(jsonData);
            var employeeList = new EmployeeList();

            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    employeeList.Add(employee);
                }
            }

            return employeeList;
        }

        public void SaveToJson(FileInfo jsonFile)
        {
            string jsonData = JsonSerializer.Serialize(this);

            if (jsonData == null)
            {
                Console.WriteLine("Do súboru neboli načítane žiadné dáta");
                return;
            }

            File.WriteAllText(jsonFile.FullName, jsonData);
        }

        public IEnumerable<string> GetPositions()
        {
            List<string> positions = new List<string>();
            foreach (var employee in this)
            {
                if (positions.Count == 0 || !positions.Contains(employee.Position))
                {
                    positions.Add(employee.Position);
                }
            }

            return positions.OrderBy(position => position);
        }

        public IEnumerable<string> GetMainWorkplaces()
        {
            List<string> workplaces = new List<string>();
            foreach (var employee in this)
            {
                if (employee.MainWorkplace != null)
                {
                    if (workplaces.Count == 0 || !workplaces.Contains(employee.MainWorkplace))
                    {
                        workplaces.Add(employee.MainWorkplace);
                    }
                }
            }

            return workplaces.OrderBy(workplace => workplace);
        }

        public SearchResult Search(string? mainWorkplace = null, string? position = null, string? name = null)
        {
            var employees = this.AsEnumerable();

            if (mainWorkplace != null)
            {
                employees = employees.Where(employee => string.Equals(employee.MainWorkplace, mainWorkplace));
            }
            if (position != null)
            {
                employees = employees.Where(employee => string.Equals(employee.Position, position));
            }
            if (name != null)
            {
                employees = employees.Where(employee => employee.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            return new SearchResult(employees.ToArray());
        }

    }
}
