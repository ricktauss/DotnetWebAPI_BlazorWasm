using System.Diagnostics;
using System;

namespace TemplatesAndCodeSnippets
{
    public class StopwatchTemplate
    {
        private static void anyMethod()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
                //code or function to measure
            stopwatch.Stop();
            long time = stopwatch.ElapsedMilliseconds;


            stopwatch.Restart();
                //code or function to measure
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
        }

        private static void anyMethod2()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
                //code or function to measure
            stopwatch.Stop();
            long time = stopwatch.ElapsedMilliseconds;
        }

        //.NET docu
        // https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-6.0

    }
}