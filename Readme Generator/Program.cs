// See https://aka.ms/new-console-template for more information

using Readme_Generator.Models;
using Readme_Generator.Readers;
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
        List<ProjectFile> folders = scanner.FoldersToIgnore(root);
        
        Console.WriteLine();
        
        Console.WriteLine("Retrieving files from directory ");
        foreach (ProjectFile folder in folders)
        {
            var files = scanner.GetFilesFromRootFolders(root, folder.Name);
            
            Console.WriteLine("Found " + files.Count + " files" + $" from folder: {folder.Name}" );    
          
            
            foreach (ProjectFile file in files)
            {
                
                Console.WriteLine(" - " + file.Name);
            }
            
            Console.WriteLine();
        }
        
        Console.WriteLine("Files from root");
        var f = scanner.FilesFromRoot(root);
        foreach (var file in f){
            Console.WriteLine(" - " + file.Name);
            
        }
        
        ProjectReader reader = new ProjectReader();
        List<ProjectFile> data = reader.ReadRootFiles(root, f);
        Console.WriteLine();
        Console.WriteLine("Files from root");
        foreach (var file in data)
        {
            Console.WriteLine(" ##### " + file.Name);
            foreach (var line in file.Contents)
            {
                Console.WriteLine(line);
            }
        }
        Console.WriteLine();
        
        Console.WriteLine("Summary from root");
        ProjectSummary summaries = reader.ProjectSummary(root, f);
       
        Console.WriteLine("Project Name");
        Console.WriteLine(" - " + summaries.Name);

        Console.WriteLine("Project Files");
        if (summaries.Files.Count > 0)
        {
            foreach (var file in summaries.Files)
            {
                Console.WriteLine(" - " + file.Name);
                    
            }
        }
        
    } 
}
