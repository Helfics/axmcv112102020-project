using SQLite;
using System;

namespace RssReader.Common.Entities
{
    public class RssSource
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
