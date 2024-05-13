// Question code
using System.Diagnostics.CodeAnalysis;

public interface QAImpliment{
    public string Print(bool pract);
}
public class QnA : QAImpliment{ // For Question and Answer
    public string Question = "", Answer = "", Hint = "";
    
    public QnA(string Q, string A, string H){
        Question = Q;
        Answer = A;
        Hint = H;
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
    public string theme;
    [AllowNull] public string rule;
    public QnA[] questions = {new QnA("", "", "")};
    public int length;
    
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
    public string concept = "";
    public QuestionGroup[] groups;
    
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