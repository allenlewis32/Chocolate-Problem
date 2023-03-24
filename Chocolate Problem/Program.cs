namespace Chocolate_Problem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChocolateDispenser chocolateDispenser = new ChocolateDispenser();
            chocolateDispenser.AddChocolates(Color.Red, 7);
            chocolateDispenser.Display();
            chocolateDispenser.AddChocolates(Color.Green, 5);
            chocolateDispenser.Display();
            chocolateDispenser.RemoveChocolates(2);
            chocolateDispenser.Display();
            chocolateDispenser.DispenseChocolates(2);
            chocolateDispenser.Display();
            chocolateDispenser.DispenseChocolatesOfColor(1, Color.Red);
            chocolateDispenser.Display();
            foreach(int n in chocolateDispenser.NoOfChocolates()) Console.WriteLine(n);
            chocolateDispenser.SortChocolateBasedOnCount();
            chocolateDispenser.Display();
            chocolateDispenser.ChangeChocolateColor(2, Color.Green, Color.Silver);
            chocolateDispenser.Display();
            chocolateDispenser.ChangeColorAllOfXCount(Color.Silver, Color.Crimson);
            chocolateDispenser.Display();
            chocolateDispenser.RemoveChocolateOfColor(Color.Crimson);
            chocolateDispenser.Display();
        }
    }
}