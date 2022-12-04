var thread = new Thread(() => {
    for (int i = 0; i < 10; i++)
    {
        Console.Write($"{i} ");
        Thread.Sleep(100);
    }
});
thread.Start();
thread.Join();
Console.WriteLine("Done");
