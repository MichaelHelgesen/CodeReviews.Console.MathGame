namespace mathGame.MichaelHelgesen.Models;

internal class MathProblem
{
    public int Number1 { get; }
    public int Number2 { get; }
    public string Operator { get; }

    // Konstruktør som setter tallene når oppgaven lages
    public MathProblem(int number1, int number2, string op)
    {
        Number1 = number1;
        Number2 = number2;
        Operator = op;
    }

    public int CorrectAnswer => Operator switch
    {
        "+" => Number1 + Number2,
        "-" => Number1 - Number2,
        "*" => Number1 * Number2,
        "/" => Number1 / Number2,
        _ => 0
    };

    public string MathProblemAsString => $"{Number1} {Operator} {Number2}";

}