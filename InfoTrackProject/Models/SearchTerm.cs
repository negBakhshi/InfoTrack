namespace InfoTrackProject.Models
{
    /// <summary>
    /// Represents the structure of the keyword and URL
    /// </summary>
    public class SearchTerm
    {
        /// <summary>
        /// the search phrase that user enters
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary>
        /// the URL that user wants to check the rank for it
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// building the query string for Google
        /// </summary>
        public string BuildSearchUrl() => KeyWord.Trim().Replace(' ','+') + "+" + URL;
        
    }
}