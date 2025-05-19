

using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;

public class AccountManager : IAccountManager
{
    private readonly AccountContext _context;

    public  static User CurrentUser;    

    public AccountManager(AccountContext context)
    {
        _context = context;
    }

    public void RegisterAccount(User account)
    {
        string[] domens = ["ru", "com"];

        if (account.Name.Contains("@") && account.Name.Contains(".") &&
        account.Name.Length > 5 && account.Name.Length < 50)
        {
            var splited = account.Name.Split(".");
            foreach(var domen in domens)
            {
                if(splited[splited.Length - 1].Contains(domen))
                {
                    account.Email = account.Name;
                    account.Name = account.Name.Split("@")[0];
                    System.Console.WriteLine($"{account.Name}'s Email is valid");
                    break;
                }
                else
                {
                    account.Email = account.Name;
                }
            }
        }


        Console.WriteLine("[Account manager] registring account: " + account.Name);

        if(_context.Users.Any(u => u.Name == account.Name))
        {
            Console.WriteLine("Account with name " + account.Name + " already exists."); 
            return;
        } 
        account.ID = _context.Users.Count() + 1;    
        _context.Users.Add(account); 
        _context.SaveChanges();
    }

    public User GetAccount(string accountName) 
    {
       return _context.Users.FirstOrDefault(u => u.Name == accountName);
    }

    public List<User> GetAccounts()
    {
        return _context.Users.ToList(); 
    }

    public bool VerifyAccount(User account)
    {
        if(_context.Users.Any(u => u.Name == account.Name && u.Password == account.Password))
        {
            CurrentUser = account;
            Console.WriteLine("Account verified."); 
            return true;    
        }
        else 
        {
            Console.WriteLine("Account not verified."); 
            return false; 
        }    
    }
}   