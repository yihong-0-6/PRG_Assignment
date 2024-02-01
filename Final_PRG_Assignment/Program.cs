//===============================================================================================================================================================
//Student Number: S10257222
//Student Name: Huang Yi Hong
//Student Number: S10241567
//Student Name: Tan Xin Zheng Zen
//===============================================================================================================================================================
using System;
using System.Diagnostics;
using PRG_Assignment;
using System.Globalization;


List<Customer> cust = new List<Customer>();
Queue<Order> GoldQueue = new Queue<Order>();
Queue<Order> RegularQueue = new Queue<Order>();
List<IceCream> icecream = new List<IceCream>();
List<Order> currentOrder = new List<Order>();
Dictionary<int, string> orderIdToCustomerName = new Dictionary<int, string>();
Dictionary<string, Customer> custDic = new Dictionary<string, Customer>();

string filePath = "customers.csv"; //making a filepath for customer.csv file

while (true)
{
    //displaying option menu
    Console.WriteLine("[1] List all customers");
    Console.WriteLine("[2] List all current orders");
    Console.WriteLine("[3] Register a new customer");
    Console.WriteLine("[4] Create a customer’s order");
    Console.WriteLine("[5] Display order details of a customer");
    Console.WriteLine("[6] Modify order details");
    Console.WriteLine("[7] Process an order and checkout");
    Console.WriteLine("[8] Display monthly charged amounts breakdown & total charged amounts for the year");
    Console.WriteLine("[0] Exit");
    Console.Write("Choose your option: ");

    int option;
    if (int.TryParse(Console.ReadLine(), out option))
    {
        Console.WriteLine("");
        switch (option)
        {
            case 1://option 1: List all customers
                DisplayCustomerList(cust);
                break;

            case 2://option 2: List all current orders                  
                break;

            case 3://option 3: Register a new customer
                RegisterNewCustomer(cust);
                break;

            case 4://option 4: Create a customer's order
                CreateNewOrder(cust, orderIdToCustomerName);

                break;

            case 5://option 5: Display order details of a customer

                break;

            case 6://option 6: Modify order details

                break;

            case 7://option 7: Process an order and checkout

                break;

            case 8://option 8: Display monthly charged amounts breakdown & total charged amounts for the year

                break;

            case 0://option 0: Exit the program
                Console.WriteLine("Exiting the program. Goodbye!");
                return;

            default:
                Console.WriteLine("Invalid option. Please choose a valid option.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a number corresponding to the options.");
    }

    Console.WriteLine(); // Add a newline for better readability
}

//---------------------------------------------------------------------------------------------------------------------------------------------------------------
//Basic Feature 1 - List all customers: S10257222 Huang Yi Hong
//---------------------------------------------------------------------------------------------------------------------------------------------------------------
void DisplayCustomerList(List<Customer> cust) //method to display customer list
{    
    ReadCustomerFile(cust); //calling method to read customer.csv datafile

    Console.WriteLine("Customer List:");
    Console.WriteLine("{0,-15}{1,-11}{2,-16}", "Name", "MemberID", "DOB (dd/MM/yyyy)"); //displaying header

    foreach (Customer customer in cust)
    {
        string formattedDob = customer.Dob.ToString("dd/MM/yyyy");
        Console.WriteLine($"{customer.Name,-15}{customer.Memberid,-11}{formattedDob,-16}"); //displaying customer data
    }
    Console.WriteLine(); //for better readability
}

void ReadCustomerFile(List<Customer> cust) //method to read and store customer.csv datafile
{
    cust.Clear();
    custDic.Clear();
    using (StreamReader sr = new StreamReader(filePath)) //using StreamReader to read file
    {
        string header = sr.ReadLine(); //reading the header
       
        string line;
        while ((line = sr.ReadLine()) != null) //reading the data
        {
            string[] fields = line.Split(','); //spliting the data by comma


            //storing the data
            if (fields.Length == 6)
            {
                string name = fields[0];
                string idString = fields[1];
                string dobString = fields[2];
                string membershiptier = fields[3];
                string points = fields[4];
                string punchcard = fields[5];

                if (int.TryParse(idString, out int id))
                {
                    DateTime dob;

                    //ensuring all DateTime variables are formatted correctly
                    if (!DateTime.TryParse(dobString, out dob))
                    {
                        CultureInfo cultureInfo = CultureInfo.InvariantCulture;
                        if (!DateTime.TryParseExact(dobString, "dd/MM/yyyy", cultureInfo, DateTimeStyles.None, out dob))
                        {
                            Console.WriteLine($"Invalid format for date of birth: {dobString}"); 
                            continue;
                        }
                    }

                    // Successfully parsed, create PointCard object
                    PointCard pc = new PointCard(int.Parse(points), int.Parse(punchcard));
                    pc.Tier = membershiptier;

                    Customer customer = new Customer(name, id, dob);

                    // add pointcard object to customer
                    customer.rewards = pc;

                    cust.Add(customer); //storing data into a list
                    custDic.Add(fields[1], customer); //storing data in a dictionary where memberID is the key
                }
                else
                {
                    continue;
                }
            }
            else
            {
                continue;
            }
        }
    }
}

//---------------------------------------------------------------------------------------------------------------------------------------------------------------
//Basic Feature 2 - List all current orders: S10241567 Tan Xin Zheng Zen
//---------------------------------------------------------------------------------------------------------------------------------------------------------------























//---------------------------------------------------------------------------------------------------------------------------------------------------------------
//Basic Feature 3 - Register a new customer: S10257222 Huang Yi Hong
//---------------------------------------------------------------------------------------------------------------------------------------------------------------
void RegisterNewCustomer(List<Customer> cust)
{
    Console.Write("Enter Name: ");
    string name = Console.ReadLine().ToLower(); //prompt user for Name and convert user input to lowercase
    name = char.ToUpper(name[0]) + name.Substring(1); //capitalizing the Name

    Console.Write("Enter ID (6 digits integer): "); 
    string memberID = Console.ReadLine(); //prompt user for ID

    Customer sameID = cust.Find(c => c.Memberid.ToString() == memberID); //finding for same ID in the customer list

    if (sameID == null) // ensure that ID is unique from others
    {
        if (int.TryParse(memberID, out _) && memberID.Length == 6) //ensure that user input is 6 digit integer
        {            
            DateTime dob; 
            Console.Write("Enter date of birth (dd/MM/yyyy): "); //prompt user for dob and ensuring it is in correct format
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
            {                
                Customer newCustomer = new Customer(name, int.Parse(memberID), dob.Date); //create new Customer object
                                
                PointCard newPointCard = new PointCard(); //create new PointCard object

                newCustomer.rewards = newPointCard; //assign new PointCard to new Customer

                newCustomer.rewards.Tier = "Ordinary"; //starting as Ordinary tier

                //append new Customer details into the file
                string customerInfo = $"{newCustomer.Name},{newCustomer.Memberid},{newCustomer.Dob.Date.ToString("dd/MM/yyyy")},{newCustomer.rewards.Tier},{newCustomer.rewards.Points},{newCustomer.rewards.PunchCard}";

                File.AppendAllLines("customers.csv", new[] { customerInfo });

                //Notification display that customer registered susseccfully
                Console.WriteLine("Customer registered successfully.");
            }
            else
            {
                Console.WriteLine("Invalid date of birth format.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid 6 numerical digit ID.");
        }
    }
    else
    {
        Console.WriteLine("This member ID is already in use.");
    }
}

//---------------------------------------------------------------------------------------------------------------------------------------------------------------
//Basic Feature 4 - Create a customer's order: S10257222 Huang Yi Hong
//---------------------------------------------------------------------------------------------------------------------------------------------------------------
void CreateNewOrder(List<Customer> cust, Dictionary<int, string> orderIdToCustomerName)
{
    DisplayCustomerList(cust); //listing the customers

    while (true)
    {
        // prompt user to select a customer and retrieve the selected customer
        Console.Write("Enter name of customer: "); //prompt user to select a customer
        string inputname = Console.ReadLine().ToLower();
        inputname = char.ToUpper(inputname[0]) + inputname.Substring(1);

        Customer selectedcustomer = cust.Find(c => c.Name == inputname); //retrieving customer

        if (selectedcustomer != null) //ensuring customer exists
        {

            Order currentOrder = selectedcustomer.MakeOrder(); //creating an order object
            int lastOrderId = 1;
            currentOrder.Id += lastOrderId;
            orderIdToCustomerName.Add(currentOrder.Id, selectedcustomer.Name); //adding order to customer name

            Console.WriteLine("Option: "); //display options
            Console.WriteLine("Cup");
            Console.WriteLine("Cone");
            Console.WriteLine("Waffle");
            Console.WriteLine();

            Console.Write("Choose your option: "); //prompt user for their option
            string option = Console.ReadLine().ToLower();
            option = char.ToUpper(option[0]) + option.Substring(1);

            if (option == "Cup")
            {
                List<Flavour> flavours;
                int scoops;
                List<Topping> toppings;
                chooseflavours(out flavours, out scoops);
                choosetoppings(out toppings);


                IceCream newIceCream = new Cup(option, scoops, flavours, toppings); //create an ice cream object

                currentOrder.AddIceCream(newIceCream); //add ice cream to current order
            }

            if (option == "Cone")
            {
                List<Flavour> flavours;
                int scoops;
                chooseflavours(out flavours, out scoops); //calling method to choose flavour

                bool dip = false;
                Console.Write("Is cone dipped? (Y/N): ");
                string dipp = Console.ReadLine().ToUpper(); //check if ice cream is dipped
                if (dipp == "Y")
                {
                    dip = true;
                }
                else if (dipp == "N")
                {
                    dip = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option.");
                    break;
                }

                List<Topping> toppings;
                choosetoppings(out toppings); //calling method to choose toppings

                IceCream newIceCream = new Cone(option, scoops, flavours, toppings, dip); //create an ice cream object

                currentOrder.AddIceCream(newIceCream); //add ice cream to current order
            }

            // if waffle is picked
            if (option == "Waffle")
            {
                List<Flavour> flavours;
                int scoops;
                chooseflavours(out flavours, out scoops);


                Console.WriteLine("Waffle flavour: "); //display waffle flavour
                Console.WriteLine("Red velvet");
                Console.WriteLine("Charcoal");
                Console.WriteLine("Pandan");
                Console.WriteLine();

                Console.Write("Choose waffle flavour: "); //prompt user for waffle flavour
                string waffleflavour = Console.ReadLine().ToLower();
                waffleflavour = char.ToUpper(waffleflavour[0]) + waffleflavour.Substring(1);
                if (waffleflavour == "Red velvet" || waffleflavour == "Charcoal" || waffleflavour == "Pandan") //ensure user input valid waffle flavour
                {
                    List<Topping> toppings;
                    choosetoppings(out toppings);

                    IceCream newIceCream = new Waffle(option, scoops, flavours, toppings, waffleflavour); //create an ice cream object

                    currentOrder.AddIceCream(newIceCream); //add ice cream to current order
                }
                else
                {
                    Console.WriteLine("Please enter a valid flavour.");
                    break;
                }
            }

            Console.WriteLine("Ice cream added to the order.");

            Console.Write("Would you like to add another ice cream? (Y/N): "); //prompt user if want to add another ice cream to order
            string additional = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (additional == "N")
            {
                DateTime current = DateTime.Now;
                currentOrder.TimeReceived = current;

                if (selectedcustomer.rewards.Tier == "Gold") //check for gold tier member
                {
                    GoldQueue.Enqueue(currentOrder); //add to gold queue
                }
                else
                {
                    RegularQueue.Enqueue(currentOrder); //add to regular queue
                }

                break;
            }
            else if (additional != "Y")
            {
                Console.WriteLine("Please enter a valid option.");
                break;
            }

            else
            {
                Console.WriteLine("Customer not found.");
                break;
            }

        }
    }
}

//method to choose flavour
void chooseflavours(out List<Flavour> flavours, out int scoops)
{
    flavours = new List<Flavour>();


    Console.Write("Enter number of scoops of ice cream (min 1, max 3): ");
    scoops = Convert.ToInt32(Console.ReadLine()); //prompt user for number of scoops
    if (scoops >= 1 && scoops <= 3) //ensure input is min 1 and max 3
    {

        Console.WriteLine("Ice cream flavours:"); //display flavour list
        Console.WriteLine("Regular flavours: ");
        Console.WriteLine("Vanilla");
        Console.WriteLine("Chocolate");
        Console.WriteLine("Strawberry");
        Console.WriteLine();
        Console.WriteLine("Premium flavours: ");
        Console.WriteLine("Durian");
        Console.WriteLine("Ube");
        Console.WriteLine("Sea salt");
        Console.WriteLine();

        bool premium = false;
        for (int i = 0; i < scoops; i++) //ensure it ask for the same number of scoops
        {
            Console.Write($"Enter flavour of scoop {i + 1}: ");
            string icecreamflavour = Console.ReadLine().ToLower();
            icecreamflavour = char.ToUpper(icecreamflavour[0]) + icecreamflavour.Substring(1);
                        
            if (icecreamflavour == "Vanilla" || icecreamflavour == "Chocolate" || icecreamflavour == "Strawberry") //check if each flavour is premium
            {
                premium = false;
            }
            else if (icecreamflavour == "Durian" || icecreamflavour == "Ube" || icecreamflavour == "Sea salt")
            {
                premium = true;
            }
            else
            {
                Console.WriteLine("Invalid flavour.");
                i--; //decrease index to input flavour
                continue;
            }

            Flavour existingFlavour = flavours.Find(f => f.Type == icecreamflavour); //checks if the flavour is already in the list
            if (existingFlavour != null) 
            {
                existingFlavour.Quantity++;
            }
            else
            {
                flavours.Add(new Flavour(icecreamflavour, premium, 1)); 
            }
        }
    }
    else
    {
        Console.WriteLine("Please enter a valid number of scoops of ice cream.");
    }
}

//method to choose toppings
void choosetoppings(out List<Topping> toppings)
{
    toppings = new List<Topping>();

    try
    {
        Console.Write("Enter number of toppings (min 0, max 4): ");
        int top = Convert.ToInt32(Console.ReadLine()); //prompt user for number of toppings

        if (top == 0)
        {
            return;
        }
        else if (top >= 1 && top <= 4) //if user choose to add topping
        {
            Console.WriteLine();
            Console.WriteLine("Ice cream toppings: "); //display topping list
            Console.WriteLine("Sprinkles");
            Console.WriteLine("Mochi");
            Console.WriteLine("Sago");
            Console.WriteLine("Oreos");
            Console.WriteLine();
            for (int i = 0; i < top; i++) //ensure it ask for the same number of toppings
            {
                Console.Write($"Enter topping {i + 1}: "); //prompt user for toppings they want
                string icecreamtop = Console.ReadLine().ToLower();
                icecreamtop = char.ToUpper(icecreamtop[0]) + icecreamtop.Substring(1);

                //ensure that user input valid topping names
                if (icecreamtop == "Sprinkles" || icecreamtop == "Mochi" || icecreamtop == "Sago" || icecreamtop == "Oreos")
                {
                    toppings.Add(new Topping(icecreamtop));
                }
                else
                {
                    Console.WriteLine("Invalid topping");
                }
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number of toppings.");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Please enter a valid number.");
    }

}
//---------------------------------------------------------------------------------------------------------------------------------------------------------------
//Basic Feature 5 - Display order details of a customer: S10241567 Tan Xin Zheng Zen
//---------------------------------------------------------------------------------------------------------------------------------------------------------------



















//---------------------------------------------------------------------------------------------------------------------------------------------------------------
//Basic Feature 6 - Modify order details: S10241567 Tan Xin Zheng Zen
//---------------------------------------------------------------------------------------------------------------------------------------------------------------

//===============================================================================================================================================================
//Advanced Feature (a) - Process an order and checkout:
//===============================================================================================================================================================

















