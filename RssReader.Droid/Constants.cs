using System;
using System.IO;

namespace RssReader.Droid
{
    public static class Constants
    {
        public static string ConnectionString
        {
            get => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "rssreader.db3");
        }
    }
}