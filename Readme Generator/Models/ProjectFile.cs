namespace Readme_Generator.Models;

public class ProjectFile
{
    public string Name { get; set; } = string.Empty;

    public string FolderName { get; set; } = string.Empty;
    
    public string Path { get; set; } = string.Empty;
    
    public string Extension { get; set; } = string.Empty;

    public List<string> Contents { get; set; } = new List<string>();
}