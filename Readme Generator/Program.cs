// See https://aka.ms/new-console-template for more information
using Readme_Generator.Scanner;


public class Run
{
  
    public static void Main(string[] args)
    {
        ProjectRootFinder finder = new ProjectRootFinder();

        string root = finder.ReadProject();
        
        Console.WriteLine("The root path is: " + root);
        
        ProjectScanner scanner = new ProjectScanner();
        
        Console.WriteLine("Scanning " + root);
        List<string> folders =scanner.FoldersToIgnore(root);
        
        Console.WriteLine();
        
        Console.WriteLine("Retrieving files from directory ");
        foreach (string folder in folders)
        {
            var files = scanner.GetFilesFromRootFolders(root, folder);
            
            Console.WriteLine("Found " + files.Count + " files" + $" from folder: {folder}" );    
          
            
            foreach (string file in files)
            {
                
                Console.WriteLine(" - " + file);
            }
            
            Console.WriteLine();
        }
        
        Console.WriteLine("Files from root");
        var f = scanner.FilesFromRoot(root);
        foreach (var file in f){
            Console.WriteLine(" - " + file);}
    } 
}
