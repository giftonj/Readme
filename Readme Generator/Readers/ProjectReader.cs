using Readme_Generator.Models;

namespace Readme_Generator.Readers;

public class ProjectReader
{
    public List<ProjectFile> ReadRootFiles(string root, List<ProjectFile> files)
    {
        List<ProjectFile> projectFiles = new List<ProjectFile>();
        foreach (var file in files)
        {
            var r = Path.Combine(root, file.Name);

            string[] lines = File.ReadAllLines(r);
            Console.WriteLine($"Reading: {file.Name}");
            
            projectFiles.Add(new ProjectFile
            {
                Contents = lines.ToList(),
                Name = file.Name
            });
        }

        return projectFiles;
    }
}