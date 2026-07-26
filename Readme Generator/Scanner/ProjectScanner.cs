namespace Readme_Generator.Scanner;

public class ProjectScanner
{
    
    public List<string> FoldersToIgnore(string directories)
    {
        var folders = Directory.GetDirectories(directories);

        var ignored = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "node_modules",
            "bin",
            "obj"
        };
        var f = new List<string>();
        foreach (var folder in folders)
        {
            var folderName = Path.GetFileName(folder);
            
            if (ignored.Contains(folderName))
            {
                Console.WriteLine("Skipping " + folderName);
                continue;
            }
           
            
            Console.WriteLine("Scanning " + folderName);

           f.Add(folderName);
        }

        return f;
    }

    public List<string> FilesFromRoot(string root)
    {
        var files = Directory.GetFiles(root);
        List<string> f = new List<string>();
        foreach (var file in files)
        {
            var t = Path.GetFileName(file);
            f.Add(t);
        }

        return f;
    }
    
    public List<string> GetFilesFromRootFolders(string root, string directory)
    {
        var folderPath = Path.Combine(root, directory);
        var files = Directory.GetFiles(folderPath);
        
        var f = new List<string>();
        foreach (var file in files)
        {
            var t = Path.GetFileName(file);
            f.Add(t);
        }

        
        return f;
    }
}