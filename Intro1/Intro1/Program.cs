
Console.WriteLine("Type Enter to Exit");
subA();
subB();
await Console.In.ReadLineAsync();

async void subA()
{
    Console.Write("[Starting subA]");
    foreach (var item in Enumerable.Range('A',5))
    {
        Console.Write((char)item);
        await Task.Delay(200);
    }
    Console.Write("[Done subA]");
}

async void subB()
{
    Console.Write("[Starting subB]");
    foreach (var item in Enumerable.Range('a', 5))
    {
        Console.Write((char)item);
        await Task.Delay(300);
    }
    Console.Write("[Done subB]");
}