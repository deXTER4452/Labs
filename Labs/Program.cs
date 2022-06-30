public class Product
{
    public String Name { get; set; }
    public float Price { get; set; }
    public int Code { get; set; }

    public Product(string name, float price, int code)
    {
        Name = name;
        Price = price;
        Code = code;
    }
}

public class VendingMachine
{
    public int SerialNumber { get; set; }
    public Product Product { get; set; }
    public Dictionary<int, int> MoneyFloat { get; set; } = new Dictionary<int, int>();
    public Dictionary<Product, int> Inventory { get; set; } = new Dictionary<Product, int>();
    public List<Product> products { get; set; } = new List<Product>();
    public VendingMachine(int serialNumber)
    {
        SerialNumber = serialNumber;
        MoneyFloat = new Dictionary<int, int>();
        Inventory = new Dictionary<Product, int>();
    }
    public void StockItem(Product product, int quantity) // Add products to the vending machine, if the product already exists the add the new quantityelse add the new product with the new quantity
    {
        if (Inventory.ContainsKey(product))
        {
            int currentQuantity = Inventory[product];
            Inventory.Add(product, currentQuantity + quantity);
        }
        else
        {
            Inventory.Add(product, quantity);
        }
    }
    public void StockFloat(int moneyDenomination, int quantity) // Add money
    {
        MoneyFloat.Add(moneyDenomination, quantity);
    }

    public void VendItem(string code, List<int> money) // get code and money to vend item from the machine
    {
        List<Product> products = Inventory.Keys.ToList();
        Product p = products[0];
        bool itemFound = false;
        for(int i = 0; i < products.Count; i++)
        {
            if (products[i].Name == code) // i was about to use FullName method here, but VS put in Name method for me and it worked
            {
                itemFound = true;
                p = products[i];
                break;
            }
        }

        if (!itemFound)
        {
            Console.WriteLine($"Error: No item found with code {code}");
        }
        if (Inventory[p] == 0)
        {
            Console.WriteLine($"Error: Item is out of stock");
        }

        float moneyProvided = 0;
        for(int i = 0; i < money.Count; i++)
        {
            moneyProvided += money[i];
        }
        if (moneyProvided < p.Price)
        {
            Console.WriteLine($"Error : Insufficient balance");
        }

        Console.WriteLine($"Enjoy your {p.Name} and here is your change of {p.Price}");


    }
   
}





