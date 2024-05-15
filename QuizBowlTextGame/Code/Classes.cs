// Question code
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Text.Json.Serialization;

public interface QAImpliment{
    public string Print(bool pract);
}
public class QnA : QAImpliment{ // For Question and Answer
    public string Question {get; set;}
    public string Answer {get; set;}
    public string Hint {get; set;}
    
    [JsonConstructor]
    public QnA() {
        int i = 0;
    }
    public QnA(string question1, string answer1, string hint1){
        Question = question1;
        Answer = answer1;
        Hint = hint1;
    }
    
    public string Print(bool pract){
        Console.WriteLine($"{Question}\n");
        if (pract){ // Hint
            Console.WriteLine($"{Hint}\n");
        }
        return Answer;
    }
}
// Question groups
public class QuestionGroup{
    public string theme {get; set;}
    [AllowNull] public string rule {get; set;}
    public QnA[] questions {get; set;}
    public int length {get; set;}
    
    [JsonConstructor]
    public QuestionGroup() {
        length = 1;
    }

    public QuestionGroup(string theme1, string rule1, QnA[] questions1, int length1) {
        theme = theme1;
        rule = rule1;
        questions = questions1;
        length = length1;
    }

    public QuestionGroup(bool lightning = false) {
        theme = "";
        if (lightning) {
            rule = "";
        } else {
            rule = null;
        }
        questions = new QnA[] {
            new QnA("Question",
            "Ans",
            "Hint")
        };
    }
    
    public void Print(){
        if (rule == null) {
            Console.WriteLine($"Theme: {theme}");
        } else {
            Console.WriteLine($"Theme: {theme} \nRule: {rule}");
        }
    }
}

// Concept Groups
public class ConceptGroup{
    public string concept {get; set;}
    public QuestionGroup[] groups {get; set;}
    
    
    public ConceptGroup(string concept1, QuestionGroup[] groups1){
        concept = concept1;
        groups = groups1;
    }
    [JsonConstructor]
    public ConceptGroup(){
        concept = "";
        groups = new QuestionGroup[] {new QuestionGroup(), new QuestionGroup()};
    }

    public void WriteData(){
        Console.WriteLine($"\nConcept: {concept}");
        for(int i = 0; i < groups.Length; i++){
            Console.WriteLine($"\t{i}.\t{groups[i].theme}");
        }
    }
}