using Core.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Services
{
    public class RoomService
    {
        private readonly HttpClient _httpClient;

        public RoomService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddRoomAsync(Room room)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Room", room);
            response.EnsureSuccessStatusCode(); // Throws an exception if the status code is not 2xx
        }


        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Room>>("api/Room");
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Room>($"api/Room/{id}");
        }

        public async Task UpdateRoomAsync(Room room)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Room/{room.Id}", room);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteRoomAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Room/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Room>> SearchRoomsAsync(string RoomNumber)
        {
            return await _httpClient.GetFromJsonAsync<List<Room>>($"api/Room/search?RoomNumber={Uri.EscapeDataString(RoomNumber)}");
        }
    }
}
