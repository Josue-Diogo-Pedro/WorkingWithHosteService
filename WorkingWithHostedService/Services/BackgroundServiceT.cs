namespace WorkingWithHostedService.Services;

public abstract class BackgroundServiceT : IHostedService
{
    private Task _executingTask;
    private readonly CancellationTokenSource _stoppingCts = new CancellationTokenSource();

    public virtual Task StartAsync(CancellationToken cancellationToken)
    {
        // Armazena a tarefa que estamos executando
        _executingTask = ExecuteAsync(_stoppingCts.Token);
        // se a tarefa foi concluida então retorna,
        // isto causa o cancelamento e a falha do chamados
        if (_executingTask.IsCompleted)
        {
            return _executingTask;
        }
        // de outra forma ela esta rodando
        Console.WriteLine("Teste");
        return Task.CompletedTask;
    }

    public virtual async Task StopAsync(CancellationToken cancellationToken)
    {
        // Para a chamada sem iniciar
        if (_executingTask == null)
        {
            return;
        }
        try
        {
            // Sinaliza o cancelamento para o método
            _stoppingCts.Cancel();
        }
        finally
        {
            // Aguarde ate que a tarefa termine ou que pare
            await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
        }
    }

    protected virtual async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        do
        {
            await Process();
            //aguarde 5 segundos
            await Task.Delay(5000, stoppingToken);
        }
        while (!stoppingToken.IsCancellationRequested);
    }
    protected abstract Task Process();
}
