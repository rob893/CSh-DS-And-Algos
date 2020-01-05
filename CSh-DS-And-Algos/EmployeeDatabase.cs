using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CSh_DS_And_Algos
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public int AnnualSalary { get; set; }
        public DateTime HireDate { get; set; }
    }

    public class EmployeeDatabase
    {
        private Dictionary<string, Employee> employeesLookup = new Dictionary<string, Employee>();


        public EmployeeDatabase(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                employeesLookup[employee.EmployeeId] = employee;
            }
        }

        public Employee GetEmployeeById(string employeeId)
        {
            return employeesLookup.ContainsKey(employeeId) ? employeesLookup[employeeId] : null;
        }

        public void AddEmployee(Employee employee)
        {
            employeesLookup[employee.EmployeeId] = employee;
        }

        public void DeleteEmployeeById(string employeeId)
        {
            if (employeesLookup.ContainsKey(employeeId))
            {
                employeesLookup.Remove(employeeId);
            }
        }

        public string GetODataString(Expression<Func<Employee, bool>> exp)
        {
            return ParseLambaExpression(exp.Body);
        }

        private string ParseLambaExpression(Expression exp)
        {
            switch(exp.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return ParseMemberExpression(exp);
                case ExpressionType.Constant:
                    return ParseConstantExpression(exp);
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.AndAlso:
                case ExpressionType.OrElse:
                    return ParseBinaryExpression(exp);
                default:
                    return "";
            }
        }

        private string ParseMemberExpression(Expression exp)
        {
            var member = exp as MemberExpression;
            return member.Member.Name;
        }

        private string ParseConstantExpression(Expression exp)
        {
            var constant = exp as ConstantExpression;

            if (constant.Type == typeof(string))
            {
                return "'" + constant.Value.ToString() + "'";
            }
            
            return constant.Value.ToString();
        }

        private string ParseBinaryExpression(Expression exp)
        {
            var member = exp as BinaryExpression;
            
            var left = ParseLambaExpression(member.Left);
            var right = ParseLambaExpression(member.Right);

            return ParseBinaryExpression(left, right, member);
        }

        private string ParseBinaryExpression(string left, string right, BinaryExpression exp)
        {
            switch (exp.NodeType)
            {
                case ExpressionType.GreaterThan:
                    return left + " gt " + right;
                case ExpressionType.GreaterThanOrEqual:
                    return left + " ge " + right;
                case ExpressionType.LessThan:
                    return left + " lt " + right;
                case ExpressionType.LessThanOrEqual:
                    return left + " le " + right;
                case ExpressionType.Equal:
                    return left + " eq " + right;
                case ExpressionType.AndAlso:
                    return left + " and " + right;
                case ExpressionType.OrElse:
                    return left + " or " + right;
                case ExpressionType.NotEqual:
                    return left + " ne " + right; 
                default:
                    return "";
            }
        }

        public IEnumerable<Employee> FindEmployees(Expression<Func<Employee, bool>> predicate)
        {
            var body = predicate.Body;
            //var prop = body.;
        
            return employeesLookup.Values.Where(predicate.Compile());
        }

        public static EmployeeDatabase BuildDatabase()
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    FirstName = "Bob",
                    LastName = "Joe",
                    EmployeeId = "1",
                    AnnualSalary = 100000,
                    HireDate = DateTime.Now
                },
                new Employee
                {
                    FirstName = "Robert",
                    LastName = "Black",
                    EmployeeId = "6",
                    AnnualSalary = 30000,
                    HireDate = DateTime.Parse("12/2/2009")
                },
                new Employee
                {
                    FirstName = "Celeste",
                    LastName = "White",
                    EmployeeId = "2",
                    AnnualSalary = 75000,
                    HireDate = DateTime.Parse("12/2/2009")
                },
                new Employee
                {
                    FirstName = "Jack",
                    LastName = "Joe",
                    EmployeeId = "3",
                    AnnualSalary = 150000,
                    HireDate = DateTime.Parse("12/2/2009")
                },
                new Employee
                {
                    FirstName = "John",
                    LastName = "Joe",
                    EmployeeId = "4",
                    AnnualSalary = 45000,
                    HireDate = DateTime.Parse("12/2/2009")
                },
                new Employee
                {
                    FirstName = "Larry",
                    LastName = "Smith",
                    EmployeeId = "5",
                    AnnualSalary = 60000,
                    HireDate = DateTime.Parse("12/2/2019")
                }
            };

            return new EmployeeDatabase(employees);
        }
    }
}