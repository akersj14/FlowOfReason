using System.Reactive;
using FlowOfReason.Core.DataModels;
using FlowOfReason.UI.Services;
using ReactiveUI;

namespace FlowOfReason.UI.ViewModels;

public class UserAccountPageViewModel : ViewModelBase
{
    private string _backingUserGreeting = string.Empty;
    private string _backingPresentedName = string.Empty;
    private string _backingAccountEmail = string.Empty;
    private string _backingAccountPassword = string.Empty;
    private User _backingUser;
    
    public UserAccountPageViewModel(IUserAccountService userAccountService)
    {
        BackingUserAccountService = userAccountService;
        _backingUser = BackingUserAccountService.GetCurrentUser();
        UserGreeting = _backingUser.Name;
        PresentedName = _backingUser.Name;
        AccountEmail = _backingUser.Email;
        AccountName = _backingUser.Name;
        SaveChanges = ReactiveCommand.Create(() =>
        {
            _backingUser.Name = _backingPresentedName;
            _backingUser.Email = _backingAccountEmail;
            _backingUser.Password = _backingAccountPassword;
            BackingUserAccountService.UpdateUser(_backingUser);
        });
    }

    private IUserAccountService BackingUserAccountService { get; set; }

    public string UserGreeting
    {
        get => _backingUserGreeting;
        set => this.RaiseAndSetIfChanged(ref _backingUserGreeting, "Hello " + value); 
    }

    public string PresentedName
    {
        get => _backingPresentedName;
        set => this.RaiseAndSetIfChanged(ref _backingPresentedName, value);
    }

    public string AccountEmail
    {
        get => _backingAccountEmail;
        set => this.RaiseAndSetIfChanged(ref _backingAccountEmail, value);
    }

    public string AccountName
    {
        get => _backingAccountPassword;
        set => this.RaiseAndSetIfChanged(ref _backingAccountPassword, value);
    }
    
    public ReactiveCommand<Unit, Unit> SaveChanges { get; }
}