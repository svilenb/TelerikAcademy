namespace _02.FindExecutableFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class FindExecutableFiles
    {
        static void Main(string[] args)
        {
            string startingdirectory = @"C:\Windows\";

            ListExecutableFiles(startingdirectory);
        }

        private static void ListExecutableFiles(string directory)
        {
            try
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    if (file.EndsWith(".exe"))
                    {
                        Console.WriteLine(file);
                    }
                }

                foreach (string dir in Directory.GetDirectories(directory))
                {
                    ListExecutableFiles(dir);
                }
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine(uae.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
