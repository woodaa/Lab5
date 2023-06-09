using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominos_Thing
{
    class BoneYard
    {
        public delegate void EmptyHandler(BoneYard by);
        public event EmptyHandler Empty;

        public void HandleEmpty(BoneYard by)
        {
        }

        private List<Domino> listOfDominos = new List<Domino>();
        public BoneYard(int maxDots)
        {

            for (int leftSide = 0; leftSide <= maxDots; leftSide++)
                for (int rightSide = leftSide; rightSide <= maxDots;)
                    listOfDominos.Add(new Domino(leftSide, rightSide));
            Empty = new EmptyHandler(HandleEmpty);
            
        }
        public int NumDominos
        {
            get
            {
                return listOfDominos.Count;
            }

        }
        public bool IsEmpty
        {
            get
            {
                return (listOfDominos.Count == 0);
            }
        }

        public Domino Draw()
        {
            if (!IsEmpty)
            {
                Domino d = listOfDominos[0];
                listOfDominos.Remove(d);
                return d;
            }
            return null;

        }
        public Domino this[int i]
        {
            get
            {
                return listOfDominos[i];
            }
        }
        public void Shuffle()
        {
            Random gen = new Random();
            for (int i = 0; i < NumDominos; i++)
            {
                int rnd =  gen.Next(0, NumDominos);
                Domino d = listOfDominos[rnd];
            }
        }

        public override string ToString()
        {
            string output = "";
            foreach (Domino d in listOfDominos)
                output += (d.ToString() + "/n");
            return output;
        }








    }


}
