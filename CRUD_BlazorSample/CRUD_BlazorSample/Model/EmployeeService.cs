using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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
            try
            {
                var response = await _httpClient.PostAsJsonAsync("AddEmployee", employee);
                response.EnsureSuccessStatusCode();
                return employee;
            }
            catch (HttpRequestException ex)
            {
                // Handle the exception, log or display an appropriate error message
                Console.WriteLine($"Error occurred during the HTTP request: {ex.Message}");
                throw; // Re-throw the exception or handle it as needed
            }
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"updateemployee", employee);

            if (!response.IsSuccessStatusCode)
            {
                // Handle unsuccessful response (e.g., status code indicates error)
                throw new HttpRequestException($"Update employee failed with status code: {response.StatusCode}");
            }
            else
            {
                return employee;
            }
            
        }


        public async Task DeleteEmployee(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteEmployee/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
