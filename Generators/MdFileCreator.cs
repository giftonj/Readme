namespace Readme_Generator.Generators;

public class MdFileCreator
{
    public void CreateMdFile(string path, string content)
    {
        var fileName = "README.md";
        
        var filePath = Path.Combine(path, fileName);
        
        File.WriteAllText(filePath, content);
        
    }
}