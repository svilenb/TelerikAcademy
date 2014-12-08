namespace Music.Client
{
    using System;
    using System.Collections.Generic;

    public class Artist
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IEnumerable<string> Albums { get; set; }
    }
}
