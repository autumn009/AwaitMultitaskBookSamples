_ = Task.Run(async () =>
{
    Console.WriteLine($"Sub Thread ID={Thread.CurrentThread.ManagedThreadId}");
    foreach (var item in Enumerable.Range('0', 10))
    {
        Console.Write((char)item);
        await Task.Delay(300);
    }
});

Console.WriteLine($"Main Thread ID={Thread.CurrentThread.ManagedThreadId}");
foreach (var item in Enumerable.Range('A', 26))
{
    Console.Write((char)item);
    await Task.Delay(100);
}
