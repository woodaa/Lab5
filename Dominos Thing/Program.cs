using System;

namespace Dominos_Thing
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        

        public class Domino
        {
            private int side1;
            private int side2;
            public Domino()
            {
                Side1 = 0;
                Side2 = 0;
            }


            public Domino(int s1, int s2)
            {
                Side1 = s1;
                Side2 = s2;
            }

            public int Side1
            {
                get
                {
                    return Side1;
                }
                set
                {
                    if (value >= 0 && value <= 12)
                        Side1 = value;
                    else
                        throw new ArgumentException("Value must be between 1 and 13");

                }
            }



            public int Side2
            {
                get
                {
                    return side2;
                }
                set
                {
                    if (value >= 0 && value <= 12)
                        side2 = value;
                    else
                        throw new ArgumentException("Value must be between 1 and 13");

                }

            }
            public void Flip()
            {
                int temp = side1;
                side1 = side2;
                side2 = temp;
            }
            public bool IsDouble() => (side1 == side2) ? true : false;

            public override string ToString()
            {
                return String.Format("Side 1: {0} Side 2: {1},", side1, side2);
            }
            public override bool Equals(object obj)
            {
                {
                    if (obj == null)
                        return false;
                    else
                    {
                        Domino d = (Domino)obj;
                        if (d.Side1 == this.Side1 && d.Side2 == this.Side2)
                            return true;
                        else
                            return false;
                    }
                }
            }
            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }
        }
        

    }
}
