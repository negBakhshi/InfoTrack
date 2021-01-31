using System.ComponentModel.DataAnnotations;

namespace InfoTrackProject.ViewModel
{
    public class SearchTermVM
    {
        [Required]
        [Display(Name = "Search Term")]
        public string KeyWord { get; set; }
        [Required]
        public string URL { get; set; }
        public string Ranks { get; set; }

    }
}