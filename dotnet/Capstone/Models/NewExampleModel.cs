namespace Capstone.Models
{
    public class NewExampleModel
    {
            public int codeId {get; set;}
            public int pendingStatus {get; set;}
            public string title {get; set;}
            public string programmingLanguage {get;set;}
            public string codeDescription {get; set;}
            public string exampleDate {get; set;}
            public string codeSnippet {get; set;}
            public int difficultyRank {get; set;}
            public string category {get; set;} //might have to make list/dict
    }
}