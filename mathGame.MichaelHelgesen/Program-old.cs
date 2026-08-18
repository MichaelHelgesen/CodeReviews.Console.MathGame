/*
List<Game> FinishedGamesArchive = new List<Game>();
string playerName = "unknown";
int numberOfRounds = 0;
bool displayGameMenu = false;
bool playerIsPlaying = false;
int chosenGame = 0;

Console.WriteLine("-- Welcome to the Math Game! --");
Console.Write("Please enter your name: ");

while (chosenGame != -1)
{
    // Register name
    if (numberOfRounds == 0)
    {
        playerName = Console.ReadLine();
        ++numberOfRounds;
        Console.WriteLine(numberOfRounds);
        displayGameMenu = true;
    }

    // Generate menu
    if (displayGameMenu)
    {
        chosenGame = PlayerMenu.GeneratePlayerMenu(numberOfRounds, playerName);
        displayGameMenu = false;
        playerIsPlaying = true;
        if (chosenGame == -1)
        {
            Console.WriteLine("Bye");
            Environment.Exit(0);
        }
    } 

    // Start game
    if (playerIsPlaying && chosenGame != 5)
    {
        Console.Clear();
        FinishedGamesArchive.Add(PlayGame.StartGame(chosenGame, playerName, numberOfRounds));
        numberOfRounds++;
        playerIsPlaying = false;
        displayGameMenu = true;
    }

    // View results
    if (chosenGame == 5)
    {
        Console.Clear();
        foreach (var g in FinishedGamesArchive)
        {
            Console.WriteLine($"Game number {g.GameNumber}");
            Console.WriteLine($"Question\tCorrect answer\tPlayer answer\tResult");
            //int score;
            foreach (var question in g.Questions)
            {
                Console.WriteLine($"{question.QuestionText}\t\t{question.CorrectAnswer}\t\t{question.PlayerAnswer}\t\t{question.IsCorrect}");

            }
            Console.WriteLine($"\nScore: {g.GameScore} \n");
        }

        Console.WriteLine("\nPress enter to return to menu");
        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
        {
            // Ignorerer alle andre taster lydløst
        }
        displayGameMenu = true;
        chosenGame = 0;
    } 

}

Console.WriteLine("Bye");


*/