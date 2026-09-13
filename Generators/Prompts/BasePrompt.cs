using Readme_Generator.Models;

namespace Readme_Generator.Generators.Prompts;

public class BasePrompt
{
    public string BasicPrompt(ProjectSummary summaries, List<ProjectFile> folders, List<string> subfoldersFromRoot, List<ProjectFile> filesFromRootFolders, List<ProjectFile> f, List<ProjectFile> readme ,string sourceCode)
    {
       var prompt = $$"""
                       You are an expert technical writer.
                       
                       Generate a professional README for the following project but also tell me if the current files are good.
                       
                       ProjectName:
                       {{summaries.Name}}
                       
                       This is the starting point;
                       If the Readme part is not empty read from it first then edit the necessary lines and add things that seem like they have changed from the source code from the previous readme contents.
                       README.md:
                       {{string.Join("\n", readme.Select(c => c.Contents))}}
                       
                       Root Folders:
                       {{string.Join("\n", folders.Select(folder => "-" + folder.Name))}}
                       
                       Subfolders:
                       {{string.Join("\n", subfoldersFromRoot.Select(folder => "- " + folder))}}
                       
                       Files from Root subfolders:
                       {{string.Join("\n", filesFromRootFolders.Select(file => "- " + file.FolderName + "/" + file.Name))}}
                       
                       
                       Root Files:
                       {{string.Join("\n", f.Select(file => "-" + file.Name))}}
                       
                       
                       SourceCode from Root Files:
                       {{sourceCode}}
                       
                       Project Summary:
                       {{summaries.Files}}
                       
                       Instructions:
                       - Explain what this project does.
                       - Suggest a better folder structure if needed.
                       - Point out missing files.
                       - Suggest improvements.
                       - Generate a README.md.
                       - In the response don't start with "Here's a professional README for your **Readme Generator** project, incorporating feedback and improvements based on your current implementation:" just go straight to the README.md content.
                       
                       """;


       return prompt;
    }
}