using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using static System.Console;
internal class Program {
    static double price = 0;
    static bool size = false;
    static bool tops = false;
    static bool side = false;
    static bool drnk = false;
    static bool chpskt = false;
    static void Menu() {
        Write($"\x1b[?1049h\x1b[HWelcome to the Pizza Ordering Service [POS]. Enter choice below:\n1: Pizza size{(size == true ? " [DONE]" : "")}\n2: Toppings{(tops == true ? " [DONE]" : "")}\n3: Sides{(side == true ? " [DONE]" : "")}\n4: Drinks{(drnk == true ? " [DONE]" : "")}\n5: Discount{(chpskt == true ? " [DONE]" : "")}\n0: Exit\n% ");
        switch (ReadLine()!) {
            case "1":
                Size();
                break;
            case "2":
                Toppings();
                break;
            case "3":
                Sides();
                break;
            case "4":
                Drinks();
                break;
            case "5":
                Discount();
                break;
            case "0":
                Write(price > 0 ? $"Your price is £{price}\n" : "");
                break;
            default:
                throw new Exception("\x1b[91mERROR:\x1b[0m INVALID CHOICE");
        }
    }
    static void Main() {
        Menu();
    }
    static void Size() {
        if (size) { WriteLine("Already done."); Read(); Menu(); }
        Write("Enter size:\n1: Small [£3.50]\n2: Medium [£5]\n3: Large [£7.25]\n% ");
        price+=ReadLine()! switch {
            "1"=>3.5,
            "2"=>5,
            "3"=>7.25,
            _=>throw new ArgumentNullException("\x1b[91mERROR:\x1b[0m ANSWER IS INVALID"),
        };
        size = true;
        Menu();
    }
    static void Toppings() {
        if (tops) { WriteLine("Already done."); Read(); Menu(); }
        Write("Enter a comma-separated list of toppings [toppings can be repeated]:\n1: Tomatoes [£1.50]\n2: Mushrooms [£2]\n3: Sweetcorn [£1]\n4: Peppers [£1.25]\n5: Onions [£1.50]\n% ");
        string[] toppings = ReadLine()!.Split(",");
        foreach (var i in toppings) {
            price+=i switch {
                "1"=>1.5,
                "2"=>2,
                "3"=>1,
                "4"=>1.25,
                "5"=>1.5,
                _=>throw new ArgumentNullException("\x1b[91mERROR:\x1b[0m ANSWER IS INVALID"),
            };
        }
        tops = true;
        Menu();
    }
    static void Sides() {
        if (side) { WriteLine("Already done."); Read(); Menu(); }
        Write("Enter a comma-separated list of sides:\n1: Garlic bread [£1.50]\n2: Fries [£2]\n3: Halloumi [£2.50]\n4: Mozzarella sticks [£2]\n5: Onion rings [£1.50]\n% ");
        string[] sides = ReadLine()!.Split(",");
        if (sides.GroupBy(x => x).Any(g => g.Count() > 1)) throw new ArgumentNullException("\x1b[91mERROR:\x1b[0m NO DUPLICATE CHOICES");
        foreach (var i in sides) {
            price+=i switch {
                "1"=>1.5,
                "2"=>2,
                "3"=>2.5,
                "4"=>2,
                "5"=>1.5,
                _=>throw new ArgumentNullException("\x1b[91mERROR:\x1b[0m ANSWER IS INVALID"),
            };
        }
        side = true;
        Menu();
    }
    static void Drinks() {
        if (drnk) { WriteLine("Already done."); Read(); Menu(); }
        Write("Enter a comma-separated list of drinks [drinks can be repeated]:\n[cans [all £0.50]]\n1: Coke\n2: Sprite\n3: Fanta\n4: Water [£1]\n5: Ginger beer [£1.50]\n% ");
        string[] drinks = ReadLine()!.Split(",");
        foreach (var i in drinks) {
            price+=i switch {
                var j when Regex.IsMatch(j, @"[1-3]")=>.5,
                "4"=>1,
                "5"=>1.5,
                _=>throw new ArgumentNullException("\x1b[91mERROR:\x1b[0m ANSWER IS INVALID"),
            };
        }
        drnk = true;
        Menu();
    }
    static void Discount() {
        if (chpskt) { WriteLine("Already done."); Read(); Menu(); }
        Write("Enter a discount code for 80% off [format is UU111ll&]\n% ");
        string code = ReadLine()!;
        if (code.Substring(0, 2).ToUpper() == code.Substring(0, 2) && Convert.ToInt32(code.Substring(2, 3)) % 1 == 0 && code.Substring(4, 2).ToLower() == code.Substring(4, 2) && code.Substring(7) == "&") price*=(4/5); else throw new Exception("\x1b[91mERROR:\x1b[0m INVALID CODE");
        chpskt = true;
        Menu();
    }
}
