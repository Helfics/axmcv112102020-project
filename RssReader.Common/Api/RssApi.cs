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
        public async Task<List<RssItem>> Get(string url)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return XDocument
                        .Parse(content)
                        .Descendants("item")
                        .Select(x => new RssItem
                        {
                            Title = x.Element("title").Value,
                            Description = x.Element("description").Value
                        })
                        .ToList();
                }
            }
        }
    }
}
