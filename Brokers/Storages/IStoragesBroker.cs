using FileDb.AppComplete.Modals.Users;

namespace FileDb.AppComplete.Brokers.Storages
{
    internal interface IStoragesBroker
    {
        User AddUser(User user);
        List<User> ReadAllUsers();
        User UpdateUser(User user);
        bool DeleteUser(int id);
    }
}