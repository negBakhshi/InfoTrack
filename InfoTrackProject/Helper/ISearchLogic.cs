using InfoTrackProject.Models;
using System.Collections.Generic;

namespace InfoTrackProject.Helper
{
    public interface ISearchLogic
    {
        List<int> GetRank(SearchTerm searchTerm);
    }
}
