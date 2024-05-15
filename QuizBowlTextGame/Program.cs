// Game for Quiz Bowl Practice
using System.Text.Json;


// Game
public class QuizBowlGame
{
    public static void Help(){
        Console.WriteLine("____COMMANDS____\nSKIP\tSkip to a different subject and question.\nEXIT\tExit the program.\nLIST\tList all questions.\nGOTO\tGo to a certian question.\nDIFF\tChange difficulty.\n");
    }
    public static void ListQuestions(ConceptGroup[] concepts){
        for (int i = 0; i < concepts.Length; i++){
            Console.Write($"{i}.\t");
            concepts[i].WriteData();
        }
    }
    public static void GetIDs(out int conceptID, out int groupID){
        conceptID = groupID = 0; // Just eliminates errors
        // Prepares vars for use
        bool idset = false;
        string input;
        int inputInt;
        while (!idset){ // Gets the concept group ID
            Console.WriteLine("\nEnter the numeric id of the general concept.");
            input = Console.ReadLine();
            if (int.TryParse(input, out inputInt)){
                idset = true;
                conceptID = inputInt;
            } else {
                Console.WriteLine("Please enter an integer.");
            }
        }
        idset = false; // Reuse var
        while (!idset){ // Gets the question group ID
            Console.WriteLine("\nEnter the numeric id of the question grouping.");
            input = Console.ReadLine();
            if (int.TryParse(input, out inputInt)){
                idset = true;
                groupID = inputInt;
            } else {
                Console.WriteLine("Please enter an integer.");
            }
        }
    }
    public static void GetLength(out int l) {
        bool idset = false;
        l = 0;
        while (!idset){
            Console.WriteLine("\nEnter how long you want to stay in the group.");
            string s = Console.ReadLine();
            if (int.TryParse(s, out l)) {
                idset = true;
            }
            else {
                Console.WriteLine("Please enter an integer.");
            }
        }
    }

    public static void Main(string[] args)
    {
        // Interface vars
        ConceptGroup[] concepts = new ConceptGroup[] {
            new CGSports(),
            new CGMedia(),
            new CGMath()
        };
        //File.OpenRead("./QuizBowlTextGame/ClassJson/CGMath.json");
        string json1 = File.ReadAllText("./QuizBowlTextGame/ClassJson/CGMath.json");
        concepts[2] = JsonSerializer.Deserialize<ConceptGroup>(json1);
        
        bool run = true;
        var rand = new Random();
        int correct = 0, wrong = 0, lengthRun = 1;
        string Input = " ";
        // Initial statements
        Console.WriteLine("____Quiz Bowler____\n\u00A9 2024 DecCatBurner\nFor a list of commands type \"help\"");
        SetMode: // Difficulty
            bool practice = false;
            Console.WriteLine("Do you want hints on? Y/N");
            Input = Console.ReadLine();
            if (Input.ToUpper() == "Y"){
                practice = true;
            } else if (Input.ToUpper() != "N"){
                Console.WriteLine("Not an accepted input.\nEnter Y or N");
                goto SetMode;
            }
            Console.WriteLine("\r");
        // Questions
        Run:
            ConceptGroup concept = concepts[rand.Next(0, concepts.Length)];
            
            QuestionGroup group = concept.groups[rand.Next(0, concept.groups.Length)];

            lengthRun = group.length;
        AskQuestion:
            group.Print();
            for (int i = 0; i < lengthRun; i++){
                string Answer = group.questions[rand.Next(0, group.questions.Length)].Print(practice);
            	Input = Console.ReadLine();
                // Check commands
                switch (Input.ToUpper()){
                    case "SKIP": // Skip the current category
                        goto Run;
                    case "EXIT": // Exit the program
                        run = false;
                        break;
                    case "HELP": // List the commands
                        Help();
                        break;
                    case "LIST": // List the questions
                        ListQuestions(concepts);
                        break;
                    case "DIFF": // Set the difficulty
                        goto SetMode;
                    case "LENGTH": // Set the length
                        GetLength(out lengthRun);
                        break;
                    case "GOTO": // Search for a question
                        ListQuestions(concepts);
                        int conceptID, groupID;
                        GetIDs(out conceptID, out groupID);
                        // Check if valid id then set.
                        if (conceptID < concepts.Length && conceptID >= 0){
                            concept = concepts[conceptID];
                        } else {
                            Console.WriteLine("Not a listed concept group.");
                            goto AskQuestion;
                        }
                        if (groupID < concept.groups.Length && groupID >= 0){
                            group = concept.groups[groupID];
                        } else {
                            Console.WriteLine("Not a listed question group.");
                        }
                        goto AskQuestion;
                    default: // Handles answering the question
                        if (Input.ToUpper() == Answer.ToUpper()){
                            correct++;
                            Console.WriteLine($"Correct; \n\tScore:{correct}|{wrong}");
                        }else{
                            wrong++;
                            Console.WriteLine($"Wrg; Correct: {Answer} \n\tScore:{correct}|{wrong}");
                        }
                        break;
                }
            }
        if (run){
    	    goto Run;
        }
    }
}