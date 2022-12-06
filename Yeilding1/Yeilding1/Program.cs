subB();
await subA();

async Task subA()
{
    await Console.In.ReadLineAsync();
}

async void subB()
{
    await Console.Out.WriteLineAsync("Start subB");
    int x = 0;
    for (int i = 0; i < int.MaxValue; i++)
    {
        x += Random.Shared.Next();
        if (x % 100 == 0) await Task.Yield();
    }
    Console.WriteLine(x);
}
