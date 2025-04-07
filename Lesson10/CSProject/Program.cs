using System.Runtime.Intrinsics.X86;

class FileManager
{
    private string _currentDirectory;
    private string[] _pages;
    public FileManager()
    {
        _currentDirectory = Directory.GetCurrentDirectory();
    }

    public void printDirectory()
    {
        System.Console.WriteLine($"Текущая директория: {_currentDirectory}");
        string[] dirFiles = Directory.GetFiles(_currentDirectory);
        string[] dirDirectories = Directory.GetDirectories(_currentDirectory);
        int i = 1;
        foreach(string dir in dirDirectories)
        {
            System.Console.WriteLine($"{i}. {dir}");
            i++;
        }
        foreach(string file in dirFiles)
        {
            System.Console.WriteLine($"{i}. {file}");
            i++;
        }
    }
    
    public void changeDirectory(string newDirectory)
    {
        if (Directory.Exists(newDirectory))
        {
            _currentDirectory = newDirectory;
        }
    }
}


class Program
{
    static void Main()
    {
        FileManager fm = new FileManager();
        string input = "";
        fm.printDirectory();
        while (true)
        {
            string[] temp = input.Split(' ');
            if (temp[0] == "cd")
            {
                fm.changeDirectory(temp[1]);
            }
            input = System.Console.ReadLine();
            fm.printDirectory();
        }
    }
}
        