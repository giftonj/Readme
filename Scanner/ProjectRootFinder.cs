namespace Readme_Generator.Scanner;

public class ProjectRootFinder
{
    public string ReadProject()
    {
        string directory = Directory.GetCurrentDirectory();

        while (directory != null)
        {
            if (File.Exists(Path.Combine(directory, ".git")) ||
                Directory.Exists(Path.Combine(directory, ".git")) ||
                Directory.GetFiles(directory, "*.csproj").Any() ||
                File.Exists(Path.Combine(directory, "package.json")) ||
                File.Exists(Path.Combine(directory, "pyproject.toml")) ||
                File.Exists(Path.Combine(directory, "Cargo.toml")))
            {
                Console.WriteLine($"Project root: {directory}");
                break;
            }

            directory = Directory.GetParent(directory)?.FullName;
        }
        
        return directory!;
    }
}