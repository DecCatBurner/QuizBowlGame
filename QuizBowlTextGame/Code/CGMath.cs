public class LRndBinaryAddition : LightningRound{
    public LRndBinaryAddition() : base(){
        theme = "Binary Addition";
        rule = "Answer in binary form\nDon't include leading 0s";
        //hint = "1 + 1 = 10, 0 + 0 = 0, 1 + 0 = 1";
        questions = new QnA[] {
            new QnA("1010 + 101",
                "1111",
                "1 + 1 = 10, 0 + 0 = 00, 1 + 0 = 01\nWrite 0100 as 100"),
            new QnA("1111 + 11",
                "10010",
                "1 + 1 = 10, 0 + 0 = 00, 1 + 0 = 01\nWrite 0100 as 100"),
            new QnA("1010 + 11",
                "1101",
                "1 + 1 = 10, 0 + 0 = 00, 1 + 0 = 01\nWrite 0100 as 100"),
            new QnA("1011 + 1101",
                "11000",
                "1 + 1 = 10, 0 + 0 = 00, 1 + 0 = 01\nWrite 0100 as 100"),
            new QnA("111 + 110110",
                "111101",
                "1 + 1 = 10, 0 + 0 = 00, 1 + 0 = 01\nWrite 0100 as 100"),
            new QnA("101110 + 11101",
                "1001011",
                "1 + 1 = 10, 0 + 0 = 00, 1 + 0 = 01\nWrite 0100 as 100"),
            new QnA("11100 + 100100",
                "1000000",
                "1 + 1 = 10, 0 + 0 = 00, 1 + 0 = 01\nWrite 0100 as 100"),
            new QnA("101010 + 110011",
                "1011101",
                "1 + 1 = 10, 0 + 0 = 00, 1 + 0 = 01\nWrite 0100 as 100"),
            new QnA("110011 + 11001",
                "1001100",
                "1 + 1 = 10, 0 + 0 = 00, 1 + 0 = 01\nWrite 0100 as 100"),
            new QnA("101010 + 10011",
                "111101",
                "1 + 1 = 10, 0 + 0 = 00, 1 + 0 = 01\nWrite 0100 as 100"),
            new QnA("11111 + 11",
                "100010",
                "1 + 1 = 10, 0 + 0 = 00, 1 + 0 = 01\nWrite 0100 as 100")
        };
    }
}

public class CGMath : ConceptGroup{
    public CGMath(){
        concept = "Math";
        groups = new QuestionGroup[] {new LRndBinaryAddition()};
    }
}