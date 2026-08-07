using Readme_Generator.Models;

namespace Readme_Generator.Scanner;

public class ProjectScanner
{
    
    public List<ProjectFile> FoldersToIgnore(string directories)
    {
        var folders = Directory.GetDirectories(directories);

        var ignored = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "node_modules",
            "bin",
            "obj",
            ".git",
            "dist",
            "build",
            "target",
            "venv",
            "__pycache__",
            "lib",
        };
        var f = new List<ProjectFile>();
        foreach (var folder in folders)
        {
            var folderName = Path.GetFileName(folder);
            
            if (ignored.Contains(folderName))
            {
                Console.WriteLine("Skipping " + folderName);
                continue;
            }
           
            
            Console.WriteLine("Scanning " + folderName);

           f.Add(new ProjectFile
           {
               Name = folderName,
           });
        }

        return f;
    }

    public List<ProjectFile> ProjectSubFolders(string root, string folders)
    {
        List<ProjectFile> name = new List<ProjectFile>();
       
        var folderPath = Path.Combine(root, folders);
        var sub =  Directory.GetDirectories(folderPath, "*", SearchOption.AllDirectories);

        foreach (var subFolder in sub)
        {
            name.Add(new ProjectFile
                {
                    Name = subFolder,
                }
            );
        }
        
        return name;
    }

    public List<ProjectFile> FilesFromRoot(string root)
    {
        var files = Directory.GetFiles(root);
        List<ProjectFile> f = new List<ProjectFile>();
        foreach (var file in files)
        {
            var t = Path.GetFileName(file);
            f.Add(new ProjectFile
            {
                Name = t,
            });
        }

        return f;
    }
    
    public List<ProjectFile> GetFilesFromRootFolders(string root, string directory)
    {
        var folderPath = Path.Combine(root, directory);
        var files = Directory.GetFiles(folderPath);
        
        var f = new List<ProjectFile>();
        foreach (var file in files)
        {
            var t = Path.GetFileName(file);
            f.Add(new ProjectFile
            {
                Name = t,
                FolderName = directory
            });
        }

        
        return f;
    }
}