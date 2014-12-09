namespace _03.TreeFilesAndFolders
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Folder
    {
        private string name;
        private IList<File> files;
        private IList<Folder> childFolders;

        public Folder(string name)
            : this(name, new List<File>(), new List<Folder>())
        {
        }

        public Folder(string name, IList<File> files, IList<Folder> childFolders)
        {
            this.Name = name;
            this.Files = files;
            this.ChildFolders = childFolders;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        private IList<File> Files
        {
            get
            {
                return this.files;
            }
            set
            {
                this.files = value;
            }
        }

        private IList<Folder> ChildFolders
        {
            get
            {
                return this.childFolders;
            }
            set
            {
                this.childFolders = value;
            }
        }

        public void AddFiles(string[] filesNames)
        {
            for (int i = 0; i < filesNames.Length; i++)
            {
                FileInfo newFileInfo = new FileInfo(filesNames[i]);
                long fileSize = newFileInfo.Length;
                this.Files.Add(new File(filesNames[i], fileSize));
            }
        }

        public void AddChildsFolders(Folder chieldFolder)
        {
            this.ChildFolders.Add(chieldFolder);
        }

        public long CalculateSize()
        {
            long sum = 0;
            foreach (var file in this.files)
            {
                sum += file.Size;
            }

            foreach (var folder in this.ChildFolders)
            {
                sum += folder.CalculateSize();
            }

            return sum;
        }

        public Folder FindSubFolder(string searchFolderName)
        {
            var folders = new Stack<Folder>();
            folders.Push(this);
            while (folders.Count > 0)
            {
                var currentFolder = folders.Pop();
                if (currentFolder.Name == searchFolderName)
                {
                    return currentFolder;
                }

                foreach (var folder in currentFolder.ChildFolders)
                {
                    folders.Push(folder);
                }
            }

            throw new ArgumentException("Searched subfolder doesn't exist!");
        }

        public long FindSubtreeSize(string searchFolderName)
        {
            var searchFolder = this.FindSubFolder(searchFolderName);
            return searchFolder.CalculateSize();
        }
    }
}
