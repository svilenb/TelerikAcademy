namespace Music.Client
{
    using System.Collections.Generic;

    public class Album
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
        
        public string Producer { get; set; }

        public virtual IEnumerable<string> Songs { get; set; }

        public virtual string Artist { get; set; }
    }
}
