using CRUD_BlazorSample.Context;
using Microsoft.EntityFrameworkCore;

namespace CRUD_BlazorSample.Model
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7269/api/Employee/");
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var demo =  await _httpClient.GetFromJsonAsync<List<Employee>>("GetEmployees");
            return demo;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"GetEmployee/{id}");
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var response = await _httpClient.PostAsJsonAsync("AddEmployee", employee);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateEmployee/{employee.Id}", employee);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task DeleteEmployee(string id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteEmployee/{id}");
            response.EnsureSuccessStatusCode();
        }



        //private readonly DatabaseContext _databaseContext;

        //public EmployeeService(DatabaseContext databaseContext)
        //{
        //    _databaseContext = databaseContext;
        //}

        ///// <summary>
        ///// Retrieves a list of all employees asynchronously.
        ///// </summary>
        ///// <returns>A task representing the asynchronous operation. The task result contains the list of employees.</returns>
        //public async Task<List<Employee>> GetEmployeesAsync()
        //{
        //    return await _databaseContext.Employees.ToListAsync();
        //}

        ///// <summary>
        ///// Adds a new employee to the database asynchronously.
        ///// </summary>
        ///// <param name="employee">The employee object to add.</param>
        ///// <returns>A task representing the asynchronous operation. The task result indicates whether the operation was successful.</returns>
        //public async Task<bool> AddNewEmployee(Employee employee)
        //{
        //    await _databaseContext.Employees.AddAsync(employee);
        //    await _databaseContext.SaveChangesAsync();
        //    return true;
        //}

        ///// <summary>
        ///// Retrieves an employee by their ID asynchronously.
        ///// </summary>
        ///// <param name="id">The ID of the employee to retrieve.</param>
        ///// <returns>A task representing the asynchronous operation. The task result contains the employee if found, otherwise null.</returns>
        //public async Task<Employee?> GetEmployeeById(int id)
        //{
        //    Employee? employee = await _databaseContext.Employees.FirstOrDefaultAsync(emp => emp.Id == id);
        //    return employee;
        //}

        ///// <summary>
        ///// Updates an existing employee in the database asynchronously.
        ///// </summary>
        ///// <param name="employee">The updated employee object.</param>
        ///// <returns>A task representing the asynchronous operation. The task result indicates whether the operation was successful.</returns>
        //public async Task<bool> UpdateEmployee(Employee employee)
        //{
        //    _databaseContext.Employees.Update(employee);
        //    await _databaseContext.SaveChangesAsync();
        //    return true;
        //}

        ///// <summary>
        ///// Deletes an existing employee from the database asynchronously.
        ///// </summary>
        ///// <param name="employee">The employee object to delete.</param>
        ///// <returns>A task representing the asynchronous operation. The task result indicates whether the operation was successful.</returns>
        //public async Task<bool> DeleteEmployee(Employee employee)
        //{
        //    _databaseContext.Employees.Remove(employee);
        //    await _databaseContext.SaveChangesAsync();
        //    return true;
        //}
    }
}
