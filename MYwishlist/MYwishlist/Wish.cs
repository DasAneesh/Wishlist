using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYwishlist
{
    public class Wishes
    {
        private int iD;
        private string productname;
        private string link;
        private int wishmeter;
        private int cost;

        public int ID { get => iD; set => iD = value; }
        public string Productname { get => productname; set => productname = value; }
        public string Link { get => link; set => link = value; }
        public int Wishmeter { get => wishmeter; set => wishmeter = value; }
        public int Cost { get => cost; set => cost = value; }

    
    }
}
