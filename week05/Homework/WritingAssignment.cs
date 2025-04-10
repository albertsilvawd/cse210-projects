public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor that accepts student name, topic, and title of the writing assignment
    public WritingAssignment(string studentName, string topic, string title) 
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method to get the writing information, which includes the title and the student's name
    public string GetWritingInformation()
    {
        return _title + " by " + GetStudentName();
    }

    // Using the GetSummary() method from the base class (Assignment) to access the student's name
    public string GetStudentName()
    {
        return base.GetSummary().Split('-')[0].Trim();
    }
}
