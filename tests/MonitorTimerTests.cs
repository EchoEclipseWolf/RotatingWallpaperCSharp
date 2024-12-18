using NUnit.Framework;
using System;
using System.Threading;

// PackageReference: NUnit

[TestFixture]
public class MonitorTimerTests
{
    [Test]
    public void TestStart()
    {
        
        ManualResetEventSlim signal = new ManualResetEventSlim(false);
        int callbackCount = 0;

        MonitorTimer timer = new MonitorTimer();
        timer.ChangeTime = TimeSpan.FromSeconds(2);
        timer.RandomizeMin = TimeSpan.FromSeconds(1);
        timer.RandomizeMax = TimeSpan.FromSeconds(2);

        timer.Start(() =>
        {
            callbackCount++;
            signal.Set();
        });

        Assert.IsTrue(signal.Wait(TimeSpan.FromSeconds(5))); // Wait for up to 5 seconds
        Assert.AreEqual(1, callbackCount);

        timer.Stop();

    }
}
