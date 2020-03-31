using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.Tests.CompositePattern
{
    public class FileSystemBuilder
    {
        private DirectoryItem currentDirectory;

        public FileSystemBuilder(string rootDirectory)
        {
            Root = new DirectoryItem(rootDirectory);
            currentDirectory = Root;
        }

        public DirectoryItem Root { get; }

        public DirectoryItem AddDirectory(string directoryName)
        {
            var dir = new DirectoryItem(directoryName);
            currentDirectory.Add(dir);
            currentDirectory = dir;
            return dir;
        }

        public FileItem AddFile(string fileName, int fileInBytes)
        {
            var file = new FileItem(fileName, fileInBytes);
            currentDirectory.Add(file);
            return file;
        }

        public DirectoryItem SetCurrentDirectory(string toDirectory)
        {
            var dirStack = new Stack<DirectoryItem>();
            dirStack.Push(Root);

            while (dirStack.Any())
            {
                var current = dirStack.Pop();
                if (current.Name == toDirectory)
                {
                    currentDirectory = current;
                    return current;
                }

                foreach (var item in current.Items.OfType<DirectoryItem>())
                {
                    dirStack.Push(item);
                }
            }
            
            throw new InvalidOperationException($"Director name '{toDirectory} not found");
        }
    }
}