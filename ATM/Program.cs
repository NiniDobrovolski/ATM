using ATM;

// Setting up directory path for bank account files
string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\BankAccounts";
DirectoryInfo di = new DirectoryInfo(directoryPath);

// Creating the directory if it doesn't exist
if (!di.Exists)
{
    di.Create();
}

string username, password;
bool NoAccount = false;


try
{
    // Getting username and password from the user
    User user = new User();
    Console.WriteLine("Enter Username");
    username = Console.ReadLine();
    Console.WriteLine("Enter Password");
    password = Console.ReadLine();

    // Validating username and password
    if (username == password)
    {
        throw new UsernameException();
    }
    else if (password.Length < 8)
    {
        throw new PasswordException();
    }

    // Creating user object and setting username and password
    user.Username = username;
    user.Password = password;

    // Constructing file path for the user's bank account file
    string accountFilePath = directoryPath + @$"\{username}_BankAccount.txt";
    FileInfo fi = new FileInfo(accountFilePath);
    BankAccount account = null;

    // Checking if account file exists
    if (fi.Exists)
    {
        // Loading account data if file exists
        string[] lines = File.ReadAllLines(accountFilePath);
        if (username == lines[0] && password == lines[1])
        {
            account = BankAccount.LoadAccountData(accountFilePath);
        }
        else
        {
            throw new WrongUsernameOrPasswordException();
        }
    }
    else
    {
        // Prompting user to create a new account if file doesn't exist
        Console.WriteLine("If you want to create a new account, enter 1");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 1)
        {
            account = new BankAccount(username, password, 0);
            account.CreateAccountData();
        }
        else
        {
            NoAccount = true;
        }
    }
    try
    {
        // Providing banking services
        int answer = 1;
        while (answer == 1)
        {
            if (NoAccount == true)
            {
                break;
            }
            else
            {
                Console.WriteLine("Enter the number corresponding to your need");
                Console.WriteLine("Transfer money - 1");
                Console.WriteLine("Deposit money - 2");
                Console.WriteLine("Withdraw money - 3");
                Console.WriteLine("Check your balance - 4");
                Console.WriteLine("Exit - 5");
                int ans = int.Parse(Console.ReadLine());
                if (ans == 1)
                {
                    Console.WriteLine("Enter amount of money you want to tanfer");
                    int amount = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter ID of person you want transfer money to");
                    string ID = Console.ReadLine();
                    if (ID.Length != 11)
                    {
                        throw new IdException();
                    }
                    else if (account.Money - amount < 0)
                    {
                        throw new NotEnoughMoneyException();
                    }
                    else
                    {
                        account.Transaction(ID, amount);
                        Console.WriteLine($"{amount} GEL is successfully transferred");
                        Console.WriteLine($"Current balance: {account.Money} Gel");
                    }
                }
                else if (ans == 2)
                {
                    Console.WriteLine("Enter amount of money you want to deposit");
                    int amount = int.Parse(Console.ReadLine());
                    account.depositMoney(amount);
                    Console.WriteLine($"Current Balance: {account.Money}");

                }
                else if (ans == 3)
                {
                    Console.WriteLine("Enter amount of money you want to withdraw");
                    int amount = int.Parse(Console.ReadLine());
                    if (account.Money - amount < 0)
                    {
                        throw new NotEnoughMoneyException();
                    }
                    else
                    {
                        account.withdrawMoney(amount);
                        Console.WriteLine($"You can take your {amount} Gel");
                        Console.WriteLine($"Current balance: {account.Money} Gel");
                    }
                }
                else if (ans == 4)
                {
                    Console.WriteLine($"Current balance: {account.balance()} Gel");
                }
                else if (ans == 5)
                {
                    Console.WriteLine("Thank you for choosing our service :)");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input. Try again");
                }
                Console.WriteLine("If  you need more services choose 1, otherwise enter any character");
                answer = int.Parse(Console.ReadLine());
            }
        }

    }
    catch (BankruptException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (NotEnoughMoneyException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (IdException ex)
    {
        Console.WriteLine(ex.Message);
    }
}
catch (WrongUsernameOrPasswordException ex)
{
    Console.WriteLine(ex.Message);
}
catch (UsernameException ex)
{
    Console.WriteLine(ex.Message);
}
catch (PasswordException ex)
{
    Console.WriteLine(ex.Message);
}