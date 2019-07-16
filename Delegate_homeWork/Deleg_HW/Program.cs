using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deleg_HW
{
    class Program
    {
        public delegate int Sade(int n);
        static void Main(string[] args)
        {
            #region Card
            Card card = new Card(200);
            card.NotEnoughMoney += (money) =>
            {
                Console.WriteLine("Balansda kif qeder vesait yoxdur");
            };
            card.GetMoney(260);
            #endregion


            myNumber num = new myNumber();
            num.SadeEded += delegate (int n)
            {
                Console.WriteLine($"{n} ededi sade ededdir");
            };
            num.MenfiEded += (int n) =>
              {
                  Console.WriteLine($"{n} ededi menfi ededdir");
              };
            num.CutEded += (int n) =>
             {
                 Console.WriteLine($"{n} ededi cut ededdir");
             };
            num.Sade(4);
            num.Menfi(-7);
            num.Cut(5);
        }
    }
    #region Card
    public class Card
    {
        public event Action<double> NotEnoughMoney;
        public float Money { get; private set; }

        public Card(float m)
        {
            Money = m;
        }

        public void GetMoney(float money)
        {
            if (Money >= money)
            {
                Console.WriteLine("Emeliyyat icra olundu, balansinizda " + (Money - money) + " AZN qaldi");
            }
            else
            {
                NotEnoughMoney.Invoke(money);
            }
        }
    }
    #endregion

    public class myNumber
    {
        public event Action<int> SadeEded;
        public event Action<int> MenfiEded;
        public event Action<int> CutEded;
        //public int Number { get; set; }
        //public myNumber(int n)
        //{
        //    Number = n;
        //}
        public void Sade(int n)
        {
            int count = 0;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    count++;
                }
            }
            if (count != 0)
            {
                Console.WriteLine($"{n} ededi murekkeb ededdir");
            }
            else
            {
                SadeEded.Invoke(n);
            }

        }

        public void Menfi(int n)
        {
            if (n >= 0)
            {
                Console.WriteLine($"{n} ededi musbet ededdir");
            }
            else
            {
                MenfiEded.Invoke(n);
            }
        }

        public void Cut(int n)
        {
            if (n % 2 != 0)
            {
                Console.WriteLine($"{n} ededi tek ededdir");
            }
            else
            {
                CutEded.Invoke(n);
            }
        }
    }
}
