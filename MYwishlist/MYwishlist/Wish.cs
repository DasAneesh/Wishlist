using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYwishlist.Repository
{
    public class Wish
    {
        
        public Wish(int iD, string productname, string link, int wishmeter, int cost)
        {
            
        }

        public int ID { get ; set ; }
        public string Productname { get ; set ; }
        public string Link { get; set; }
        public int Wishmeter { get ; set ; }
        public int Cost { get; set; }

    
    }
}
