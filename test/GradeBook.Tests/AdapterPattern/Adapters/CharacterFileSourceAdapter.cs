using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeBook.Tests.AdapterPattern.Adapters
{
    public class CharacterFileSourceAdapter : ICharacterSourceAdapter
    {
        private readonly string _filePath;
        private readonly CharacterFileSource _fileSource = new CharacterFileSource();

        public CharacterFileSourceAdapter(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<List<Person>> GetCharacters()
        {
           return await _fileSource.GetCharactersFromFile(_filePath);
        }
    }
}