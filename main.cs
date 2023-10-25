// A simple Material Inventory Management System using C#
using System;
using System.Collections.Generic;

class Material
{
    public int MaterialNumber { get; set; }
    public string MaterialName { get; set; }
    public string Specification { get; set; }
    public string Type { get; set; }
    public string MeasurementUnit { get; set; }
}

class InboundMaterial
{
    public int MaterialNumber { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public string SupplierName { get; set; }
}

class OutboundMaterial
{
    public int MaterialNumber { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public string CustomerName { get; set; }
}

class MaterialInventoryManagementSystem
{
    static List<Material> materials = new List<Material>();
    static List<InboundMaterial> inboundMaterials = new List<InboundMaterial>();
    static List<OutboundMaterial> outboundMaterials = new List<OutboundMaterial>();

    static void Main(string[] args)
    {
        bool loggedIn = false;
        while (!loggedIn)
        {
            Console.WriteLine("Login");
            Console.WriteLine("-----");
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            loggedIn = Login(username, password);
            if (!loggedIn)
            {
                Console.WriteLine("Invalid username or password. Please try again.");
                Console.WriteLine("");
            }
        }

        Console.WriteLine("");
        Console.WriteLine("Welcome to Material Inventory Management System");
        Console.WriteLine("-----------------------------------------------");

        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Input basic information about materials");
            Console.WriteLine("2. Query and modify basic material information");
            Console.WriteLine("3. Input inbound material information");
            Console.WriteLine("4. Query and modify inbound material information");
            Console.WriteLine("5. Input outbound material information");
            Console.WriteLine("6. Query and modify outbound material information");
            Console.WriteLine("7. Query material balance information");
            Console.WriteLine("8. Browse material balance information");
            Console.WriteLine("9. Logout");
            Console.WriteLine("");

            string input = Console.ReadLine();
            int option;
            if (int.TryParse(input, out option))
            {
                switch (option)
                {
                    case 1:
                        InputBasicMaterialInfo();
                        break;
                    case 2:
                        QueryAndModifyBasicMaterialInfo();
                        break;
                    case 3:
                        InputInboundMaterialInfo();
                        break;
                    case 4:
                        QueryAndModifyInboundMaterialInfo();
                        break;
                    case 5:
                        InputOutboundMaterialInfo();
                        break;
                    case 6:
                        QueryAndModifyOutboundMaterialInfo();
                        break;
                    case 7:
                        QueryMaterialBalanceInfo();
                        break;
                    case 8:
                        BrowseMaterialBalanceInfo();
                        break;
                    case 9:
                        Logout();
                        return;
                    default:
                        Console.WriteLine("Invalid option selected.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
    
    //Login to the system
    static bool Login(string username, string password)
    {
        // TODO: Implement login logic here.
        // For now, we just hardcode a username and password.
        return username == "fahim" && password == "fahim999";
    }

    //Input of basic information about materials
    static void InputBasicMaterialInfo()
    {
        Console.WriteLine("Enter Material Number:");
        int materialNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Material Name:");
        string materialName = Console.ReadLine();
        Console.WriteLine("Enter Specification:");
        string specification = Console.ReadLine();
        Console.WriteLine("Enter Type:");
        string type = Console.ReadLine();
        Console.WriteLine("Enter Measurement Unit:");
        string measurementUnit = Console.ReadLine();

        Material material = new Material()
        {
            MaterialNumber = materialNumber,
            MaterialName = materialName,
            Specification = specification,
            Type = type,
            MeasurementUnit = measurementUnit
        };

        materials.Add(material);

        Console.WriteLine("Material added successfully!");
    }

    //Query and modification of basic material information
    static void QueryAndModifyBasicMaterialInfo()
    {
        Console.WriteLine("Enter Material Number or Material Name:");
        string searchKey = Console.ReadLine();

        Material material = materials.Find(m => m.MaterialNumber.ToString() == searchKey || m.MaterialName == searchKey);

        if (material == null)
        {
            Console.WriteLine("Material not found");
        }
        else
        {
            Console.WriteLine($"Material Number: {material.MaterialNumber}");
            Console.WriteLine($"Material Name: {material.MaterialName}");
            Console.WriteLine($"Specification: {material.Specification}");
            Console.WriteLine($"Type: {material.Type}");
            Console.WriteLine($"Measurement Unit: {material.MeasurementUnit}");
            Console.WriteLine("Do you want to modify the material information? (Y/N)");
            string modify = Console.ReadLine();

            if (modify.ToUpper() == "Y")
            {
                Console.WriteLine("Enter new Material Name:");
                string materialName = Console.ReadLine();
                Console.WriteLine("Enter new Specification:");
                string specification = Console.ReadLine();
                Console.WriteLine("Enter new Type:");
                string type = Console.ReadLine();
                Console.WriteLine("Enter new Measurement Unit:");
                string measurementUnit = Console.ReadLine();

                material.MaterialName = materialName;
                material.Specification = specification;
                material.Type = type;
                material.MeasurementUnit = measurementUnit;

                Console.WriteLine("Material information updated successfully!");
            }
        }
    }

    //Input of inbound material information
    static void InputInboundMaterialInfo()
    {
        Console.WriteLine("Enter Material Number:");
        int materialNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Quantity:");
        int quantity = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Date (yyyy-MM-dd):");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Enter Supplier Name:");
        string supplierName = Console.ReadLine();

        InboundMaterial inboundMaterial = new InboundMaterial()
        {
            MaterialNumber = materialNumber,
            Quantity = quantity,
            Date = date,
            SupplierName = supplierName
        };

        inboundMaterials.Add(inboundMaterial);

        Console.WriteLine("Inbound material added successfully!");
    }


    //Query and modification of inbound material information
    static void QueryAndModifyInboundMaterialInfo()
    {
        Console.WriteLine("Enter Material Number:");
        int materialNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Date (yyyy-MM-dd):");
        DateTime date = DateTime.Parse(Console.ReadLine());

        InboundMaterial inboundMaterial = inboundMaterials.Find(im => im.MaterialNumber == materialNumber && im.Date == date);

        if (inboundMaterial == null)
        {
            Console.WriteLine("Inbound material not found");
        }
        else
        {
            Console.WriteLine($"Material Number: {inboundMaterial.MaterialNumber}");
            Console.WriteLine($"Quantity: {inboundMaterial.Quantity}");
            Console.WriteLine($"Date: {inboundMaterial.Date:yyyy-MM-dd}");
            Console.WriteLine($"Supplier Name: {inboundMaterial.SupplierName}");
            Console.WriteLine("Do you want to modify the inbound material information? (Y/N)");
            string modify = Console.ReadLine();

            if (modify.ToUpper() == "Y")
            {
                Console.WriteLine("Enter new Quantity:");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new Date (yyyy-MM-dd):");
                DateTime newDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter new Supplier Name:");
                string supplierName = Console.ReadLine();

                inboundMaterial.Quantity = quantity;
                inboundMaterial.Date = newDate;
                inboundMaterial.SupplierName = supplierName;

                Console.WriteLine("Inbound material information updated successfully!");
            }
        }
    }

    //Input of outbound material information
    static void InputOutboundMaterialInfo()
    {
        Console.WriteLine("Enter Material Number:");
        int materialNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Quantity:");
        int quantity = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Date (yyyy-MM-dd):");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Enter Customer Name:");
        string customerName = Console.ReadLine();

        OutboundMaterial outboundMaterial = new OutboundMaterial()
        {
            MaterialNumber = materialNumber,
            Quantity = quantity,
            Date = date,
            CustomerName = customerName
        };

        outboundMaterials.Add(outboundMaterial);

        Console.WriteLine("Outbound material added successfully!");
    }

    //Query and modification of outbound material information
    static void QueryAndModifyOutboundMaterialInfo()
    {
        Console.WriteLine("Enter Material Number:");
        int materialNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Date (yyyy-MM-dd):");
        DateTime date = DateTime.Parse(Console.ReadLine());

        OutboundMaterial outboundMaterial = outboundMaterials.Find(om => om.MaterialNumber == materialNumber && om.Date == date);

        if (outboundMaterial == null)
        {
            Console.WriteLine("Outbound material not found");
        }
        else
        {
            Console.WriteLine($"Material Number: {outboundMaterial.MaterialNumber}");
            Console.WriteLine($"Quantity: {outboundMaterial.Quantity}");
            Console.WriteLine($"Date: {outboundMaterial.Date:yyyy-MM-dd}");
            Console.WriteLine($"Customer Name: {outboundMaterial.CustomerName}");
            Console.WriteLine("Do you want to modify the outbound material information? (Y/N)");
            string modify = Console.ReadLine();

            if (modify.ToUpper() == "Y")
            {
                Console.WriteLine("Enter new Quantity:");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new Date (yyyy-MM-dd):");
                DateTime newDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter new Customer Name:");
                string customerName = Console.ReadLine();

                outboundMaterial.Quantity = quantity;
                outboundMaterial.Date = newDate;
                outboundMaterial.CustomerName = customerName;

                Console.WriteLine("Outbound material information updated successfully!");
            }
        }
    }

    //Query of material balance information
    static void QueryMaterialBalanceInfo()
    {
        Console.WriteLine("Enter Material Number:");
        int materialNumber = int.Parse(Console.ReadLine());

        Material material = materials.Find(m => m.MaterialNumber == materialNumber);

        if (material == null)
        {
            Console.WriteLine("Material not found");
        }
        else
        {
            int inboundQuantity = inboundMaterials.Where(im => im.MaterialNumber == materialNumber).Sum(im => im.Quantity);
            int outboundQuantity = outboundMaterials.Where(om => om.MaterialNumber == materialNumber).Sum(om => om.Quantity);
            int balance = inboundQuantity - outboundQuantity;

            Console.WriteLine($"Material Number: {material.MaterialNumber}");
            Console.WriteLine($"Material Name: {material.MaterialName}");
            Console.WriteLine($"Measurement Unit: {material.MeasurementUnit}");
            Console.WriteLine($"Inbound Quantity: {inboundQuantity}");
            Console.WriteLine($"Outbound Quantity: {outboundQuantity}");
            Console.WriteLine($"Balance: {balance}");
        }
    }

    //Browsing of material balance information
    static void BrowseMaterialBalanceInfo()
    {
        Console.WriteLine("Material Balance:");

        foreach (Material material in materials)
        {
            int inboundQuantity = 0;
            int outboundQuantity = 0;

            foreach (InboundMaterial inbound in inboundMaterials)
            {
                if (inbound.MaterialNumber == material.MaterialNumber)
                {
                    inboundQuantity += inbound.Quantity;
                }
            }

            foreach (OutboundMaterial outbound in outboundMaterials)
            {
                if (outbound.MaterialNumber == material.MaterialNumber)
                {
                    outboundQuantity += outbound.Quantity;
                }
            }

            int balance = inboundQuantity - outboundQuantity;

            Console.WriteLine($"Material: {material.MaterialName}, Balance: {balance}");
        }
    }

    //Logout from the system
    static void Logout()
    {
        Console.WriteLine("Logout successfully!");
    }
}
