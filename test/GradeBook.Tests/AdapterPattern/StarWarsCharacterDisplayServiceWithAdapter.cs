using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GradeBook.Tests.AdapterPattern.Adapters;
using Newtonsoft.Json;

namespace GradeBook.Tests.AdapterPattern
{
    public class StarWarsCharacterDisplayServiceWithAdapter
    {
        private readonly ICharacterSourceAdapter _characterSourceAdapter;

        public StarWarsCharacterDisplayServiceWithAdapter(ICharacterSourceAdapter characterSourceAdapter)
        {
            _characterSourceAdapter = characterSourceAdapter;
        }

        public async Task<string> ListCharacters()
        {
            var people = await _characterSourceAdapter.GetCharacters();
            var sb = new StringBuilder();
            int nameWidth = 30;
            sb.AppendLine($"{"NAME".PadRight(nameWidth)}   {"HAIR"}");

            foreach (Person person in people)
            {
                sb.AppendLine($"{person.Name.PadRight(nameWidth)}   {person.HairColor}");
            }

            return sb.ToString();
        }
    }
}