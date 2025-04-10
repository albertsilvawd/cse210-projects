namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        private int totalPoints;

        // Construtor que recebe totalPoints como referência (ref)
        public EternalGoal(string name, int points, ref int totalPoints) : base(name, points)
        { }

        // Método para registrar a realização da meta eterna
        public override void RecordEvent()
        {
            totalPoints += _points;  // Atualiza o totalPoints toda vez que a meta eterna for registrada
            Console.WriteLine($"Goal '{_name}' recorded. You earned {_points} points.");
        }

        // Método para exibir a meta eterna
        public override void DisplayGoal()
        {
            Console.WriteLine($"[ ] {_name} (Eternal goal, not completed)");
        }
    }
}
