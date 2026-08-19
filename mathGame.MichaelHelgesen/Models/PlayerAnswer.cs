namespace mathGame.MichaelHelgesen.Models;

internal class PlayerAnswer
{
    public string MathProblem { get; set; }
    public int CorrectAnswer { get; set; }
    public int Answer { get; set; }

    public PlayerAnswer(string mathProblem, int correctAnswer, int answer)
    {
        MathProblem = mathProblem;
        CorrectAnswer = correctAnswer;
        Answer = answer;
    }
    public bool IsCorrect => Answer == CorrectAnswer;
}