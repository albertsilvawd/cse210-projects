namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _timesCompleted;
        private int _targetTimes;
        private int _bonusPoints;
        private int totalPoints;

        // Construtor que recebe totalPoints como referência (ref)
        public ChecklistGoal(string name, int points, int targetTimes, int bonusPoints, ref int totalPoints) : base(name, points)
        {
            _timesCompleted = 0;
            _targetTimes = targetTimes;
            _bonusPoints = bonusPoints;
        }

        // Método para registrar a realização da meta de checklist
        public override void RecordEvent()
        {
            if (_timesCompleted < _targetTimes)
            {
                _timesCompleted++;
                totalPoints += _points;  // Atualiza o totalPoints cada vez que a meta de checklist for registrada
                int totalPointsThisTime = _timesCompleted * _points;
                Console.WriteLine($"Goal '{_name}' recorded. You earned {_points} points. Total: {totalPointsThisTime} points.");
                
                if (_timesCompleted == _targetTimes)
                {
                    totalPoints += _bonusPoints;  // Adiciona pontos extras quando a meta de checklist é completada
                    Console.WriteLine($"Bonus! You've completed the goal {_timesCompleted}/{_targetTimes}. You earned an additional {_bonusPoints} points.");
                }
            }
        }

        // Método para exibir a meta de checklist
        public override void DisplayGoal()
        {
            Console.WriteLine($"[ ] {_name} Completed {_timesCompleted}/{_targetTimes} times.");
        }
    }
}
