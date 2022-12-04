await Task.Run(async () => {
    for (int i = 0; i < 10; i++)
    {
        Console.Write($"{i} ");
        await Task.Delay(100);
    }
});
Console.WriteLine("Done");
