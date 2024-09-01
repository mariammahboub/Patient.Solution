using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PatientTherapyService 
    {

        private readonly HttpClient _httpClient;

        public PatientTherapyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddPatientTherapyAsync(PatientTherapy patientTherapy)
        {
            var response = await _httpClient.PostAsJsonAsync("api/PatientTherapy", patientTherapy);
            response.EnsureSuccessStatusCode();
        }


        public async Task<List<PatientTherapy>> GetPatientTherapiesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<PatientTherapy>>("api/PatientTherapy");
        }

        public async Task<PatientTherapy> GetPatientThreapyByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<PatientTherapy>($"api/PatientTherapy/{id}");
        }

        public async Task UpdatePatientTherapiesAsync(PatientTherapy therapy)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/PatientTherapy/{therapy.Id}", therapy);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePatientTherapiesAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/PatientTherapy/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<PatientTherapy>> SearchPatientTherapiesAsync(string fullName)
        {
            return await _httpClient.GetFromJsonAsync<List<PatientTherapy>>($"api/PatientTherapy/search?fullName={Uri.EscapeDataString(fullName)}");

        }
    }

}
