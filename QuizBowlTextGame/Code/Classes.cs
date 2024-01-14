// Question code
public interface QAImpliment{
    public string Print(bool pract);
}
public class QnA : QAImpliment{ // For Question and Answer
    public string Question, Answer, Hint;
    
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
    public QnA[] questions = {};
    
    public QuestionGroup(){
        theme = "";
        questions = new QnA[] {
            new QnA("Question",
            "Ans",
            "Hint")
        };
    }
    
    public virtual void Print(){
        Console.WriteLine($"Theme: {theme}");
    }
    
    public virtual int Length(){
        return 1;
    }
}

// Lightning Rounds
public class LightningRound : QuestionGroup{
    public string rule; //, hint;
    
    public LightningRound() : base(){
        theme = "";
        rule = "Ans";
        //hint = "Use Hint";
        questions = new QnA[] {
            new QnA("Question",
                "Ans",
                "Hint")
        };
    }
    
    public override void Print(){
        Console.WriteLine($"Theme: {theme} \nRule: {rule}");
    }
    
    public override int Length(){
        return 10;
    }
}

// Concept Groups
public class ConceptGroup{
    public string concept = "";
    public QuestionGroup[] groups;
    
    public ConceptGroup(){
        concept = "";
        groups = new QuestionGroup[] {new QuestionGroup(), new LightningRound()};
    }

    public void WriteData(){
        Console.WriteLine($"\nConcept: {concept}");
        for(int i = 0; i < groups.Length; i++){
            Console.WriteLine($"\t{i}.\t{groups[i].theme}");
        }
    }
}