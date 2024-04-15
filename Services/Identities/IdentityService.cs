
using FileDb.AppComplete.Brokers.Storages;
using FileDb.AppComplete.Modals.Users;

namespace FileDb.AppComplete.Services.Identities
{
    internal sealed class IdentityService : IIdentityService
    {
        private static IdentityService instance;
        private readonly IStoragesBroker storagesBroker;

        private IdentityService(IStoragesBroker storagesBroker)
        {
            this.storagesBroker = storagesBroker;
        }

        public static IdentityService GetIdentityService(IStoragesBroker storagesBroker)
        {
            if (instance == null)
            {
                instance = new IdentityService(storagesBroker);
            }
            return instance;
        }

        public int GetNewId()
        {
            List<User> users = this.storagesBroker.ReadAllUsers();

            return users.Count is not 0
                ? IncrementListUsersId(users)
                : 1;
        }

        private static int IncrementListUsersId(List<User> users)
        {
            return users[users.Count - 1].Id + 1;
        }
    }
}
