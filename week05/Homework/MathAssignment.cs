public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment() : base()
    {
        _textbookSection = "N/a";
        _problems = "None";
    }

    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"{GetSummary()}\n" +
               $"Section {_textbookSection} Problems {_problems}";
    }
}