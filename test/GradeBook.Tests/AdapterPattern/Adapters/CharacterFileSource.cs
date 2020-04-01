using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GradeBook.Tests.AdapterPattern.Adapters
{
    public class CharacterFileSource
    {
        public async Task<List<Person>> GetCharactersFromFile(string filePath)
        {
            var people = JsonConvert.DeserializeObject<List<Person>>(await
                File.ReadAllTextAsync(filePath));

            return people;
        }
    }
}