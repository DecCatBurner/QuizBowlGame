public class Books : QuestionGroup{
    public Books() : base(){
        theme = "Books";
        questions = new QnA[] {
            new QnA("This 1859 novel tells the story of a carpenter in love with a single woman who has a child with another man. What is the title of this novel by George Eliot?",
                "Adam Bede",
                "Man Body")
        };
    }
}

public class Authors : QuestionGroup{
    public Authors() : base(){
        theme = "Authors";
        questions = new QnA[] {
            new QnA("This American author was best-known for his highly popular westerns portraying frontier life. Which author's novel Hondo was made into a movie starring John Wayne in 1954?",
                "Louis L'Amour",
                "F' Four")
        };
    }
}

public class Poems : QuestionGroup{
    public Poems() : base(){
        theme = "Poems";
        questions = new QnA[] {
            new QnA("The subject of this 1681 poetic satire by John Dryden was the Exclusion Crisis in England. Which poem takes its title from a story in the Bible about a son of David and the friend who persuaded him to rebel against his father?",
                "Absalom and Achitophel",
                "2 Samuel"),
            new QnA("In one play by Shakespeare, this character meets defeat at the Battle of Actium. Which character also gives a funeral oration that leads a crowd to riot in an earlier play?",
                "Mark Antony",
                "Becomes Augustus")
        };
    }
}

public class CGMedia : ConceptGroup{
    public CGMedia(){
        concept = "Media";
        groups = new QuestionGroup[] {new Books(), new Authors(), new Poems()};
    }
}