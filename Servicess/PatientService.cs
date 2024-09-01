using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PatientService
    {
        private readonly HttpClient _httpClient;

        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddPatientAsync(Patient patient)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Patient", patient);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Patient>> GetPatientsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Patient>>("api/Patient");
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Patient>($"api/Patient/{id}");
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Patient/{patient.Id}", patient);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePatientAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Patient/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Patient>> SearchPatientsAsync(string fullName)
        {
            return await _httpClient.GetFromJsonAsync<List<Patient>>($"api/Patient/search?fullName={Uri.EscapeDataString(fullName)}");
        }
    }
}
