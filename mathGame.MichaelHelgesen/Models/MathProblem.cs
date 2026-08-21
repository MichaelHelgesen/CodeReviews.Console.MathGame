using mathGame.MichaelHelgesen.Enums;

namespace mathGame.MichaelHelgesen.Models;

class MathProblem
{
    internal int FirstNumber { get; set; }
    internal int SecondNumber { get; set; }
    internal string Operator { get; }
    internal int CorrectAnswer { get; set; }

    internal MathProblem(MenuItems gameType)
    {
        GenerateNumbers();

        switch (gameType)
        {
            case MenuItems.Addition:
                
                Operator = "+";
                CorrectAnswer = FirstNumber + SecondNumber;
                break;
            case MenuItems.Subtraction:
                Operator = "-";
                CorrectAnswer = FirstNumber - SecondNumber;
                break;
            case MenuItems.Multiplication:
                Operator = "*";
                CorrectAnswer = FirstNumber * SecondNumber;
                break;
            case MenuItems.Division:
                FirstNumber *= SecondNumber;
                Operator = "/";
                CorrectAnswer = FirstNumber / SecondNumber;
                break;
        }
    }

    void GenerateNumbers()
    {
        FirstNumber = Random.Shared.Next(1, 10);
        SecondNumber = Random.Shared.Next(1, 10);
    }

    internal string AsString => $"{FirstNumber} {Operator} {SecondNumber}";
}