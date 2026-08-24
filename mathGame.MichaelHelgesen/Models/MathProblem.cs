using mathGame.MichaelHelgesen.Enums;

namespace mathGame.MichaelHelgesen.Models;

class MathProblem
{
    internal int FirstNumber { get; set; }
    internal int SecondNumber { get; set; }
    internal string Operator { get; }
    internal int CorrectAnswer { get; set; }

    internal MathProblem(GameType gameType)
    {

        if (gameType == GameType.Random) gameType = GenerateRandomOperator();

        GenerateNumbers();

        switch (gameType)
        {
            case GameType.Addition:

                Operator = "+";
                CorrectAnswer = FirstNumber + SecondNumber;
                break;
            case GameType.Subtraction:
                Operator = "-";
                CorrectAnswer = FirstNumber - SecondNumber;
                break;
            case GameType.Multiplication:
                Operator = "*";
                CorrectAnswer = FirstNumber * SecondNumber;
                break;
            default:
                FirstNumber *= SecondNumber;
                Operator = "/";
                CorrectAnswer = FirstNumber / SecondNumber;
                break;
        }
    }

    void GenerateNumbers()
    {

        var maxNumber = Game.DifficultySetting switch
        {
            Difficulty.Hard => 1000,
            Difficulty.Easy => 10,
            _ => 100,
        };

        FirstNumber = Random.Shared.Next(0, maxNumber);
        SecondNumber = Random.Shared.Next(1, maxNumber);
    }

    GameType GenerateRandomOperator()
    {

        var values = Enum.GetValues<GameType>()
                            .Where(m => m != GameType.Random)
                            .ToArray();
        return values[Random.Shared.Next(values.Length)];
    }

    internal string AsString => $"{FirstNumber} {Operator} {SecondNumber}";
}