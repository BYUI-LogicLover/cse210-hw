class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Saratoga Springs", "UT", "USA");
        Address address2 = new Address("456 Oak Ave", "Otherville", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create products
        Product product1 = new Product("Laptop", "P001", 1200.00, 1);
        Product product2 = new Product("Mouse", "P002", 25.00, 2);
        Product product3 = new Product("Keyboard", "P003", 75.00, 1);
        Product product4 = new Product("Monitor", "P004", 300.00, 1);
        Product product5 = new Product("Webcam", "P005", 50.00, 1);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product2);

        
        List<Order> orders = new List<Order> { order1, order2 };
        int orderNumber = 1;
        foreach (var order in orders)
        {
            Console.WriteLine($"Order #{orderNumber}:\n");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.CalculateTotalCost():F2}\n");
            Console.WriteLine("----------------------------------------\n");
            orderNumber++;
        }
    }
}