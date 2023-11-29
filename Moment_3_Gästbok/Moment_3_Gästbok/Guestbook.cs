using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Moment_3_Gästbok
{
    internal class Guestbook
    {
        //variabel som ska användas för att ge Id till inläggen:
        private static int nextId;
        //skapar en lista att stoppa inläggen i:
        private List<Post> ? posts;
        //filväg till JSON-filen:
        private const String FilePath = "C:\\Users\\46725\\source\\repos\\Moment_3_Gästbok\\Moment_3_Gästbok\\Guestbook.json";

        //initiering av gästbokklassen:
        public Guestbook() { 
            //initierar en ny lista med inlägg för förvaring av det vi hittar i JSON-filen
        posts = new List<Post>();
        }

        //metod för att lägga till poster:
        public void AddPost(Post post)
        {
            //inkrementerar varje id per inlägg:
            post.Id = nextId++;
            //använder posts-objektet medd "add" metoden för att lägga till:
            posts.Add(post);
            //sparar till JSON-filen med savetofile-metoden:
            SaveToFile(FilePath);
        }

        //metod för att radera inlägg:
        public void DeletePost(int postId)
        {
            // Hitta post med hjälp av Id:
            Post postToDelete = posts.FirstOrDefault(post => post.Id == postId);

            //if sats som kontrollerar att Id finns:
            if (postToDelete != null)
            {
                /* En rad som ligger här för att kunna debugga - hade lite svårt att nå JSON-filen i början:
                Console.WriteLine($"Hittade post med ID och författare: {postId}: {postToDelete.Name}");*/

                // Använder remove metoden för att radera från JSON-filen:
                posts.Remove(postToDelete);

                //bekräftelse av radering:
                Console.WriteLine($"Post med ID {postId} raderad.");

                // Åkalla savetofile igen för att spara:
                SaveToFile(FilePath);

                // Skriv ut den nya listan med inlägg:
                Console.WriteLine("Updaterad lista med Poster:");
                foreach (var post in posts)
                {
                    Console.WriteLine($"ID: {post.Id}, Title: {post.Name} - {post.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Post med ID {postId} kunde inte hittas.");
            }
        }

        //metod för att visa samtliga inlägg:
        public void DisplayPosts()
        {
            //foreach-loop som går igenom alla inlägg...
            foreach (var post in posts)
            {
                //och skriver ut dem!
                Console.WriteLine(post);
            }
        }

        //metod för att spara till JSON-filen: Tar filvägen till JSON-filen som argument:
        public void SaveToFile(string FilePath)
        {
            //om möjligt sparar vi till JSON-filen:
            try
            {
                //omvandlar post-objekt till JSON med serialiseringsmetoden:
                string json = JsonSerializer.Serialize(posts);
                //Skriver ovanstående JSON-objekt i JSON-filen med denna metod:
                File.WriteAllText(FilePath, json);
            }
            //om detta inte är möjligt:
            catch (Exception ex)
            {
                //Så får vi felmeddelande:
                Console.WriteLine($"Det gick inte att spara till filen: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            //om möjligt ska detta hända:
            try
            {
                //kontrollera att vi har en JSON-fil i FilePath-variabeln:
                if (File.Exists(FilePath))
                {
                    //om så är fallet använder vi readalltext-metoden för att lägga JSON i en variabel:
                    string json = File.ReadAllText(FilePath);
                    //avserialisera och för in i listan av inlägg:
                    posts = JsonSerializer.Deserialize<List<Post>>(json);
                }
            }
            catch (Exception ex)
            {
                //om ovanstående inte var möjligt vill man ju ha felmeddelande:
                Console.WriteLine($"Kunde inte ladda från filen: {ex.Message}");
            }
        }



        }
}
