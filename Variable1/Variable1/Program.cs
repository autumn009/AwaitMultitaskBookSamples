Console.WriteLine("start");
var task = sub();
Console.WriteLine("waiting");
await task;
Console.WriteLine("done");

async Task sub()
{
    for (char i = '0'; i <= '9'; i++)
    {
        Console.Write(i);
        await Task.Delay(100);
    }
    Console.WriteLine();
}