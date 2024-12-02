namespace EmployeeAPI.Service
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using EmployeeAPI.Models;
    using System.Xml;
    using Newtonsoft.Json;

    public class EmployeeService
    {
        private readonly string filePath = "employee.json";

        public List<Employee> GetAllEmployees()
        {
            return ReadFile();
        }

        public Employee GetEmployeeById(int id)
        {
            return ReadFile().FirstOrDefault(e => e.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            var employees = ReadFile();
            employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            employees.Add(employee);
            WriteFile(employees);
        }

        public void UpdateEmployee(Employee employee)
        {
            var employees = ReadFile();
            var existingEmployee = employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Department = employee.Department;
                existingEmployee.Salary = employee.Salary;
                WriteFile(employees);
            }
        }

        public void DeleteEmployee(int id)
        {
            var employees = ReadFile();
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                WriteFile(employees);
            }
        }

        private List<Employee> ReadFile()
        {
            if (!File.Exists(filePath))
            {
                return new List<Employee>();
            }
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Employee>>(json);
        }

        private void WriteFile(List<Employee> employees)
        {
            var json = JsonConvert.SerializeObject(employees, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }

}
