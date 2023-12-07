using System.Drawing;
using System.Transactions;

namespace goods;
public class Goods : IComparable<Goods>
{
    private static int _lastGeneratedId = 0;
    public int code { get; set; }
    public string name { get; set; }
    public string manufacture { get; set; }
    public double cost { get; set; }
    public int quantityInTheLot { get; set; }
    public Goods(string name, string manufacture, double cost, int quantity)
    {
        code = GenerateUniqueId();
        this.name = name;
        this.manufacture = manufacture;
        this.cost = cost;
        quantityInTheLot = quantity;
    }
    public double TotalLotCost(int code)
    {
        double totalLotCost = cost * quantityInTheLot;
        return totalLotCost;
    }
    public void ValueToIncrease(double percentage)
    {
        if (percentage <= 0 || percentage >= 100) return;
        else
        {
            cost += cost * (percentage / 100);
        }

    }
    public double CalculateLotCost()
    {
        return cost * quantityInTheLot;
    }
    public string Display()
    {
        double totalCost = CalculateLotCost();
        return $"\t{name} ({code})\n" +
               $"Manufacture: {manufacture}\n" +
               $"Quantity: {quantityInTheLot}\n" +
               $"Cost: {cost:F2} UAH\n" +
               $"Total cost: {totalCost:F2} UAH\n";
    }

    public int CompareTo(Goods? other)
    {
        return cost.CompareTo(other?.cost);
    }
    private int GenerateUniqueId()
    {
        return ++_lastGeneratedId;
    }
}