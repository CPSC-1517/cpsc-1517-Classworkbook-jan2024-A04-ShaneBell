using WestWindSystem.BLL;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

WestWindContext context = new WestWindContext();

CustomerServices customerServices = new CustomerServices(context);

foreach(Customer aCustomer in customerServices.GetAllCustomers())
{
    Console.WriteLine(aCustomer.ContactName);
}

Customer customer = customerServices.GetCustomerByCustomerID("ALFKI");

Console.WriteLine($"The email for customerID ALFKI is {customer.ContactEmail} and the phone number is {customer.Phone}");




//Using the context directly
//foreach(Customer aCustomer in context.Customers)
//{
//    Console.WriteLine(aCustomer.ContactName);
//}
//Create a Class library
//Created folders for BLL,DAL, Entities
//Use EF Core Power Tools to create the entities and the context classes

