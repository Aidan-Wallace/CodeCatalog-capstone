using System;

namespace Capstone.Models
{
    public class CodeExample
    {
        public int userId { get; set; }
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
        public int isPublic { get; set; } = 0; //0 = NotPublic, 1 = IsPublic

        public int genericExample { get; set; } = 0; //0 = Not included 1 = included in list
        
    }

}
