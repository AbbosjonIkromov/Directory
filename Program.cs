using System;
using System.IO;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;
using System.Threading;


string path = @"D:\";
string input = "";
do
{
    Console.Clear();
    Console.WriteLine(path);
    ListOfCurrentFolder(path);

    Console.Write("\nEnter the folder name to continue: ");
    input = Console.ReadLine();

    if(input.Equals("../"))
    {
        string helper = Path.GetDirectoryName(path);

        if(!string.IsNullOrEmpty(helper))
            path = helper;
        else
        {
            Console.Clear();
            Console.WriteLine("\n\t\tThis is a top-level folder.\n");
            Thread.Sleep(3000);
        }

    }
    else if(Directory.Exists(Path.Combine(path, input)))
        path = Path.Combine(path, input);
    
}while(!input.Equals("stop",  StringComparison.OrdinalIgnoreCase));

void ListOfCurrentFolder(string path)
{
    Console.WriteLine($"\n  {"File/Folder",-50}\t\t{"Size",-10}\n");
    IEnumerable<string> files = Directory.EnumerateFileSystemEntries(path);

    foreach(var file in files)
    {
        if(Directory.Exists(file))
        {
            DirectoryInfo directory = new DirectoryInfo(file);
            Console.WriteLine($"..{directory.Name,-50}");
        }
        else if(File.Exists(file))
        {
            FileInfo fileInfo = new FileInfo(file);
            Console.WriteLine($"..{fileInfo.Name,-50}\t\t{fileInfo.Length + " bites",-10}");
        }
    }
}



