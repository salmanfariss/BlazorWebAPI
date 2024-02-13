using CRUD_BlazorSample.Context;
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
            var response = await _httpClient.PostAsJsonAsync("AddEmployee", employee);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"updateemployee", employee);

            if (!response.IsSuccessStatusCode)
            {
                // Handle unsuccessful response (e.g., status code indicates error)
                throw new HttpRequestException($"Update employee failed with status code: {response.StatusCode}");
            }

            // Read the response content as a string
            string responseContent = await response.Content.ReadAsStringAsync();

            // Check if the response content is empty
            if (string.IsNullOrWhiteSpace(responseContent))
            {
                throw new InvalidOperationException("Update employee response is empty or invalid JSON.");
            }

            try
            {
                // Deserialize the JSON response into an Employee object
                return JsonSerializer.Deserialize<Employee>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Enable case-insensitive property name matching
                });
            }
            catch (JsonException ex)
            {
                throw new JsonException("Error parsing JSON response when updating employee.", ex);
            }
        }


        public async Task DeleteEmployee(string id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteEmployee/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
