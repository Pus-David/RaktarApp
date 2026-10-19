using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RaktarApp
{
    internal class TartosTermek : Termek
    {
        public int GaranciaEvek { get; set; }

        public TartosTermek (int garanciaevek, string becikkszam, int bealapar) : base(becikkszam, bealapar )
        {
            GaranciaEvek = garanciaevek;

        }
        public override int ErtekSzamitas(int darabszam)
        {
            return base.ErtekSzamitas(darabszam) + (GaranciaEvek * 500 * darabszam);
        }
        public override string ToString()
        {
            return $"{base.ToString()}|Garancia {GaranciaEvek}";
        }

    }
}
