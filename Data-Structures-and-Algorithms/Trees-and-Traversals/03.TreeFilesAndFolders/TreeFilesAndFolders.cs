namespace _03.TreeFilesAndFolders
{
    using System;
    using System.IO;

    class TreeFilesAndFolders
    {
        static void Main(string[] args)
        {
            Console.Write("Enter root directory: ");
            string rootName = Console.ReadLine();
            Console.Write("Enter subtree root directory: ");
            string dirSearchSum = Console.ReadLine();
            Folder rootFolder = new Folder(rootName);

            CreateThree(rootFolder);

            try
            {
                var subtreeSize = rootFolder.FindSubtreeSize(dirSearchSum);
                Console.WriteLine("Size of subtree: {0}", subtreeSize);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        public static void CreateThree(Folder folder)
        {
            try
            {
                string[] filesName = Directory.GetFiles(folder.Name);
                folder.AddFiles(filesName);
                var dirs = Directory.GetDirectories(folder.Name);
                foreach (var dir in dirs)
                {
                    Folder newfolder = new Folder(dir);
                    folder.AddChildsFolders(newfolder);
                    CreateThree(newfolder);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("No access to this directory");
                return;
            }
        }
    }
}
