using RssReader.Common.Api;
using RssReader.Common.Entities;
using RssReader.Common.Repositories;
using RssReader.Common.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RssReader.Common.Services
{
    public class RssReaderService
    {
        private readonly RssSourceRepository rssSourceRepository;
        private readonly RssApi rssApi;

        public RssReaderService(string connectionString)
        {
            rssSourceRepository = new RssSourceRepository(connectionString);
            rssApi = new RssApi();
        }

        public RssSource GetRssSourceById(int id)
        {
            return rssSourceRepository.GetById(id);
        }

        public int AddRssSource(string title, string url)
        {
            if (string.IsNullOrEmpty(title))
                throw new AddRssSourceTitleRequiredException();

            if (!(Uri.TryCreate(url, UriKind.Absolute, out var uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)))
                throw new AddRssSourceUrlRequiredException();

            var rssSource = new RssSource
            {
                Title = title,
                Url = url,
                CreatedAt = DateTime.Now
            };

            return rssSourceRepository.Add(rssSource);
        }

        public List<RssSource> GetAllRssSources()
        {
            return rssSourceRepository.GetAll();
        }

        public void DeleteRssSource(int id)
        {
            rssSourceRepository.Delete(id);
        }

        public async Task<List<RssItem>> GetAllRssItems(string url)
        {
            try
            {
                return await rssApi.Get(url);
            }
            catch (Exception)
            {
                throw new UnreachableRssFeedException();
            }
        }
    }
}
