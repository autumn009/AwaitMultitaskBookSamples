Console.WriteLine("start");
await sub();
Console.WriteLine("done");

Task sub()
{
    Console.WriteLine("in sub");
    return Task.CompletedTask;
}