using Moment_3_Gästbok;

namespace Gästbok
{
    class Program
    {

        static void Main(string[] args)
        {

            //skapar instans av gästboks-klassen:
            Guestbook guestbook = new Guestbook();

            //While-loop som håller programmet igång tills användare väljer att avsluta:
            while (true)
            {

                const String filePath = "C:\\Users\\46725\\source\\repos\\Moment_3_Gästbok\\Moment_3_Gästbok\\Guestbook.json";
                //skriv ut de olika alternativen till användaren:
                Console.WriteLine("Meny:");
                Console.WriteLine("1. Lägg till inlägg");
                Console.WriteLine("2. Radera inlägg");
                Console.WriteLine("3. Visa inlägg");
                Console.WriteLine("4. Spara och avsluta");

                //uppmana användaren att välja alternativ:
                Console.Write("Skriv siffran för det alternativ du vill ha: ");

                //läs in användarens svar i en variabel
                string choice = Console.ReadLine();

                //använd denna i en switch-sats:
                switch (choice)
                {
                    case "1":
                        //rensar skärmen:
                        Console.Clear();
                        //ber användare skriva namn och meddelande och tar emot dessa i variabler:
                        Console.Write("Skriv ditt namn: ");
                        string name = Console.ReadLine();
                        Console.Write("Skriv ditt meddelande: ");
                        string message = Console.ReadLine();

                        if (name.Length > 1 && message.Length > 1) { 
                            //gör dessa till Post-objekt:
                            Post newPost = new Post { Name = name, Message = message };
                        //använder gästboksklassens addpost-metod på det nya post-objektet:
                        guestbook.AddPost(newPost);}
                        else
                        {
                            Console.WriteLine("Namn eller meddelande måste vara mer än en bokstav. Gör om, gör rätt!");
                        }
                        
                        //och bryter:
                        break;

                    case "2":
                        //rensar skärmen:
                        Console.Clear();

                        //ber användaren att skriva index-nummer för det meddelande som ska raderas:
                        Console.Write("Skriv in index-nummer för det meddelande du vill radera: ");

                        //om det index som skickas med kan parse:as returneas sant och då...
                        if (int.TryParse(Console.ReadLine(), out int index))
                        {
                            //skickas denna med som argument i gästbok-klassens delete-metod:
                            guestbook.DeletePost(index);
                        }
                        else
                        {
                            //annars får vi detta felmeddelande:
                            Console.WriteLine("Felaktigt index-nummer - skriv ett korrekt index-nummer.");
                        }
                        
                        break;

                    case "3":
                        //rensar skärmen:
                        Console.Clear();
                        //laddar in kurser från filer och visar dem med hjälp av dessa gästboks-metoder:
                        guestbook.LoadFromFile();
                        guestbook.DisplayPosts();
                        
                        break;

                    case "4":
                        //rensar skärmen:
                        Console.Clear();
                        // Save till JSON-fil och avsluta:
                        guestbook.SaveToFile(filePath);
                        return;

                        //om vi inte mottar ett valbart alternativ (exempelvis "5") så hamnar vi här:
                    default:
                        //rensar skärmen:
                        Console.Clear();
                        Console.WriteLine("Felaktigt val. Välj 1-4.");
                        
                        break;
                }



                }
        }
    }
}