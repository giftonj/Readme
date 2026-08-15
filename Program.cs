// See https://aka.ms/new-console-template for more information

using Readme_Generator.Generators;
using Readme_Generator.Models;
using Readme_Generator.Readers;
using Readme_Generator.Scanner;


public class Run
{

    public static async Task Main(string[] args)
    {
        ProjectRootFinder finder = new ProjectRootFinder();

        string root = finder.ReadProject();

        Console.WriteLine("The root path is: " + root);

        ProjectScanner scanner = new ProjectScanner();

        Console.WriteLine("Scanning " + root);
        List<ProjectFile> folders = scanner.FoldersToIgnore(root);

        Console.WriteLine();

        Console.WriteLine("Subfolders from root");
        List<string> subfoldersFromRoot = new List<string>();

        foreach (var folder in folders)
        {
            Console.WriteLine(folder.Name);
            var subFolders = scanner.ProjectSubFolders(root, folder.Name);

            foreach (var subFolder in subFolders)
            {
                var relative = Path.GetRelativePath(root, subFolder.Name);
                subfoldersFromRoot.Add(relative);

                int depth = relative.Split(Path.DirectorySeparatorChar).Length - 1;

                // subfoldersFromRoot.Add(
                //     $"{new string('-', depth * 2)} {Path.GetFileName(subFolder.Name)}"
                // );

                Console.WriteLine($"{new string('-', depth * 2)} {Path.GetFileName(subFolder.Name)}");
            }
        }


        Console.WriteLine();

        Console.WriteLine("Retrieving files from directory ");
        List<ProjectFile> filesFromRootFolders = new List<ProjectFile>();
        foreach (ProjectFile folder in folders)
        {
            var files = scanner.GetFilesFromRootFolders(root, folder.Name);

            filesFromRootFolders.AddRange(files.Select(file => file));

            Console.WriteLine("Found " + files.Count + " files" + $" from folder: {folder.Name}");


            foreach (ProjectFile file in files)
            {

                Console.WriteLine(" - " + file.Name);
            }

            Console.WriteLine();
        }

        Console.WriteLine("Files from root");
        var f = scanner.FilesFromRoot(root);
        foreach (var file in f)
        {
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

        var sourceCode = string.Join(
            "\n\n",
            data.Select(file =>
                $"""
                 File: {file.Name}

                 {string.Join("\n", file.Contents)}

                 ----------------------------------------
                 """));

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

        Console.WriteLine("Response from the AI");
        var apiKey = "***************************";

        var mistral = new MistralClient(apiKey);

        var prompt = $$"""
                       You are an expert technical writer.
                       
                       Generate a professional README for the following project but also tell me if the current files are good.
                       
                       ProjectName:
                       {{summaries.Name}}
                       
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
                       
                       """;

        string answer = await mistral.AskAsync(prompt);
        Console.WriteLine(answer);

    }
}
