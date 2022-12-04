subSync();
await subAsync();

async Task subAsync()
{
    await Console.Out.WriteLineAsync("Hello Await");
}

void subSync()
{
    Console.Out.WriteLineAsync("Hello Wait").Wait();
}
