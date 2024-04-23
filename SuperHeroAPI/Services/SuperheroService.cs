namespace SuperheroAPI.Services
{
    using SuperheroAPI.Services.Interfaces;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class SuperheroService : ISuperheroService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://www.superheroapi.com/api/10223345425719740";
        // move it to appsettings later;
        //used yours instead of generating new one for now.

        public SuperheroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //GetALL not needed!
        public async Task<string> GetSuperheroById(int superheroId)
        {
            var url = $"{BaseUrl}/{superheroId}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var returnedValue =  await response.Content.ReadAsStringAsync();
                return returnedValue;
            }
            else
            {   
                throw new Exception($"Failed to fetch superhero info. Status code: {response.StatusCode}");
            }
        }

        //public async Task<IEnumerable<string>> GetFavoriteSuperheroes(List<int> superheroIds)
        //{
        //    var favoriteSuperheroes = new List<string>();
        //    foreach (var id in superheroIds)
        //    {
        //        var superheroInfo = await GetSuperheroInfo(id);
        //        favoriteSuperheroes.Add(superheroInfo);
        //    }
        //    return favoriteSuperheroes;
        //}

    }

}
