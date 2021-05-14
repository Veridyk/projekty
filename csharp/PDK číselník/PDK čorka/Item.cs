using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDK_čorka
{
    class Item
    {
        public string KodPDK { get; set; }
        public string Nazev { get; set; }
        public string Pojistovna { get; set; }
        public string SUKL { get; set; }
        public string Vyrobce { get; set; }

        public Item(string KodPDK, string Nazev, string Pojistovna, string SUKL, string Vyrobce)
        {
            this.KodPDK = KodPDK;
            this.Nazev = Nazev;
            this.Pojistovna = Pojistovna;
            this.Vyrobce = Vyrobce;
        }
    }
}
