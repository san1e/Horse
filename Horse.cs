using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using System;

public class Horse
{
    public string Name { get; private set; }
    public Brush Color { get; private set; }
    public double Accelaration { get; private set; }
    public double Position { get; private set; }

    public Stopwatch Timer;

    public Horse(string name, Brush color)
    {
        Name = name;
        Color = color;
        Position = 0;

        Accelaration = new Random().Next(5, 11);

        Timer = new Stopwatch();
        Timer.Start();
    }
    public void ChangeAccelaration()
    {
        Position += 20;
    }
    public async Task RunAsync()
    {
        while (true)
        {
            if (Position >= 720)
            {
                Timer.Stop();
                break;
            }

            ChangeAccelaration();

            await Task.Delay(new Random().Next(0, 500));
        }
    }

    public static Horse[] ChangePlace(Horse[] horses)
    {
        horses = horses.OrderByDescending(x => x.Position).ToArray();

        return horses;
    }

    public static Horse[] ChangePositionRaiting(Horse[] horses)
    {
        horses = horses.OrderBy(x => x.Timer.ElapsedMilliseconds).ToArray();

        return horses;
    }
}