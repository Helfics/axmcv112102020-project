using RssReader.Common.Entities;
using SQLite;
using System.Collections.Generic;

namespace RssReader.Common.Repositories
{
    public class RssSourceRepository
    {
        private readonly string connectionString;

        public RssSourceRepository(string connectionString)
        {
            this.connectionString = connectionString;

            using (var cnx = new SQLiteConnection(connectionString))
            {
                cnx.CreateTable<RssSource>();
            }
        }

        public RssSource GetById(int id)
        {
            using (var cnx = new SQLiteConnection(connectionString))
            {
                return cnx.Table<RssSource>()
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public int Add(RssSource rssSource)
        {
            using (var cnx = new SQLiteConnection(connectionString))
            {
                cnx.Insert(rssSource);
            }

            return rssSource.Id;
        }

        public List<RssSource> GetAll()
        {
            using (var cnx = new SQLiteConnection(connectionString))
            {
                return cnx.Table<RssSource>().ToList();
            }
        }

        public void Delete(int id)
        {
            using (var cnx = new SQLiteConnection(connectionString))
            {
                cnx.Table<RssSource>().Delete(x => x.Id == id);
            }
        }
    }
}
