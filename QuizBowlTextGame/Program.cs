// Game for Quiz Bowl Practice
using System.Text.Json;
using System.Collections;


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
            "DIFF\tChange difficulty.",
            "DATA\tSee your user data for this run."};
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
        Console.Title = "____Quiz Bowler____";
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.Cyan;
        // Interface vars
        ConceptGroup[] concepts = new ConceptGroup[] {
            AddConcept("CGMath.json"),
            AddConcept("CGSports.json"),
            AddConcept("CGMedia.json"),
            AddConcept("CGScience.json"),
            AddConcept("CGArt.json"),
            AddConcept("CGHistory.json"),
            AddConcept("CGPractice.json")
        };
        
        List<IVec3> questionsAnswered = new(); 
        List<int> finishedConcepts = new();
        IVec3 questionC;
        bool run = true;
        var rand = new Random();
        int correct = 0, wrong = 0, lengthRun = 1, streak = 0, highStreak = 0;
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
            questionC.x = rand.Next(0, concepts.Length);
            /*if (finishedConcepts.Contains(questionC.x)) {
                goto Run;
            }*/
            ConceptGroup concept = concepts[questionC.x];
            //int attemptCatagory = 0;
        SetCatagory:
            questionC.y = rand.Next(0, concept.catagories.Length);
            /*for (int i = 0; i < concept.catagories.Length; i++){
                if (i == questionC.y) {
                    goto SetCatagory;
                    attemptCatagory++;
                }
            }*/
            QuestionCatagory catagory = concept.catagories[questionC.y];
            //if (attemptCatagory == concept.catagories.Length) { goto Run; finishedConcepts.Add(questionC.x); }

            lengthRun = catagory.length;
        AskQuestion:
            catagory.Print();
            for (int i = 0; i < lengthRun; i++){
                int attemptQuestion = 0;
                questionC.z = rand.Next(0, catagory.questions.Length);
                for (int j = 0; j < catagory.questions.Length; j++){
                    if (j == questionC.z) {
                        questionC.z = questionC.z++ % catagory.questions.Length;
                        j = 0;
                        attemptQuestion++;
                        if (attemptQuestion > catagory.questions.Length) { j = catagory.questions.Length; }
                    }
                }
                string Answer = catagory.questions[questionC.z].Print(practice);
            	Input = Console.ReadLine();
                // Check commands
                switch (Input.ToUpper()){
                    case "SKIP": // Skip the current category
                        streak = 0;
                        goto Run;
                    case "EXIT": // Exit the program
                        goto Exit;
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
                    case "DATA": // Set the length
                        Console.WriteLine($"Correct: {correct}\nWrong: {wrong}\nCurrent Streak: {streak}\nHighest Streak: {highStreak}");
                        break;
                    default: // Handles answering the question
                        questionsAnswered.Add(new IVec3(questionC.x, questionC.y, questionC.z));
                        if (Input.ToUpper() == Answer.ToUpper()){
                            correct++;
                            streak++;
                            if (streak > highStreak) { highStreak = streak; }
                            Console.WriteLine($"Correct. \n\tCorrect:{correct}|Wrong:{wrong}");
                        }else{
                            wrong++;
                            streak = 0;
                            Console.WriteLine($"Wrong. The correct answer is {Answer} \n\tCorrect:{correct}|Wrong:{wrong}");
                        }
                        break;
                }
            }
        if (run){
    	    goto Run;
        }
        Exit:
            Console.WriteLine("Exited Successfully.");
    }
}