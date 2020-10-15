using Microsoft.Toolkit.Parsers.Rss;
using RssReader.Common.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader.Common.Api
{
    public class RssApi
    {
        private HttpClient httpClient;

        public RssApi()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<RssItem>> Get(string url)
        {
            using (var response = await httpClient.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var parser = new RssParser();

                return parser
                        .Parse(content)
                        .Select(x => new RssItem
                        {
                            Title = x.Title,
                            Description = x.Summary,
                            ImageUrl = x.ImageUrl,
                            PubDate = x.PublishDate
                        })
                        .ToList();
            }
        }
    }
}
