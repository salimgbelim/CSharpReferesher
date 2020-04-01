using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeBook.Tests.AdapterPattern.Adapters
{
    public class StarWarsApiCharacterSourceAdapter : ICharacterSourceAdapter
    {
        private readonly StarWarsApi _starWarsApi = new StarWarsApi();

        public async Task<List<Person>> GetCharacters()
        {
            return await _starWarsApi.GetCharacters();
        }
    }
}