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
        Console.WriteLine($"Question: {Question}\n");
        if (pract){ // Hint
            Console.WriteLine($"Hint: {Hint}\n");
        }
        return Answer;
    }
}
// Question catagorys
public class QuestionCatagory{
    public string theme {get; set;}
    [AllowNull] public string rule {get; set;}
    public QnA[] questions {get; set;}
    public int length {get; set;}
    
    [JsonConstructor]
    public QuestionCatagory() {
        length = 1;
    }

    public QuestionCatagory(string theme1, string rule1, QnA[] questions1, int length1) {
        theme = theme1;
        rule = rule1;
        questions = questions1;
        length = length1;
    }

    public QuestionCatagory(bool lightning = false) {
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
    public QuestionCatagory[] catagories {get; set;}
    public bool mathCheck {get; set;}
    
    
    public ConceptGroup(string concept1, QuestionCatagory[] catagorys1){
        concept = concept1;
        catagories = catagorys1;
    }
    [JsonConstructor]
    public ConceptGroup(){
        concept = "";
        catagories = new QuestionCatagory[] {new QuestionCatagory(), new QuestionCatagory()};
    }

    public void WriteData(){
        Console.WriteLine($"\nConcept: {concept}");
        for(int i = 0; i < catagories.Length; i++){
            Console.WriteLine($"\t{i}.\t{catagories[i].theme}");
        }
    }
}

// Integer Vector for determining which questions have been answered

public struct IVec3{
    public int x, y, z;

    public IVec3(int x1, int y1, int z1){
        x = x1;
        y = y1;
        z = z1;
    }
}