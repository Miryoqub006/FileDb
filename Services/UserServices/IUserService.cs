using FileDb.AppComplete.Modals.Users;

namespace FileDb.AppComplete.Services.UserServices
{
    internal interface IUserService
    {
        User AddUser(User user);
        void ShowUsers();
        void Update(User user);
        void Delete(int id);
    }
}