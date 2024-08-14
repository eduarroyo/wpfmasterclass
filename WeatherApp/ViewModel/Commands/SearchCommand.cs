using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands;

public class SearchCommand : ICommand
{
    public WeatherVM VM { get; private set; }

    public SearchCommand(WeatherVM vm)
    {
        VM = vm;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter)
    {
        string? query = (string?) parameter;
        return !string.IsNullOrWhiteSpace(query); ;
    }

    public async void Execute(object? parameter)
    {
        await VM.MakeQuery();
    }
}
