using RssReader.Common.Entities;
using RssReader.Common.Repositories;
using System;
using System.Collections.Generic;

namespace RssReader.Common.Services
{
    public class RssSourceService
    {
        private readonly RssSourceRepository rssSourceRepository;

        public RssSourceService(string connectionString)
        {
            rssSourceRepository = new RssSourceRepository(connectionString);
        }

        public RssSource GetById(int id)
        {
            return rssSourceRepository.GetById(id);
        }

        public int Add(string title, string url)
        {
            var rssSource = new RssSource
            {
                Title = title,
                Url = url,
                CreatedAt = DateTime.Now
            };

            return rssSourceRepository.Add(rssSource);
        }

        public List<RssSource> GetAll()
        {
            return rssSourceRepository.GetAll();
        }


    }
}
