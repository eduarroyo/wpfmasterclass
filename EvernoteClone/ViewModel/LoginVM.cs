using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;

namespace EvernoteClone.ViewModel;

public class LoginVM
{

    #region Properties
    private User user { get; set; }
    public User User
    {
        get => user;
        set => user = value;
    }

    public RegisterCommand RegisterCommand { get; set; }
    public LoginCommand LoginCommand { get; set; }
    #endregion

    public LoginVM()
    {
        RegisterCommand = new RegisterCommand(this);
        LoginCommand = new LoginCommand(this);
    }
}
