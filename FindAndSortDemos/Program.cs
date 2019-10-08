using System;
using System.Collections.Generic;

namespace FindAndSortDemos
{
    class Program
    {

        public static Employee employeeToFind = new Employee();

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee("Bob", "Ross", 100000.00d),
                new Employee("Fred", "Armison", 200000.00d),
                new Employee("Fred", "Estare", 300000.00d),
                new Employee("Steven", "Colbert", 500000.00d),
                new Employee("Ed", "Sullivan", 120000.00d),
                new Employee("Jamie", "Curtis", 180000.00d),
                new Employee("Chevy", "Chase", 10000.00d),
            };

            Console.WriteLine("Please type the name of an employee you wish to find.");
            string search = Console.ReadLine();

            Console.Clear();

            if (!string.IsNullOrEmpty(search))
            {
                string[] searchArr = search.Split(' ');
                employeeToFind.FirstName = searchArr[0];

                if(searchArr.Length > 1)
                {
                    employeeToFind.LastName = searchArr[1];
                }

                Employee empFound = employees.Find(EmployeeSearch);

                if (empFound != null)
                {
                    Console.WriteLine($"Employee Found: {empFound.ToString()}");
                }

                else Console.WriteLine($"No match found for {search}");
            }

            else Console.WriteLine("invalid input");

            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadLine();

            Console.Clear();
            Main(args);
        }

        static bool EmployeeSearch(Employee empFromList)
        {
            return (empFromList.FirstName.ToUpper() == employeeToFind.FirstName.ToUpper() 
                && (string.IsNullOrEmpty(employeeToFind.LastName) || 
                empFromList.LastName.ToUpper() == employeeToFind.LastName.ToUpper()));
        }

    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  double Salary { get; set; }


        public Employee()
        {

        }

        public Employee(string fName, string lName, double salary)
        {
            FirstName = fName;
            LastName = lName;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} earns {Salary.ToString("c")} per year.";
        }
    }
}
