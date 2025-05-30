public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public Video(string title, string author, int length, List<Comment> comments)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = comments;
    }

    public int GetTotalComments()
    {
        return _comments.Count;
    }

    public void AddComment(string username, string text)
    {
        _comments.Add(new Comment(username, text));
    }

    public string Display()
    {
        string displayText = $"{_title} - {_author} ({_length} secs)";
        foreach (Comment comment in _comments)
        {
            displayText += $"\n{comment.Display()}";
        }

        return displayText;
    }
}