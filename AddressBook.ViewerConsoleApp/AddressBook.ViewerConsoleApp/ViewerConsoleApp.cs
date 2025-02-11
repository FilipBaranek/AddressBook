using AddressBook.CommonLibrary;
using CommandLine;
using System.Text;



internal class Program
{
    private static void Main(string[] args)
    {
        string? argumentLine = Console.ReadLine();

        if (argumentLine == null || argumentLine == "")
        {
            Console.WriteLine("Nebol zadaný žiadný príkaz");
            return;
        }

        var argumentsArray = SplitCommandLine(argumentLine);
        

        var parser = Parser.Default.ParseArguments<Options>(argumentsArray);

        parser.WithParsed(options =>
        {
            if (options.Input != null)
            {
                FileInfo fileInfo = new FileInfo(options.Input);
                EmployeeList? employees = EmployeeList.LoadFromJson(fileInfo);

                if (employees != null)
                {
                    SearchResult result = employees.Search(mainWorkplace: options.Workplace, position: options.Position, name: options.Name);

                    int i = 1;
                    foreach (var employee in result.Employees)
                    {
                        Console.Write($"[{i}] {employee.Name}\nPracivoisko: {employee.Workplace}\nMiestnost: {employee.Room}\nTelefon: {employee.Phone}\nE-mail: {employee.Email}\nFunkcia: {employee.Position}");
                        Console.WriteLine("\n");
                        i++;
                    }

                    if (options.Output != null)
                    {
                        result.SaveToCsv(new FileInfo(options.Output));
                    }

                }
            }
        })
        .WithNotParsed(errors =>
        {
            Console.WriteLine("Nesprávny príkazy");
        });
    }

    private static string[] SplitCommandLine(string argumentLine)
    {
        List<string> arguments = new List<string>();
        StringBuilder sb = new StringBuilder();
        bool inQuotes = false;

        foreach (char c in argumentLine)
        {
            if (c == '\"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ' ' && !inQuotes)
            {
                arguments.Add(sb.ToString());
                sb.Clear();
            }
            else
            {
                sb.Append(c);
            }
        }

        arguments.Add(sb.ToString());

        return arguments.ToArray();
    }
}


class Options
{
    [Option("input", Required = false)]
    public string? Input { get; set; }

    [Option("name", Required = false)]
    public string? Name { get; set; }

    [Option("main-workplace", Required = false)]
    public string? Workplace { get; set; }

    [Option("position", Required = false)]
    public string? Position { get; set; }

    [Option("output", Required = false)]
    public string? Output { get; set; }
}

