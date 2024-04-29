using System;
using System.IO;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.ForegroundColor = ConsoleColor.White;
        PasswordManager passMan = new PasswordManager();
        //PasswordGenerator passGen = new PasswordGenerator();  


        Console.WriteLine("\n(1) Password Manager");
        Console.WriteLine("(2) Password Generator");
        Console.WriteLine("(3) Exit Program");

        Console.Write("Enter program number: ");
        int userInput = int.Parse(Console.ReadLine());

        while (userInput != 1 && userInput != 2 && userInput != 3)
        {
            Console.WriteLine("\nInvalid input. Try again");
            Console.WriteLine("(1) Password Manager");
            Console.WriteLine("(2) Password Generator");
            Console.WriteLine("(3) Exit Program");
            Console.Write("Enter program number: ");
            userInput = int.Parse(Console.ReadLine());
        }

        if (userInput == 1) { PasswordManager.PassInput(); }
        if (userInput == 2) { PasswordGenerator.MainS(); }
        if (userInput == 3) { Environment.Exit(0); }
    }
}



class PasswordManager
{
    public static string filePath = "txtFile.txt";

    public static void PassInput()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n(1) Add");
        Console.WriteLine("(2) View");
        Console.WriteLine("(3) Back");
        Console.Write("Enter choice: ");
        int user_input = int.Parse(Console.ReadLine());

        while (user_input != 1 && user_input != 2 && user_input != 3)
        {
            Console.WriteLine("\nInvalid Input");
            Console.WriteLine("(1) Add");
            Console.WriteLine("(2) View");
            //Console.WriteLine("(3) Delete");
            Console.WriteLine("(3) Back");
            Console.Write("Enter choice: ");
            user_input = int.Parse(Console.ReadLine());
        }

        if (user_input == 1) { AddPass(); }
        if (user_input == 2) { PrintPass(); }
       // if (user_input == 3) {}
        if (user_input == 3) { Program.Main(); }
    }

    public static void AddPass()
    {
        Console.Write("Enter service/website name: ");
        var service = Console.ReadLine();

        Console.Write("Enter username/email: ");
        var username = Console.ReadLine();

        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        try
        {
            using (StreamWriter writer = File.AppendText(PasswordManager.filePath))
            {
                writer.WriteLine(string.Empty);
                writer.WriteLine("---> "+service+" <---");
                writer.WriteLine("Username: "+username);
                writer.WriteLine("Password: "+password);
                Console.WriteLine("Text appended to the file.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        PassInput();
    }

    public static void PrintPass()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        try
        {
            string content = File.ReadAllText(filePath);
            Console.WriteLine(content);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        PassInput();
    }
}



class PasswordGenerator
{
    static Random random = new Random();

    public static void Generate()
    {
        string characterSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        Console.Write("Password Length: ");
        int length = int.Parse(Console.ReadLine());

        while (length <= 0)
        {
            Console.WriteLine("Invalid Input. Please try again.");
            Console.Write("Password Length: ");
            length = int.Parse(Console.ReadLine());
        }

        string randomString = GenerateRandomString(length, characterSet);
        Console.WriteLine(randomString);
        Program.Main();
    }

    static string GenerateRandomString(int length, string characterSet)
    {
        if (length <= 0 || string.IsNullOrEmpty(characterSet))
        {
            return string.Empty;
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            int index = random.Next(0, characterSet.Length);
            sb.Append(characterSet[index]);
        }
        return sb.ToString();
    }

    public static void MainS()
    {
        Console.WriteLine("(1) Generate password");
        Console.WriteLine("(2) Back");
        Console.Write("Enter Number: ");
        int userInpu = int.Parse(Console.ReadLine());

        while(userInpu != 1 && userInpu != 2)
        {
            Console.WriteLine("Invalid Input. Please try again.");
            Console.WriteLine("(1) Generate password");
            Console.WriteLine("(2) Back");
            Console.Write("Enter Number: ");
            userInpu = int.Parse(Console.ReadLine());
        }

        if (userInpu == 1) { PasswordGenerator.Generate(); }
        if (userInpu == 2) { Program.Main(); }
    }
}
