using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProject
{
    class Harcos
    {
        private string nev;
        private int szint;
        private int tapasztalat;
        private int eletero;
        private int alapEletero;
        private int alapSzebzés;

        public Harcos(string nev, int statuszSablon)
            { 

        }

        public string Nev { get => nev; set => nev = value; }
        public int Szint { get => szint; set => szint = value; }
        public int Tapasztalat { get => tapasztalat; set => tapasztalat = value; }
        public int Sebzes { get => alapSzebzés + szint;  }
        public int Eletero { get => eletero; set => eletero = value; }
        public int AlapEletero { get => alapEletero;  }
        public int AlapSzebzés { get => alapSzebzés;  }
        public int SzintLepeshez { get => 10 + szint * 5 ;  }
        public int MaxEletero { get => alapEletero + szint * 3 ;  }


        public void MegKuzd(Harcos masikharcos) 
        {
        }
        public void Gyogyul()
        { 
        }
        public override string ToString()
        {
            return base.ToString();
        }



    }
}
