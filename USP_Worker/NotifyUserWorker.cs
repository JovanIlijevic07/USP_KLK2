using Microsoft.Extensions.Hosting;
using MongoDB.Entities;
using USP_Domain.Entities;

namespace USP_Worker;

public class NotifyUserWorker:BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.Now;
            if (now.DayOfWeek is DayOfWeek.Monday or DayOfWeek.Wednesday or DayOfWeek.Friday &&
                now is { Hour: 11, Minute: 0, Second: 0 })
            {
                DoWork();
            }
                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
        }
    }

    private async Task DoWork()
    {
        var result= await DB.Find<User>().ExecuteAsync();

        foreach (var user in result)
        {
            Console.WriteLine(user.Email);
        }
    }
}