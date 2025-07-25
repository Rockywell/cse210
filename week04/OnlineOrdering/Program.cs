using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        // USA Customer
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("Alice Smith", address1);

        Order order1 = new Order(customer1, [
            new Product("Notebook", 101, 4.99, 3),
            new Product("Pen", 220, 1.50, 5)
        ]);

        // International Customer
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Chen", address2);

        Order order2 = new Order(customer2, [
            new Product("Laptop", 332, 999.99, 1),
            new Product("Mouse", 411, 25.00, 2),
            new Product("Keyboard", 529, 75.00, 1)
        ]);


        List<Order> orders = [order1, order2];
        orders.ForEach(order => order.DisplayAll());
    }
}