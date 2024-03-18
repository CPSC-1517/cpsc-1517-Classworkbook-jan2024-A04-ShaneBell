
#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
using WestWindSystem.BLL;
#endregion

//Creating a context object using the default constructor.
//It will use the connection string in the OnConfiguring method
WestWindContext context = new WestWindContext();

//Instantiate a customerServices Object and pass in the context of where the data is. 
CustomerServices customerServices = new CustomerServices(context);

//Display all the customers contactNames

foreach(Customer aCustomer in customerServices.GetAllCustomers())
{
    Console.WriteLine(aCustomer.ContactName);
}

Customer customer2 = customerServices.GetCustomerById("ALfki");

Console.WriteLine($"ALFKI is {customer2.ContactName}");

//foreach(Customer aCustomer in context.Customers)
//{
//    Console.WriteLine(aCustomer.ContactName);
//}


//Customer firstCustomer = context.Customers.First();
//Console.WriteLine($"The first customer is: {firstCustomer.ContactName}");
