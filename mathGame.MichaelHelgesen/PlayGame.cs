public static class PlayGame
{
    public static Game StartGame(int selectedGame, string playerName, int gameNumber)
    {
        int gameRounds = 1;
        int gameScore = 0;

        var (operand, gameType) = selectedGame switch
        {
            1 => ("+", "addition"),
            2 => ("*", "multiplication"),
            3 => ("/", "division"),
            _ => ("-", "subtraction"),
        };

        Game game = new Game
        {
            GameNumber = gameNumber,
            GameType = gameType
        };

        Console.Clear();
        Console.WriteLine($"You chose {gameType}!\n\nTry to solve five math problems in a row\n\nPress enter when ready {playerName}!");

        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
        {
            // Ignorerer alle andre taster lydløst
        }
        
        // -- Egen metode gather valid answer --
        do
        {
            int a = Random.Shared.Next(1, 11);
            int b = Random.Shared.Next(0, 11);
            int c = a * b;
            bool validAnswer = false;
            int answer = 0;
            int correctAnswer;

            Console.Clear();
            if (selectedGame == 3)
                Console.WriteLine($"Question {gameRounds}/5: What is {c} {operand} {a}?");

            else
                Console.WriteLine($"Question {gameRounds}/5: What is {a} {operand} {b}?");

            do
            {
                try
                {
                    answer = int.Parse(Console.ReadLine());
                    validAnswer = true;

                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Only use numbers. Please try again!");
                }
            }
            while (!validAnswer);

            // -- Egen metode create math problem //
            if (selectedGame == 1)
                correctAnswer = a + b;

            else if (selectedGame == 2)
                correctAnswer = a * b;

            else if (selectedGame == 3)
                correctAnswer = c / a;

            else correctAnswer = a - b;

            MathQuestion newTask = new MathQuestion
            {
                QuestionText = $"{a} {operand} {b}",
                CorrectAnswer = correctAnswer,
                PlayerAnswer = answer
            };

            if (newTask.IsCorrect)
            {
                gameScore++;
            }

            game.Questions.Add(newTask);
            gameRounds++;
        }
        while (gameRounds < 6);

        Console.Clear();
        Console.WriteLine($"Game over for game number {gameNumber}. You scored {gameScore} points.\nHere are the results:\n");
        game.GameScore = gameScore;

        // -- Egen metode display result --
        foreach (var q in game.Questions)
        {
            Console.WriteLine($"{q.QuestionText} = {q.CorrectAnswer}\tYour answer: {q.PlayerAnswer}");
        }

        // -- Egen metode play again--
        Console.WriteLine("\nDo you want to play again? (Y/N): ");

        ConsoleKeyInfo tastInput;
        do
        {
            // tar imot tastetrykk uten at brukeren må trykke Enter
            tastInput = Console.ReadKey(intercept: true);
        } while (tastInput.Key != ConsoleKey.Y && tastInput.Key != ConsoleKey.N);

        if (tastInput.Key == ConsoleKey.N)
        {
            Console.WriteLine("Bye");
            Environment.Exit(0);
        }

        return game;
    }
}