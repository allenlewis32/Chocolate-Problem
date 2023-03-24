using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate_Problem
{
    class CompareList: IComparer<List<Chocolate>> {
        public int Compare(List<Chocolate> list, List<Chocolate> list2)
        {
            return list.Count - list2.Count;
        }
    }
    internal class ChocolateDispenser
    {
        List<Chocolate> chocolates;
        internal ChocolateDispenser()
        {
            chocolates = new List<Chocolate>();
        }
        internal void AddChocolates(Color color, int count)
        {
            for(int i = 0; i < count; i++)
            {
                chocolates.Add(new Chocolate(color));
            }
        }
        internal List<Chocolate> RemoveChocolates(int count)
        {
            if(count < 0)
            {
                throw new Exception("count must be non-negative");
            }
            if(count > chocolates.Count)
            {
                throw new Exception("Not enough chocolates to remove");
            }
            List<Chocolate> removed = new List<Chocolate> ();
            int listLen = chocolates.Count;
            for(int i = 0; i < count; i++)
            {
                removed.Add(chocolates[listLen - 1 - i]);
            }
            chocolates.RemoveRange(listLen - count, count);
            return removed;
        }
        internal List<Chocolate> DispenseChocolates(int count)
        {
            if (count < 0)
            {
                throw new Exception("count must be non-negative");
            }
            if (count > chocolates.Count)
            {
                throw new Exception("Not enough chocolates to remove");
            }
            List<Chocolate> dis = new List<Chocolate>();
            for(int i = 0; i < count; i++)
            {
                dis.Add(chocolates[i]);
            }
            chocolates.RemoveRange(0, count);
            return dis;
        }
        internal List<Chocolate> DispenseChocolatesOfColor(int n, Color color)
        {
            List<Chocolate> chocolatesOfColor = new List<Chocolate>();
            foreach(Chocolate chocolate in chocolates)
            {
                if(chocolate.Color == color)
                {
                    chocolatesOfColor.Add(chocolate);
                    chocolates.Remove(chocolate);
                    n--;
                    if (n == 0) break;
                }
            }
            return chocolatesOfColor;
        }
        internal int[] NoOfChocolates()
        {
            int[] nos = new int[7];
            foreach(Chocolate chocolate in chocolates)
            {
                nos[(int)chocolate.Color]++; // Color enum is in the order green, silver, blue, crimson, purple, red, pink
            }
            return nos;
        }
        internal void SortChocolateBasedOnCount()
        {
            List<Chocolate>[] chocolateByColors = new List<Chocolate>[7];
            for (int i = 0; i < chocolateByColors.Length; i++) chocolateByColors[i] = new List<Chocolate>();
            foreach(Chocolate chocolate in chocolates)
            {
                chocolateByColors[(int)chocolate.Color].Add(chocolate);
            }
            Array.Sort(chocolateByColors, new CompareList());
            chocolates.Clear();
            foreach(List<Chocolate> cs in chocolateByColors)
            {
                chocolates.AddRange(cs);
            }
        }
        internal void ChangeChocolateColor(int count, Color color, Color newColor)
        {
            foreach(Chocolate chocolate in chocolates)
            {
                if(chocolate.Color == color)
                {
                    chocolate.Color = newColor;
                    count--;
                    if(count == 0)
                    {
                        break;
                    }
                } else if(chocolate.Color == newColor)
                {
                }
            }
            if(count != 0)
            {
                throw new Exception("Not enough chocolates to convert");
            }
        }
        internal Tuple<int, List<Chocolate>> ChangeColorAllOfXCount(Color color, Color newColor)
        {
            ChangeChocolateColor(NoOfChocolates()[(int)color], color, newColor);
            int n = NoOfChocolates()[(int)newColor];
            List<Chocolate> chocolates = DispenseChocolatesOfColor(n, color);
            return new Tuple<int, List<Chocolate>>(n, chocolates);
        }
        internal Chocolate RemoveChocolateOfColor(Color color)
        {
            for(int i = chocolates.Count - 1; i >= 0; i--)
            {
                if (chocolates[i].Color == color)
                {
                    Chocolate chocolate = chocolates[i];
                    chocolates.Remove(chocolate);
                    return chocolate;
                }
            }
            throw new Exception($"No {color}-colored chocolate exists");
        }
        internal void Display()
        {
            Console.Write("Chocolates: ");
            foreach(Chocolate chocolate in chocolates)
            {
                Console.Write(chocolate.Color + " ");
            }
            Console.WriteLine();
        }
    }
}
