using System.Collections.Generic;
using System.Linq;

namespace GradeBook.Tests.CompositePattern
{
    public class DirectoryItem : FileSystemItem
    {
        public DirectoryItem(string name) : base(name)
        {
        }

        public List<FileSystemItem> Items { get; } = new List<FileSystemItem>();

        public void Add(FileSystemItem component)
        {
            Items.Add(component);
        }

        public void Remove(FileSystemItem component)
        {
            Items.Remove(component);
        }
        
        public override decimal GetSizeInKb()
        {
            return Items.Sum(x => x.GetSizeInKb());
        }
    }
}