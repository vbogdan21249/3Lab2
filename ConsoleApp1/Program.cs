using System.Collections;
using System.Security.Principal;
using goods;
using binary_tree;
using System.Drawing;

public class Program
{
    static public void InOrder<T>(BinaryTreeNode<T>? current) where T : IComparable<T>
    {
        if (current == null)
        {
            return;
        }
        InOrder(current?.Left);
        Console.WriteLine(current!.Data.ToString());
        InOrder(current?.Right);
    }

    static void Main()
    {
        // Generic collection List<T>
        newParagraph("Generic collection List<T>:", ConsoleColor.Green);
        Console.WriteLine("===========================\n");
        List<Goods> goodsList =
        [
            new Goods("Brake disc", "TRW", 1237, 32),
            new Goods("Brake disc", "Remsa", 1349, 23),
            new Goods("Brake liquid", "Bosch", 171, 76)
        ];
        goodsList.Insert(2, new Goods("Brake disc", "Remsa", 1048, 35));
        goodsList.Add(new Goods("Brake liquid", "Ferodo", 239, 45));

        foreach (var goods in goodsList.Where(g => g.manufacture == "Remsa"))
        {
            goods.ValueToIncrease(20);
        }

        newParagraph("   Searching element with Code 3: ");

        Goods? goodsToFind = goodsList.FirstOrDefault(g => g != null && g.code == 3);
        Console.WriteLine(goodsToFind?.Display());

        Goods? goodsToDelete = goodsList.FirstOrDefault(g => g != null && g.code == 3);
        goodsList.Remove(goodsToDelete);

        newParagraph("   List output: ");
        foreach (Goods goods in goodsList)
        {
            if (goods != null)
            {
                Console.WriteLine(goods.Display());
            }
        }

        Console.WriteLine();

        // Non-generic collection List<T>
        newParagraph("Non-Generic List<T>:", ConsoleColor.Green);
        Console.WriteLine("===========================\n");

        ArrayList goodsArrList =
        [
            new Goods("Brake disc", "TRW", 1237, 32),
            new Goods("Brake disc", "Remsa", 1349, 23),
            new Goods("Brake liquid", "Bosch", 171, 76),
            new Goods("Brake disc", "Remsa", 1048, 35)
            ];
        goodsArrList.Add(new Goods("Brake liquid", "Ferodo", 239, 45));

        foreach (var goods in goodsArrList.OfType<Goods>().Where(g => g.manufacture == "Remsa"))
        {
            goods.ValueToIncrease(20);
        }

        newParagraph("   Searching element with code 8:");

        Console.WriteLine(goodsArrList.OfType<Goods>().FirstOrDefault(g => g.code == 8)?.Display());
        goodsArrList.Remove(goodsArrList.OfType<Goods>().FirstOrDefault(g => g.code == 8));
        newParagraph("   List output: ");
        foreach (Goods goods in goodsArrList)
        {
            if (goods != null)
            {
                Console.WriteLine(goods.Display());
            }
        }

        // Array
        newParagraph("Array:", ConsoleColor.Green);
        Console.WriteLine("===========================\n");
        Goods?[] goodsArr = new Goods[5];
        goodsArr[0] = new Goods("Brake disc", "TRW", 1237, 32);
        goodsArr[1] = new Goods("Brake disc", "Remsa", 1349, 23);
        goodsArr[2] = new Goods("Brake liquid", "Bosch", 171, 76);
        goodsArr[3] = new Goods("Brake disc", "Remsa", 1048, 35);
        goodsArr[4] = new Goods("Brake liquid", "Ferodo", 239, 45);

        // searching element with code 3
        newParagraph("   Searching element with code 11:");
        Console.WriteLine(goodsArr.FirstOrDefault(g => g != null && g.code == 11).Display());

        for (int i = 0; i < 5; i++)
        {
            if (goodsArr[i] != null && goodsArr[i].code == 11)
            {
                goodsArr[i] = null;
                break;
            }
        }
        newParagraph("   List output: ");
        foreach (var goods in goodsArr)
        {
            if (goods != null)
            {
                Console.WriteLine(goods.Display());
            }
        }
        newParagraph("Binary Tree: ", ConsoleColor.Green);
        Console.WriteLine("===========================\n");

        BinaryTree<Goods> BinaryTree = new();
        BinaryTree.Insert(new Goods("Brake disc", "TRW", 1237, 32));
        BinaryTree.Insert(new Goods("Brake disc", "Remsa", 1349, 23));
        BinaryTree.Insert(new Goods("Brake liquid", "Bosch", 171, 76));
        BinaryTree.Insert(new Goods("Brake disc", "Remsa", 1048, 35));
        BinaryTree.Insert(new Goods("Brake liquid", "Ferodo", 239, 45));
        foreach (Goods goods in BinaryTree)
        {
            if (goods != null)
            {
                Console.WriteLine(goods.Display());
            }
        }
        newParagraph("   Binary Tree inorder:", ConsoleColor.Red);
        InOrder(BinaryTree.Root);
    }

    public static void newParagraph(string text, ConsoleColor color = ConsoleColor.Red)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}
