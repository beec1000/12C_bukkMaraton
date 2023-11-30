using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bukkMaraton
{
    class Versenyzo
    {
        public string Rajtszam { get; set; }
        public string Kategoria { get; set; }
        public string Nev { get; set; }
        public string Egyesulet { get; set; }
        public TimeSpan Ido { get; set; }

        public string Tav => _tav.Tav;
        private Versenytav _tav;

        public Versenyzo(string s)
        {
             var v = s.Split(';');
            this.Rajtszam = v[0];
            this.Kategoria = v[1];
            this.Nev = v[2];
            this.Egyesulet = v[3] == "" ? null : v[3];
            var ido = v[4].Split(':');
            this.Ido = new TimeSpan(
                hours: int.Parse(ido[0]), 
                minutes: int.Parse(ido[1]), 
                seconds: int.Parse(ido[2]));
            this._tav = new Versenytav(this.Rajtszam);

        }

        public override string ToString()
        {
            return $"{this.Rajtszam}, {this.Kategoria}, {this.Nev}, {this.Egyesulet}, {this.Ido}";
        }
    }
}
