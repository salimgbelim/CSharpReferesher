using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace GradeBook.Tests.CompositePattern
{
    public class CompositePatternTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CompositePatternTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void it_uses_composite_pattern()
        {
            // Arrange
            var root = new DirectoryItem("development");
            var proj1 = new DirectoryItem("project1");
            var proj2 = new DirectoryItem("project2");

            root.Add(proj1);
            root.Add(proj2);

            proj1.Add(new FileItem("p1f1.txt", 2100));
            proj1.Add(new FileItem("p1f2.txt", 3100));

            var subDir1 = new DirectoryItem("sub-dir1");
            subDir1.Add(new FileItem("p1f3.txt", 4100));
            subDir1.Add(new FileItem("p1f4.txt", 5100));

            proj1.Add(subDir1);

            proj2.Add(new FileItem("p2f1.txt", 6100));
            proj2.Add(new FileItem("p2f2.txt", 7100));

            // Act
            _testOutputHelper.WriteLine($"Total size (proj2) : {proj2.GetSizeInKb()}");
            _testOutputHelper.WriteLine($"Total size (proj1) : {proj1.GetSizeInKb()}");
            _testOutputHelper.WriteLine($"Total size (root) : {root.GetSizeInKb()}");
        }

        [Fact]
        public void it_uses_composite_pattern_with_builder()
        {
            // Arrange
            var builder = new FileSystemBuilder("development");
            builder.AddDirectory("project1");
            builder.AddFile("p1f1.txt", 2100);
            builder.AddFile("p1f2.txt", 3100);
            builder.AddDirectory("sub-dir");
            builder.AddFile("p1f3.txt", 4100);
            builder.AddFile("p1f4.txt", 5100);

            builder.SetCurrentDirectory("development");

            builder.AddDirectory("project2");
            builder.AddFile("p2f1.txt", 6100);
            builder.AddFile("p2f2.txt", 7100);

            // Act
            _testOutputHelper.WriteLine($"Total size (proj2) : {builder.Root.GetSizeInKb()}");

            var jsonViewOfDirectoryAndFiles = JsonConvert.SerializeObject(builder.Root, Formatting.Indented);
            _testOutputHelper.WriteLine($"{jsonViewOfDirectoryAndFiles}");
        }
    }
}