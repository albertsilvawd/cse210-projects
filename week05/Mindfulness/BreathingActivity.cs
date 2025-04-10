public class BreathingActivity : Activity
{
    public override void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(2);  // Mostra o spinner por 2 segundos
            Console.WriteLine("\b \bBreathe out...");
            ShowSpinner(2);  // Mostra o spinner por 2 segundos
        }

        DisplayEndingMessage();
    }

    // Método para mostrar o spinner
    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");  // Exibe um ponto
            Thread.Sleep(1000);  // Pausa por 1 segundo
        }
    }
}
