public struct MathQuestion
{
    public string QuestionText { get; set; }
    public int CorrectAnswer { get; set; }
    public int PlayerAnswer { get; set; } 
    
    public bool IsCorrect => PlayerAnswer == CorrectAnswer;
}