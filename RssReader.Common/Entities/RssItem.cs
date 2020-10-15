using SQLite;
using System;

namespace RssReader.Common.Entities
{
    public class RssItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }
        public string ImageUrl { get; set; }
    }
}
