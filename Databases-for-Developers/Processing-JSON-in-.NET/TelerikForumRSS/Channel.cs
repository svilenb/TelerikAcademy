namespace TelerikForumRSS
{
    using System.Collections.Generic;

    public class Channel
    {
        public string Title { get; set; }

        public List<Item> Item { get; set; }
    }
}
