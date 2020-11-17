using System;
using UtilityLibraries;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using StringLibrary;

// Console App by: Sally Nielsen

class Program
{
    // To write out commands available
    static void printGuestbook()
    {
        Console.WriteLine(" ");
        Console.Write("1. Skriv i gästboken \n");
        Console.Write("2. Ta bort inlägg");
        Console.WriteLine("\n");
        Console.Write("X. Avsluta \n");

    }

    static void Main(string[] args)
    {
    // Where to application starts (for goto Start)
    Start:

        Console.WriteLine("S A L L Y ' S   G U E S T B O O K \n");

        // Path to json file
        string path = (@"/Users/sallynielsen/Projects/ClassLibraryProjects/StringLibrary/jsonposts.json");

        // Reads JSON file and deserialize it to Collection
        string allPosts = File.ReadAllText(path);
        List<Post> myposts = JsonConvert.DeserializeObject<List<Post>>(allPosts);

        // instance of class obj
        PostList list = new PostList();
        // Writes out the posts from collection, through class method
        list.writePosts(myposts);

        // Show options (calls method)
        printGuestbook();

        // Switch method for chosen option
        var choosePath = Console.ReadLine();
        switch (choosePath)
        {
            // If user press 1
            case "1":
                // Clearing console
                Console.Clear();

            startCreateName:
                // Takes input from user, put in string variables
                string inputName, inputContent;
                Console.WriteLine("Write your name and press ENTER: ");
                // Checks if input is null or empty, if true - start over
                inputName = Console.ReadLine();
                if (String.IsNullOrEmpty(inputName))
                {
                    goto startCreateName;

                };
            startCreateContent:
                Console.WriteLine("Write your post and press ENTER: ");
                inputContent = Console.ReadLine();
                // Checks if input is null or empty, if true - start over
                if (String.IsNullOrEmpty(inputContent))
                {
                    goto startCreateContent;

                };
               
                // Class method to save new post
                list.add(myposts, inputName, inputContent, path);
                
                // Starts over
                goto Start;
            // If user press 2
            case "2":

                Console.WriteLine("Which post do you want to delete?");
                Console.WriteLine("Type the number of the post index and finish by pressing ENTER");
                // User input, parse to integer for delete purpose
                int delIndex = Convert.ToInt32(Console.ReadLine());
                // Method from class to delete
                list.Delete(delIndex, myposts, path);

                // Starts over/ Goes back to menu
                goto Start;
            // If user press X
            case "x":
                // Clears and Exits
                Console.Clear();
                Environment.Exit(0);
                break;

        }
    }


}

