using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands;

public class SearchCommand : ICommand
{
    public WeatherVM VM { get; private set; }

    public SearchCommand(WeatherVM vm)
    {
        VM = vm;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public async void Execute(object? parameter)
    {
        await VM.MakeQuery();
    }
}
