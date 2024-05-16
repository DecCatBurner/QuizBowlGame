public class LRndNBATeams : QuestionCatagory{
    public LRndNBATeams() : base(){
        theme = "NBA Teams";
        rule = "Finish the name";
        questions = new QnA[] {
            new QnA("Boston",
                "Celtics",
                "Dryads"),
            new QnA("Brooklyn",
                "Nets",
                "Lake Brook"),
            new QnA("New York",
                "Knicks",
                "Nick"),
            new QnA("Philadelphia",
                "76ers",
                "Numbers"),
            new QnA("Toronto",
                "Raptors",
                "Dinos"),
            new QnA("Chicago",
                "Bulls",
                "Cow"),
            new QnA("Cleveland",
                "Cavaliers",
                "Mounted Pike People"),
            new QnA("Detroit",
                "Pistons",
                "Cars"),
            new QnA("Indiana",
                "Pacers",
                "Pesos"),
            new QnA("Milwaukee",
                "Bucks",
                "Money"),
            new QnA("Atlanta",
                "Hawks",
                "Bird"),
            new QnA("Charlotte",
                "Hornets",
                "Insect"),
            new QnA("Miami",
                "Heat",
                "Not \"Mild\"ami"),
            new QnA("Orlando",
                "Magic",
                "In Disney"),
            new QnA("Washington",
                "Wizards",
                "Cool Hat"),
            new QnA("Denver",
                "Nuggets",
                "Dinner"),
            new QnA("Minnesota",
                "Timberwolves",
                "Lumber"),
            new QnA("Oklahoma City",
                "Thunder",
                "If you get this wrong... crackle!"),
            new QnA("Portland",
                "Trail Blazers",
                "Who makes a new port?"),
            new QnA("Utah",
                "Jazz",
                "Do U TAHlike..."),
            new QnA("Golden State",
                "Warriors",
                "Fighting Gold"),
            new QnA("LA",
                "Clippers",
                "L\tA"),
            new QnA("Los Angeles",
                "Lakers",
                "Pretty Pool"),
            new QnA("Phoenix",
                "Suns",
                "Bird of"),
            new QnA("Sacramento",
                "Kings",
                "Bible Book"),
            new QnA("Dallas",
                "Mavericks",
                "Top Gun"),
            new QnA("Houston",
                "Rockets",
                "NASA has a ton"),
            new QnA("Memphis",
                "Grizzes",
                "Men can't bare it"),
            new QnA("New Orleans",
                "Pelicans",
                "See birb"),
            new QnA("San Antonio",
                "Spurs",
                "SANd")
        };
        length = 10;
    }
}

public class CGSports : ConceptGroup{
    public CGSports(){
        concept = "Sports";
        catagories = new QuestionCatagory[] {new LRndNBATeams()};
    }
}