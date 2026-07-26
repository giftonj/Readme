// See https://aka.ms/new-console-template for more information
using Readme_Generator.Scanner;


public class Run
{
  
    public static void Main(string[] args)
    {
        ProjectRootFinder finder = new ProjectRootFinder();

        string root = finder.ReadProject();
        
        Console.WriteLine("The root path is: " + root);
    } 
}
