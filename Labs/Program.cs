public class Product
{
    public String Name { get; set; }
    public float Price { get; set; }
    public int Code { get; set; }

    public Product(string name, float price, int code)
    {
        try
        {
            if(name == "" || name == null)
            {
                throw new Exception("Name cannot be null/empty");
            }
            Name = name;
            if(price <= 0)
            {
                throw new Exception("Price must be greater than 0");
            }
            Price = price;
            Code = code;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}

public class VendingMachine
{
    private int SerialNumber { get; set; }
    private Dictionary<int, int> MoneyFloat { get; set; } = new Dictionary<int, int>();
    private Dictionary<Product, int> Inventory { get; set; } = new Dictionary<Product, int>();
    public readonly string Barcode;
    public List<Product> products { get; set; } = new List<Product>();
    public int Counter = 0;

    public VendingMachine() // constructor
    {
        SerialNumber = Counter++;
        MoneyFloat = new Dictionary<int, int>();
        Inventory = new Dictionary<Product, int>();

    }

    public VendingMachine(string barcode) // constructor with barcode
    {
        try
        {
            SerialNumber = Counter++;
            MoneyFloat = new Dictionary<int, int>();
            Inventory = new Dictionary<Product, int>();
            
            if(barcode == "")
            {
                throw new Exception("Barcode cannot be empty");
            }
            Barcode = barcode;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void StockItem(Product product, int quantity) // Add products to the vending machine, if the product already exists the add the new quantityelse add the new product with the new quantity
    {
        try
        {
            if(quantity <= 0)
            {
                throw new Exception("Quantity must greater than 0");
            }

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
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void StockFloat(int moneyDenomination, int quantity) // Add money
    {
        MoneyFloat.Add(moneyDenomination, quantity);
    }

    public void VendItem(string code, List<int> money)
    {
        try
        {
            List<Product> products = Inventory.Keys.ToList();
            Product p = products[0];
            bool itemFound = false;
            for (int i = 0; i < products.Count; i++)
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
                throw new Exception($"Error: No item found with code {code}");
            }
            if (Inventory[p] == 0)
            {
                throw new Exception($"Error: Item is out of stock");
            }

            float moneyProvided = 0;
            for (int i = 0; i < money.Count; i++)
            {
                moneyProvided += money[i];
            }
            if (moneyProvided < p.Price)
            {
                throw new Exception($"Error : Insufficient balance");
            }

            Console.WriteLine($"Enjoy your {p.Name} and here is your change of {p.Price}");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


    }
   
}



// I did my own reseach for error handeling from Youtube. Didn't copy anything straight from it. 

