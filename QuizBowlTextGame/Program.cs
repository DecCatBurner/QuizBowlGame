// Game for Quiz Bowl Practice
using System.Text.Json;


// Game
public class QuizBowlGame
{
    public static ConceptGroup AddConcept(string fileName){
        return JsonSerializer.Deserialize<ConceptGroup>(File.ReadAllText(Path.Combine("C:/GitHub/QuizBowlGame/QuizBowlTextGame/ClassJson", fileName)));
    }
    public static void Help(){
        string[] cmds = {"____COMMANDS____", 
            "SKIP\tSkip to a different subject and question.", 
            "EXIT\tExit the program.",
            "LIST\tList all questions.",
            "LENGTH\tSet how many questions of a certain catagory to run.",
            "GOTO\tGo to a certian question.",
            "DIFF\tChange difficulty."};
        foreach (string s in cmds) {
            Console.WriteLine(s);
        }
    }
    public static void ListQuestions(ConceptGroup[] concepts){
        for (int i = 0; i < concepts.Length; i++){
            Console.Write($"{i}.\t");
            concepts[i].WriteData();
        }
    }
    public static void GetIDs(out int conceptID, out int catagoryID){
        conceptID = catagoryID = 0; // Just eliminates errors
        // Prepares vars for use
        bool idset = false;
        string input;
        int inputInt;
        while (!idset){ // Gets the concept catagory ID
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
        while (!idset){ // Gets the question catagory ID
            Console.WriteLine("\nEnter the numeric id of the question catagorying.");
            input = Console.ReadLine();
            if (int.TryParse(input, out inputInt)){
                idset = true;
                catagoryID = inputInt;
            } else {
                Console.WriteLine("Please enter an integer.");
            }
        }
    }
    public static void GetLength(out int l) {
        bool idset = false;
        l = 0;
        while (!idset){
            Console.WriteLine("\nEnter how long you want to stay in the catagory.");
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
            AddConcept("CGMath.json"),
            AddConcept("CGSports.json"),
            AddConcept("CGMedia.json")
        };
        
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
            
            QuestionCatagory catagory = concept.catagories[rand.Next(0, concept.catagories.Length)];

            lengthRun = catagory.length;
        AskQuestion:
            catagory.Print();
            for (int i = 0; i < lengthRun; i++){
                string Answer = catagory.questions[rand.Next(0, catagory.questions.Length)].Print(practice);
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
                        int conceptID, catagoryID;
                        GetIDs(out conceptID, out catagoryID);
                        // Check if valid id then set.
                        if (conceptID < concepts.Length && conceptID >= 0){
                            concept = concepts[conceptID];
                        } else {
                            Console.WriteLine("Not a listed concept group.");
                            goto AskQuestion;
                        }
                        if (catagoryID < concept.catagories.Length && catagoryID >= 0){
                            catagory = concept.catagories[catagoryID];
                        } else {
                            Console.WriteLine("Not a listed question catagory.");
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