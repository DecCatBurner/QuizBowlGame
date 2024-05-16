public class Bible : QuestionCatagory{
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
        catagories = new QuestionCatagory[] {new Bible()};
    }
}