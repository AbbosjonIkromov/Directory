using System;
using System.IO;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;
using System.Threading;


string path = @"D:\";
string input = string.Empty;
do
{
    Console.Clear();
    Console.WriteLine('\n' + path);
    ListOfCurrentFolder(path);

    Console.Write("\nEnter the folder name to continue: ");
    input = Console.ReadLine();

    if (input.Equals("../"))
    {
        string helper = Path.GetDirectoryName(path);

        if (!string.IsNullOrEmpty(helper))
            path = helper;
        else
        {
            Console.Clear();
            Console.WriteLine("\n\t\tThis is a top-level folder.\n");
            Thread.Sleep(3000);
        }

    }
    else if (Directory.Exists(Path.Combine(path, input)))
        path = Path.Combine(path, input);

} while (!input.Equals("stop", StringComparison.OrdinalIgnoreCase));





void ListOfCurrentFolder(string path)
{
    var info = new DirectoryInfo(path);

    Console.WriteLine($"\n  {"File/Folder",-50}\t\t{"Size"}\n");

    var directories = info.GetDirectories();
    foreach (var directory in directories)
    {
        Console.WriteLine($"..{directory.Name}");
    }

    var files = info.GetFiles();
    foreach (var file in files)
    {
        var fileName = (file.Name.Length > 50) ? $"{file.Name[..50]}.." : file.Name;
        Console.WriteLine($"..{fileName,-50} {file.Length} bytes");
    }

}



