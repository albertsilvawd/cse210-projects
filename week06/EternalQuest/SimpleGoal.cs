namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isCompleted;
        private int totalPoints;

        // Constructor accepts totalPoints as reference (ref)
        public SimpleGoal(string name, int points, ref int totalPoints) : base(name, points)
        {
            _isCompleted = false;
        }

        // Method to record the event of goal completion
        public override void RecordEvent()
        {
            if (!_isCompleted)
            {
                _isCompleted = true;
                totalPoints += _points;  // Update totalPoints when the goal is completed
                Console.WriteLine($"Goal '{_name}' completed! You earned {_points} points.");
            }
        }

        // Method to display the goal
        public override void DisplayGoal()
        {
            string status = _isCompleted ? "[X]" : "[ ]";
            Console.WriteLine($"{status} {_name}");
        }
    }
}
