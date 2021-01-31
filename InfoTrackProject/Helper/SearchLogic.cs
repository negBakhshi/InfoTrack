using InfoTrackProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace InfoTrackProject.Helper
{
    public class SearchLogic : ISearchLogic
    {
        /// <summary>
        /// Gets the search result on google as HTML and then finds the result nodes based on
        /// pattern and then selects only those with keyword and url in them.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public List<int> GetRank(SearchTerm searchTerm)
        {
            using (var client = new WebClient())
            {
                try
                {
                    var gResult = client.DownloadString($"https://www.google.com/search?num=100&q={searchTerm.KeyWord}");
                    var pattern = new Regex("<div class=\"ZINbbc xpd O9g5cc uUPGi\">(.*?)</div>").ToString();

                    var matchList = Regex.Matches(gResult, pattern).Cast<Match>().ToList();

                    return matchList.Select((x, i) => new { i, x })
                                    .Where(x => x.ToString().Contains(searchTerm.URL))
                                    .Select(x => x.i + 1)
                                    .ToList();
                }
                // in case of the web exception 409 from google when there are too many requests.
                catch (WebException)
                {
                    return new List<int>() { -1 };
                }


            }
        }
    }
}