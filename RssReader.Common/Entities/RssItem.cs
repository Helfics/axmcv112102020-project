using SQLite;
using System;

namespace RssReader.Common.Entities
{
    public class RssItem
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }
        public string ImageUrl { get; set; }
        public bool IsRead { get; set; }
    }
}
