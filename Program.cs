using FileDb.AppComplete.Brokers.Storages;
using FileDb.AppComplete.Services.Identities;
using FileDb.AppComplete.Services.UserProcessing;
using FileDb.AppComplete.Services.UserServices;
using FileDB.AppComplete.Brokers.Storages;

internal class Program
{
    private static void Main(string[] args)
    {
        PrintStorage();
        IUserProcessingService userProcessingService = InitializeServices();

        string userChoice;
        do
        {

            PrintMenu();
            Console.Write("Enter your choice: ");
            userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Enter your name: ");
                    string userName = Console.ReadLine();
                    userProcessingService.CreateNewUser(userName);
                    break;

                case "2":
                    {
                        Console.Clear();
                        userProcessingService.DisplayUsers();
                    }
                    break;

                case "3":
                    {
                        Console.Clear();
                        Console.WriteLine("Enter an ID which you want to delete");
                        Console.Write("Enter ID: ");
                        int deleteWithId = Convert.ToInt32(Console.ReadLine());
                        userProcessingService.DeleteUser(deleteWithId);
                    }
                    break;

                case "4":
                    {
                        Console.Clear();
                        Console.WriteLine("Enter an id which you want to edit");
                        Console.Write("Enter an ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine();
                        userProcessingService.UpdateUser(id, newName);
                    }
                    break;

                case "5": 
                    FileInfo fileInfo = new FileInfo("C:../../../UsersJson.json");
                    Console.WriteLine($"byte: {fileInfo.Length}");
                    break; 

                case "6":
                    FileInfo fileInfo1 = new FileInfo("C:../../../Userstxt.txt");
                    Console.WriteLine($"byte: {fileInfo1.Length}");
                    break;

                case "0": break;

                default:
                    Console.WriteLine("You entered wrong input, please try again!");
                    break;
            }
        }
        while (userChoice != "0");
        Console.Clear();
        Console.WriteLine("The app has been finished, thanks bye!");
    }

    private static IUserProcessingService InitializeServices()
    {
        IStoragesBroker storagesBroker = null;
        IUserService userService = null;
        IStoragesBroker jsonStorage = new JsonStorage();
        IStoragesBroker txtStorage = new FileStorageBroker();

        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                userService = new UserService(txtStorage);
                storagesBroker = new FileStorageBroker();
                break;
            case 2:
                userService = new UserService(jsonStorage);
                storagesBroker = new JsonStorage();
                break;
            default:
                Console.WriteLine("Invalid choise! ");
                break;
        }

        IIdentityService identityService = IdentityService.GetIdentityService(storagesBroker);
        IUserProcessingService userProcessingService = new UserProcessingService(userService, identityService);

        return userProcessingService;
    }

    private static void PrintStorage()
    {
        Console.WriteLine("1. text: ");
        Console.WriteLine("2. json: ");
        Console.Write("Enter your file choise: ");
    }

    private static void PrintMenu()
    {
        Console.WriteLine("1.Create User");
        Console.WriteLine("2.Display User");
        Console.WriteLine("3.Delete User by ID");
        Console.WriteLine("4.Update User by ID");
        Console.WriteLine("5.JSON xajmini ko`rish");
        Console.WriteLine("6.txt xajmini ko`rish");
        Console.WriteLine("0.Exit");
    }
}