using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GradeBook.Tests.AdapterPattern.Adapters
{
    public class StarWarsApi
    {
        public async Task<List<Person>> GetCharacters()
        {
            string url = "https://swapi.co/api/people";
            using var client = new HttpClient();

            string result = await client.GetStringAsync(url);
            var people = JsonConvert.DeserializeObject<ApiResult<Person>>(result).Results;
          
            return people;
        }
    }
}