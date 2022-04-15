using System;

namespace Capstone.Models
{
    public class CodeExample
    {
        public int codeId { get; set; }
        public string title { get; set; }
        public string programmingLanguage { get; set; }
        public int submissionStatus { get; set; } = 0;
        public string codeDescription { get; set; }
        public string exampleDate { get; set; }
        public string codeSnippet { get; set; }
        public string difficultyRank { get; set; }
        public string category { get; set; } //might have to make list/dict
        public string keyword{get; set; }
        public string attribution { get; set; }
        public bool isPublic { get; set; } = false;
    }
    public class PendingExample
    {
        public int codeId { get; set; }
        public int submissionStatus { get; set; } = 0; //0=pending, 1=approved, 2=declined
        public string title { get; set; }
        public string programmingLanguage { get; set; }
        public string codeDescription { get; set; }
        public string exampleDate { get; set; } = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        public string codeSnippet { get; set; }
        public string difficultyRank { get; set; }
        public string category { get; set; } //might have to make list/dict
        public string attribution { get; set; }
        public bool isPublic { get; set; } = false;
    }

}
