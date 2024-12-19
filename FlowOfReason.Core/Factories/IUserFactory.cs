using FlowOfReason.Core.DataModels;

namespace FlowOfReason.Core.Factories;

public interface IUserFactory
{
    public User CreateUser(string name, string password, string email);
}