using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaSamochodow
{
    public class Samochod
    {
        public int index { get; set; }
        public String marka { get; set; }
        public String model { get; set; }
        public Int16 rok { get; set; }
        public String silnik { get; set; }
        public String naped { get; set; }
        public String skrzynia { get; set; }

        public Samochod()
        { }

        public Samochod(int index, String marka, String model, Int16 rok, String silnik, String naped, String skrzynia)
        {
            this.index = index;
            this.marka = marka;
            this.model = model;
            this.rok = rok;
            this.silnik = silnik;
            this.naped = naped;
            this.skrzynia = skrzynia;
        }
    }
}
