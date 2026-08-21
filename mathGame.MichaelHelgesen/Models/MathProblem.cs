using mathGame.MichaelHelgesen.Enums;

namespace mathGame.MichaelHelgesen.Models;

class MathProblem
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
    public string Operator { get; }
    public int CorrectAnswer { get; set; }

    public MathProblem(MenuItems gameType)
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

    public void GenerateNumbers()
    {
        FirstNumber = Random.Shared.Next(1, 10);
        SecondNumber = Random.Shared.Next(1, 10);
    }

    public string AsString => $"{FirstNumber} {Operator} {SecondNumber}";
}