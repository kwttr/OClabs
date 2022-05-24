using System;
using System.Threading;
class program
{
    static void Main(string[] args)
    {
        var c = 0;
        var thread = new Thread(() =>
        {
            c = Count();
        });
        thread.Start();
        thread.Join();
        Console.WriteLine(c.ToString());
        Console.ReadLine();
    }

    public int Count()
    {
        int A = 1;
        int B = 2;
        return A + B;
    }
}