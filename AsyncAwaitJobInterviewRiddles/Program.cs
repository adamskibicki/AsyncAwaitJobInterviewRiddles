using System.Diagnostics;

async Task<int> Riddle0()
{
    var task0 = Operation();
    var task1 = Operation();

    return await task0 + await task1;
}

Task<int> Riddle1()
{
    var task0 = Task.Run(Operation);
    var task1 = Task.Run(Operation);

    return Task.FromResult(task0.Result + task1.Result);
}

async Task<int> Riddle2()
{
    var finishedTasks = await Task.WhenAll(Operation(), Operation());

    return finishedTasks.Sum();
}

async Task<int> Operation()
{
    await Task.Delay(200);

    return 1;
}

async Task MeasureTime(Func<Task<int>> action)
{
    Stopwatch stopwatch = new();
    
    stopwatch.Start();
    await action();
    stopwatch.Stop();

    Console.WriteLine($"Elapsed miliseconds: {stopwatch.ElapsedMilliseconds}");
}

await MeasureTime(Riddle0);
await MeasureTime(Riddle1);
await MeasureTime(Riddle2);

Console.ReadLine();