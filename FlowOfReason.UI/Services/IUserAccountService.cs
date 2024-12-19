using System.Linq;
using FlowOfReason.Core.DataBases;
using FlowOfReason.Core.DataModels;

namespace FlowOfReason.UI.Services;

public interface IUserAccountService
{
    public User GetCurrentUser();
    public void UpdateUser(User user);
}

public class UserAccountService : IUserAccountService
{
    public UserAccountService(IUserDataBase backingUserDataBase)
    {
        BackingUserDataBase = backingUserDataBase;
        var allUsers = BackingUserDataBase.GetAllAsync().Result;
        if (allUsers.Any()) return;
        
        var newUser = new User
        {
            Name = "admin",
            Email = "admin@admin.com",
            Password = "admin"
        };
        BackingUserDataBase.AddAsync(newUser);
    }

    private IUserDataBase BackingUserDataBase { get; }

    public User GetCurrentUser()
    {
        var allUsers = BackingUserDataBase.GetAllAsync().Result;
        return allUsers.ToList()[0];
    }

    public void UpdateUser(User user)
    {
        BackingUserDataBase.UpdateAsync(user);
    }
}

