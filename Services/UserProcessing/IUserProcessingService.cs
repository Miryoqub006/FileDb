
namespace FileDb.AppComplete.Services.UserProcessing
{
    internal interface IUserProcessingService
    {
        void CreateNewUser(string name);
        void DisplayUsers();
        void UpdateUser(int id, string name);
        void DeleteUser(int id);
    }
}