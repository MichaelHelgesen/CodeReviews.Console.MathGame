using mathGame.MichaelHelgesen.Enums;

namespace mathGame.MichaelHelgesen.Models;

class MathProblem
{
    internal int FirstNumber { get; set; }
    internal int SecondNumber { get; set; }
    internal string Operator { get; }
    internal int CorrectAnswer { get; set; }

    internal MathProblem(Menu gameType)
    {

        if (gameType == Menu.Random) gameType = GenerateRandomOperator();

        GenerateNumbers();

        switch (gameType)
        {
            case Menu.Addition:

                Operator = "+";
                CorrectAnswer = FirstNumber + SecondNumber;
                break;
            case Menu.Subtraction:
                Operator = "-";
                CorrectAnswer = FirstNumber - SecondNumber;
                break;
            case Menu.Multiplication:
                Operator = "*";
                CorrectAnswer = FirstNumber * SecondNumber;
                break;
            case Menu.Division:
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

    Menu GenerateRandomOperator()
    {

        var values = Enum.GetValues<Menu>()
                            .Where(m => m != Menu.Random)
                            .ToArray();

        return values[Random.Shared.Next(values.Length)];
    }

    internal string AsString => $"{FirstNumber} {Operator} {SecondNumber}";
}