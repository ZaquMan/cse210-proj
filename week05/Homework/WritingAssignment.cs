public class WritingAssignment : Assignment
{
    string _title;

    public WritingAssignment() : base()
    {
        _title = "Nothing";
    }

    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return $"{GetSummary()}\n" +
               $"{_title} by {GetStudentName()}";
    }
}