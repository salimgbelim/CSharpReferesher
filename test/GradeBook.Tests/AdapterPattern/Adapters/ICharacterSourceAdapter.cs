using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeBook.Tests.AdapterPattern.Adapters
{
    public interface ICharacterSourceAdapter
    {
        Task<List<Person>> GetCharacters();
    }
}