using mathGame.MichaelHelgesen.Enums;

namespace mathGame.MichaelHelgesen.Models;

internal class MathProblem
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
    public string Operator { get; }
    public int CorrectAnswer { get; set; }

    public MathProblem(MenuItems gameType)
    {
        switch (gameType)
        {
            case MenuItems.Addition:
                GenerateNumbers();
                Operator = "+";
                CorrectAnswer = FirstNumber + SecondNumber;
                break;
            case MenuItems.Subtraction:
                GenerateNumbers();
                Operator = "-";
                CorrectAnswer = FirstNumber - SecondNumber;
                break;
            case MenuItems.Multiplication:
                GenerateNumbers();
                Operator = "*";
                CorrectAnswer = FirstNumber * SecondNumber;
                break;
            case MenuItems.Division:
                GenerateNumbers();
                FirstNumber *= SecondNumber;
                Operator = "/";
                CorrectAnswer = FirstNumber / SecondNumber;
                break;
        }
    }

    public void GenerateNumbers()
    {
        var random = Random.Shared;
        FirstNumber = random.Next(1, 100);
        SecondNumber = random.Next(1, 100);
    }

    public string AsString => $"{FirstNumber} {Operator} {SecondNumber}";
}