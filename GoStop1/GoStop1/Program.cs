var source = new System.Threading.CancellationTokenSource();

Console.WriteLine("Type Enter to Exit");
subA(source);
subB(source);
await Console.In.ReadLineAsync();

async void subA(CancellationTokenSource source)
{
    Console.WriteLine("[SubA ready]");
    Console.WriteLine("[Waiting permission]");
    try
    {
        // キャンセルトークンがキャンセルされるまで
        // 待つ待つ待つひたすら永遠に待つ
        await Task.Delay(-1, source.Token);
    }
    catch (System.Threading.Tasks.TaskCanceledException)
    {
        // キャンセルトークンがキャンセルされた。
        // それに対応して実行することは特にない。
    }
    Console.WriteLine("[Let' GO!]");
    for (int i = 5; i < 9; i++) Console.Write(i);
}

async void subB(CancellationTokenSource source)
{
    Console.WriteLine("[SubB ready]");
    for (int i = 0; i < 4; i++)
    {
        Console.Write(i);
        await Task.Delay(100);
    }
    Console.WriteLine("[Permit to run subA]");
    // キャンセルトークンをキャンセルする
    source.Cancel();
}
