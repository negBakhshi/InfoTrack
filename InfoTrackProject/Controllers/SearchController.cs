using InfoTrackProject.Helper;
using InfoTrackProject.Models;
using InfoTrackProject.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace InfoTrackProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchLogic _searchLogic;
        public SearchController(ISearchLogic searchLogic)
        {
            _searchLogic = searchLogic;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SearchTermVM searchTermVM)
        {
            var search = new SearchTerm
            {
                KeyWord = searchTermVM.KeyWord,
                URL = searchTermVM.URL
            };

            var rank = _searchLogic.GetRank(search);

            if (rank.Count == 1 && rank.Single() == -1)
                searchTermVM.Ranks = "Too Many Requests. Please wait a few minutes before trying again.";
            else
                searchTermVM.Ranks = string.Join(", ", rank);

            return View(searchTermVM);
        }
    }
}
