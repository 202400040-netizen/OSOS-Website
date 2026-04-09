using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OSOS_Website.Models
{
    public class FirebaseService
    {
        private readonly HttpClient _httpClient;
        private readonly string _databaseUrl = "https://osos-rhythmgame-default-rtdb.firebaseio.com/";

        public FirebaseService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<RankingEntry>> GetGlobalRanking(int limit = 10)
        {
            var ranking = new List<RankingEntry>();

            try
            {
                // Usar REST API directamente (más confiable)
                string url = $"{_databaseUrl}ranking.json";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(json) && json != "null")
                    {
                        var dict = JsonSerializer.Deserialize<Dictionary<string, RankingEntry>>(json);

                        if (dict != null)
                        {
                            ranking = dict.Values
                                .OrderByDescending(x => x.Score)
                                .Take(limit)
                                .ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cargando ranking: {ex.Message}");
            }

            return ranking;
        }
    }
}