using FileDb.AppComplete.Modals.Users;
using FileDb.AppComplete.Services.Identities;
using FileDb.AppComplete.Services.UserServices;

namespace FileDb.AppComplete.Services.UserProcessing
{
    internal class UserProcessingService : IUserProcessingService
    {
        private readonly IUserService userService;
        private readonly IIdentityService identityService;
        private IUserService? userService1;

        public UserProcessingService(IUserService userService, IIdentityService identityService)
        {
            this.userService = userService;
            this.identityService = identityService;
        }

        public void CreateNewUser(string name)
        {
            User user = new User();
            user.Id = this.identityService.GetNewId();
            user.Name = name;
            this.userService.AddUser(user);
        }

        public void DisplayUsers()
        {
            this.userService.ShowUsers();
        }

        public void UpdateUser(int id, string name)
        {
            User user = new User()
            {
                Id = id,
                Name = name
            };
            this.userService.Update(user);
        }

        public void DeleteUser(int id)
        {
            this.userService.Delete(id);
        }
    }
}