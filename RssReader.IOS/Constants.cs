using System;
using System.IO;

namespace RssReader.IOS
{
    public static class Constants
    {
        public static string ConnectionString
        {
            get
            {
                var directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"..", "Library", "Database");

                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                return Path.Combine(directoryPath, "rssreader.db3");
            }
        }
    }
}
