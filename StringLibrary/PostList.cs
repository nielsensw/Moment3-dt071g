using System;
using UtilityLibraries;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
// PostList class

namespace StringLibrary
{
    public class PostList
    { 

        // Method to write all posts out
        public void writePosts(List<Post> list)
        {
            // Writes out the posts from collection
            for (int i = 0; i < list.Count; i++)
            {
                Post post1 = list[i];
                Console.WriteLine("{" + i + "} " + post1.Name + ": " + post1.Content);
            }
        }

        // Method to add post
        public void add(List<Post> list, string name, string content, string path)
        {
            // New objects of Post class
            Post postObj = new Post() { Name = name, Content = content };
            // adds to the list collection
            list.Add(postObj);
            // Serialize collection and writes to file
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, json, Encoding.UTF8);
        }

        // method to delete post
        public void Delete(int index, List<Post> list, string path)
        {

            // Deletes post in Collection, depending on number (index) given
            list.RemoveAt(index);
            // Serialize collection and writes to file
            string jsonsave = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, jsonsave, Encoding.UTF8);

        }
    }
}
