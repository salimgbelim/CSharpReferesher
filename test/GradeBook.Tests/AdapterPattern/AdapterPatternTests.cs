using System.Threading.Tasks;
using GradeBook.Tests.AdapterPattern.Adapters;
using Xunit;
using Xunit.Abstractions;

namespace GradeBook.Tests.AdapterPattern
{
    public class AdapterPatternTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AdapterPatternTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task it_displays_characters_from_file()
        {
            var service = new StarWarsCharacterDisplayService();

            var result = await service.ListCharacters(CharacterSource.File);

            _testOutputHelper.WriteLine(result);
        }

        [Fact]
        public async Task it_displays_characters_from_Api()
        {
            var service = new StarWarsCharacterDisplayService();

            var result = await service.ListCharacters(CharacterSource.Api);

            _testOutputHelper.WriteLine(result);
        }

        [Fact]
        public async Task it_displays_characters_from_file_with_adapter_pattern()
        {
            var characterFileSourceAdapter = new CharacterFileSourceAdapter(@"AdapterPattern/People.json");
            var service = new StarWarsCharacterDisplayServiceWithAdapter(characterFileSourceAdapter);

            var result = await service.ListCharacters();

            _testOutputHelper.WriteLine(result);
        }

        [Fact]
        public async Task it_displays_characters_from_Api_with_Adapter_pattern()
        {
            var starWarsApiCharacterSourceAdapter = new StarWarsApiCharacterSourceAdapter();
            var service = new StarWarsCharacterDisplayServiceWithAdapter(starWarsApiCharacterSourceAdapter);

            var result = await service.ListCharacters();

            _testOutputHelper.WriteLine(result);
        }
    }
}