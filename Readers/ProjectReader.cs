using System.Text.Json;
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
            
           
            var extension = Path.GetExtension(file.Name);
            if(file.Name.StartsWith(".")) continue;
            
            // TO BE REMOVED LATER NOW IT'S BEING USED TO IGNORE A LARGE TEXT FILE OF THE CURRENT PROJECT CREATOR
            if (extension == ".txt" || extension == ".md")
                continue;
            
            if (extension == ".cs" || files.Any(f => f.Name.Contains(".csproj")))
            {
                Console.WriteLine("This is a C# project .");
            }
            else if (extension == ".py" || extension == ".pyproj" || file.Name == "pyproject.toml" )
            {
                Console.WriteLine("This is a Python project .");
            }
            else if (extension == ".md")
            {
                Console.WriteLine("This is a Markdown project .");
            }
            else if(extension == ".json" && file.Name == "package.json")
            {
                var document = JsonDocument.Parse(File.ReadAllText(r));
                if (document.RootElement.TryGetProperty("dependencies", out JsonElement dependencies))
                {
                    Console.WriteLine("This is a Node.js based project .");
                    
                    if (dependencies.TryGetProperty("react", out JsonElement react))
                    {
                        Console.WriteLine($"React: {react.GetString()}");
                    }
                    else if (dependencies.TryGetProperty("vue", out JsonElement vue))
                    {
                        Console.WriteLine($"Vue:  {vue.GetString()}");
                    }
                    else if (dependencies.TryGetProperty("express", out JsonElement express))
                    {
                        Console.WriteLine($"Express:   {express.GetString()}");
                    }
                    else if (dependencies.TryGetProperty("next", out JsonElement next))
                    {
                        Console.WriteLine($"Next.js: {next.GetString()}");
                    }
                    else if (dependencies.TryGetProperty("@nestjs/core", out JsonElement core))
                    {
                        Console.WriteLine($"Nest.js: {core.GetString()}");
                    }
                }
            }
            else if (extension == ".txt")
            {
                continue;
            }
            else if (extension == ".toml" && file.Name == "Cargo.toml")
            {
                Console.WriteLine("This is a Rust project .");
            }
            else if (file.Name == "go.mod" || extension == ".mod")
            {
                Console.WriteLine("This is a Go project .");
            }
            else if (file.Name == "pom.xml" || extension == ".java")
            {
                Console.WriteLine("This is a Java project .");
            }
            else if (file.Name == "build.gradle" || extension == ".gradle")
            {
                Console.WriteLine("This is a Kotlin project .");
            }
            
            projectFiles.Add(new ProjectFile
            {
                Contents = lines.ToList(),
                Name = file.Name
            });
        }

        return projectFiles;
    }
    
    public ProjectSummary ProjectSummary(string root, List<ProjectFile> files)
    {
        List<ProjectFile> data = ReadRootFiles(root, files);

        var projectName = Path.GetFileName(root);

        ProjectSummary summary = new ProjectSummary();

        summary.Name = projectName!;
        summary.Files = data;
   
        
        return summary;
    }
}