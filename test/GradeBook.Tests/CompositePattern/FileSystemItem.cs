namespace GradeBook.Tests.CompositePattern
{
    public abstract class FileSystemItem
    {
        public readonly string Name;

        public FileSystemItem(string name)
        {
            Name = name;
        }

        public abstract decimal GetSizeInKb();
    }
}