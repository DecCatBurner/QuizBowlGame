// Game for Quiz Bowl Practice
using System;

// Game
public class QuizBowlGame
{
    public static void Main(string[] args)
    {
        // Interface vars
        ConceptGroup[] concepts = new ConceptGroup[] {
            new CGSports(),
            new CGMedia(),
            new CGMath()
        };
        var rand = new Random();
        int correct = 0, wrong = 0;
        string Input = " ";
        SetMode:
            bool practice = false;
            Console.WriteLine("Do you want hints on? Y/N");
            Input = Console.ReadLine();
            if (Input.ToUpper() == "Y"){
                practice = true;
            } else if (Input.ToUpper() != "N"){
                Console.WriteLine("Not an accepted input.\nEnter Y or N");
                goto SetMode;
            }
        // Question
        Run:
            ConceptGroup concept = concepts[rand.Next(0, concepts.Length)];
            
            QuestionGroup group = concept.groups[rand.Next(0, concept.groups.Length)];
            group.Print();
            for (int i = 0; i < group.Length(); i++){
                string Answer = group.questions[rand.Next(0, group.questions.Length)].Print(practice);
            	Input = Console.ReadLine();
            	if (Input.ToUpper() == "SKIP"){
            	    goto Run;
            	}
            	if (Input.ToUpper() == Answer.ToUpper()){
                    correct++;
            	    Console.WriteLine($"Correct; \n\tScore:{correct}|{wrong}");
            	}else{
                    wrong++;
            	    Console.WriteLine($"Wrg; Correct: {Answer} \n\tScore:{correct}|{wrong}");
            	}
            }
    	goto Run;
    }
}