using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moment_3_Gästbok
{
    //inläggs-klassen:
    internal class Post
    {
   

        public string ? Name { get; set; }
        //egenskap för meddelande:
        public string ? Message { get; set; }
        //egenskap för Id:
        public int ? Id { get; set; }

        
    

        //ger oss en rimlig översättning av inläggs-objektet vid instans:
        public override string ToString()
        {
            //den returnerar id - namn: meddelande:
            return $"{Id} - {Name}: {Message}";
        }
    }
}
