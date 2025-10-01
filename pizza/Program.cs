using static System.Console;
internal class Program {
    static double price = 0;
    static void Menu() {
        Write("\x1b[?1049hWelcome to the Pizza Ordering Service [POS]. Enter choice below:\n1: Pizza size\n2: Toppings\n3: Sides\n4: Drinks\n5: Discount\n% ");
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
        }
    }
    static void Main() {
        Menu();
    }
    static void Size() {
        Write("Enter size:\n1: Small [£3.50]\n2: Medium [£5]\n3: Large [£7.25]");
        price+=ReadLine()!.ToLower() switch {
            "small" => 3.5,
            "medium" => 5,
            "large" => 7.25,
            _ => throw new ArgumentNullException("\x1b[91mERROR:\x1b[0m ANSWER IS INVALID"),
        };
        Menu();
    }
    static void Toppings() {
        Write("Enter a comma-separated list of toppings:\n1: Tomatoes [£1.50]\n2: Mushrooms [£2]\n3: Sweetcorn [£1]\n4: Peppers [£1.25]\n5: Onions [£1.50]\n% ");
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
    }
    static void Sides() {
        Write("Enter a comma-separated list of sides:\n1: Garlic bread [£1.50]\n2: Fries [£2]\n3: Halloumi [£2.50]\n4: Mozzarella sticks [£2]\n5: Onion rings [£1.50]\n% ");
        string[] sides = ReadLine()!.Split(",");
        foreach (var i in sides) {
            foreach (var j in sides) { 
                if (i == j) throw new ArgumentNullException("\x1b[91mERROR:\x1b[0m NO DUPLICATE CHOICES");
            }
        }
        foreach (var i in sides) {
            price += i switch {
                "1"=>1.5,
                "2"=>2,
                "3"=>2.5,
                "4"=>2,
                "5"=>1.5,
                _=>throw new ArgumentNullException("\x1b[91mERROR:\x1b[0m ANSWER IS INVALID"),
            };
        }
    }
}
