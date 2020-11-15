using System;
using UtilityLibraries;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

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

        // Writes out the posts from collection
        for (int i = 0; i < myposts.Count; i++)
        {
            Post post1 = myposts[i];
            Console.WriteLine("{" + i + "} " + post1.Name + ": " + post1.Content);
        }

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

                // Adds inputs to collection
                myposts.Add(new Post() { Name = inputName, Content = inputContent });

                // Serialize collection and writes to file
                string json = JsonConvert.SerializeObject(myposts, Formatting.Indented);
                File.WriteAllText(path, json, Encoding.UTF8);

                // Starts over
                goto Start;
            // If user press 2
            case "2":

                Console.WriteLine("Which post do you want to delete?");
                Console.WriteLine("Type the number of the post index and finish by pressing ENTER");

                // Deletes post in Collection, depending on number (index) given
                int delIndex = Convert.ToInt32(Console.ReadLine());
                myposts.RemoveAt(delIndex);
                // Serialize collection and writes to file
                string jsonsave = JsonConvert.SerializeObject(myposts, Formatting.Indented);
                File.WriteAllText(path, jsonsave, Encoding.UTF8);

                // Starts over
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

