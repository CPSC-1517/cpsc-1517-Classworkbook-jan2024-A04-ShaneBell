using WestWindSystem.DAL;
using WestWindSystem.Entities;

WestWindContext context = new WestWindContext();

foreach(Customer aCustomer in context.Customers)
{
    Console.WriteLine(aCustomer.ContactName);
}

Customer firstCustomer = context.Customers.First();
Console.WriteLine($"The first customer is: {firstCustomer.ContactName}");
