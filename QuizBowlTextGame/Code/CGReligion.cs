public class Bible : QuestionGroup{
    public Bible() : base(){
        theme = "Bible";
        questions = new QnA[] {
            new QnA("",
                "",
                "")
        };
    }
}

public class CGReligion : ConceptGroup{
    public CGReligion(){
        concept = "Religions";
        groups = new QuestionGroup[] {new Bible()};
    }
}