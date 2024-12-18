using System;
using System.Threading;

public class MonitorTimer
{
    public DateTime LastChanged { get; set; 
    public void Start(Action ReachedTime)
    {
        TimeSpan randomDelay = TimeSpan.FromSeconds(new Random().Next((int)RandomizeMin.TotalSeconds, (int)RandomizeMax.TotalSeconds));
        TimeSpan totalDelay = ChangeTime + randomDelay;

        _timerThread = new Thread(() =>
        {
            while (true)
            {
                if (DateTime.Now >= LastChanged + totalDelay)
                {
                    ReachedTime();
                    LastChanged = DateTime.Now;
                }
                Thread.Sleep(1000);
            }
        });

        _timerThread.Start();
    }

    public void Stop()
    {
        _timerThread?.Abort();
    }
}

    public TimeSpan ChangeTime { get; set; }
    public TimeSpan RandomizeMin { get; set; }
    public TimeSpan RandomizeMax { get; set; }
    private Thread _timerThread;

    public MonitorTimer()
    {
        LastChanged = DateTime.Now;
        ChangeTime = TimeSpan.Zero;
        RandomizeMin = TimeSpan.Zero;

        RandomizeMax = TimeSpan.Zero;
    }

    public void Start(Action ReachedTime)
    {
        TimeSpan randomDelay = TimeSpan.FromSeconds(new Random().Next((int)RandomizeMin.TotalSeconds, (int)RandomizeMax.TotalSeconds));
        TimeSpan totalDelay = ChangeTime + randomDelay;

        _timerThread = new Thread(() =>
        {
            while (true)
            {
                if (DateTime.Now >= LastChanged + totalDelay)
                {
                    ReachedTime();
                    LastChanged = DateTime.Now;
                }
                Thread.Sleep(1000);
            }
        });

        _timerThread.Start();
    }

    public void Stop()
    {
        _timerThread?.Abort();
    }
}
