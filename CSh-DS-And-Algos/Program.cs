using System;
using System.Collections.Generic;
using System.Linq;

namespace CSh_DS_And_Algos
{
    

    public class Program
    {
        public static void Main(string[] args)
        {
            var db = EmployeeDatabase.BuildDatabase();

            var test = db.GetODataString(emp => emp.AnnualSalary > 5000 && emp.FirstName == "Bob");
            Console.WriteLine(test);
            // var emps = db.FindEmployees(emp => emp.AnnualSalary > 50000 && emp.FirstName == "Jackz");
            // foreach (var emp in emps)
            // {
            //     Console.WriteLine(emp.FirstName);
            // }
        }
    }
}
