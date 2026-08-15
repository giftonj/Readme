namespace Readme_Generator.Models;

public class ProjectSummary
{
    public string Name { get; set; } = string.Empty;
    
    public string Language { get; set; } = string.Empty;
    
    public List<ProjectFile> Files { get; set; } = new List<ProjectFile>();
    
    public List<string> Dependencies { get; set; } = new List<string>();

}