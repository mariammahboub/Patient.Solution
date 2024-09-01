using Core.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Services
{
    public class PatientReservationService
    {
        private readonly HttpClient _httpClient;

        public PatientReservationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddPatientReservationAsync(PatientReservation patient)
        {
            var response = await _httpClient.PostAsJsonAsync("api/PatientReservation", patient);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<PatientReservation>> GetPatientReservationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<PatientReservation>>("api/PatientReservation");
        }

        public async Task<PatientReservation> GetPatientReservationByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<PatientReservation>($"api/PatientReservation/{id}");
        }

        public async Task UpdatePatientReservationAsync(PatientReservation reservation)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/PatientReservation/{reservation.Id}", reservation);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePatientReservationAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/PatientReservation/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<PatientReservation>> SearchPatientReservationsAsync(DateTime? startDate, DateTime? endDate)
        {
            var url = $"api/PatientReservation/search?startDate={startDate?.ToString("yyyy-MM-dd")}&endDate={endDate?.ToString("yyyy-MM-dd")}";
            return await _httpClient.GetFromJsonAsync<List<PatientReservation>>(url);
        }
    }
}
