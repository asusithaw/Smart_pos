using DBManipulations.Entities;
using DBManipulations;
using NHibernate;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Customer");
            Console.WriteLine("2. Product Category");
            Console.WriteLine("Type 'end' to exit.");
            Console.Write("Enter your choice: ");

            var input = Console.ReadLine();

            if (input.ToLower() == "end")
            {
                Console.WriteLine("The program has ended.");
                break;
            }

            if (input != "1" && input != "2")
            {
                Console.WriteLine("Please input the appropriate menu number.");
                continue;
            }
                        
            if (int.TryParse(input, out var number))
            {
                switch (number)
                {
                    case 1:
                        HandleCustomerMenu();
                        break;
                    case 2:
                        HandleProductCategoryMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1 or 2.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    private static void HandleCustomerMenu()
    {
        while (true)
        {
            Console.WriteLine("Customer Menu");
            Console.WriteLine("1. List Customers");
            Console.WriteLine("2. Add Customer");
            Console.WriteLine("3. Delete Customer");
            Console.WriteLine("4. Back to previous menu");
            Console.Write("Enter your choice: ");

            var input = Console.ReadLine();

            if (input == "4")
            {
                break;
            }
            
            if (int.TryParse(input, out var number))
            {
                switch (number)
                {
                    case 1:
                        ListCustomers();
                        break;
                    case 2:
                        AddCustomer();
                        break;
                    case 3:
                        DeleteCustomer();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    private static void HandleProductCategoryMenu()
    {
        while (true)
        {
            Console.WriteLine("Product Category Menu");
            Console.WriteLine("1. List Product Categories");
            Console.WriteLine("2. Add Product Category");
            Console.WriteLine("3. Delete Product Category");
            Console.WriteLine("4. Back to previous menu");
            Console.Write("Enter your choice: ");

            var input = Console.ReadLine();

            if (input == "4")
            {
                break;
            }
            
            if (int.TryParse(input, out var number))
            {
                switch (number)
                {
                    case 1:
                        ListProductCategories();
                        break;
                    case 2:
                        AddProductCategory();
                        break;
                    case 3:
                        DeleteProductCategory();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    private static void ListCustomers()
    {
        Console.WriteLine("Id | Name | Address");

        using (ISession session = NHibernateHelper.OpenSession())
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                foreach(Customer customer in session.Query<Customer>())
                {
                    Console.WriteLine(customer.Id+" "+customer.Name+" "+customer.Address);
                }
            }
        }
    }

    private static void AddCustomer()
    {
        Console.Write("Name: ");
        var name = Console.ReadLine();

        Console.Write("Address: ");
        var address = Console.ReadLine();       

        using (ISession session = NHibernateHelper.OpenSession())
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                var customer = new Customer
                {
                    Name = name,
                    Address = address,                   
                };

                session.Save(customer);
                transaction.Commit();
            }
        }

        Console.WriteLine("Customer added successfully.");
    }

    private static void DeleteCustomer()
    {
        Console.Write("Enter Customer Id to delete: ");
        var input = Console.ReadLine();

        if (int.TryParse(input, out var customerId))
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    var customer = session.Get<Customer>(customerId);

                    if (customer != null)
                    {
                        session.Delete(customer);
                        transaction.Commit() ;
                        Console.WriteLine("Customer {0} deleted Successfully", customer.Name);
                    }
                    else
                    {
                        Console.WriteLine("{0} The Customer Id is not found", customerId);
                    }
                        
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }



    }

    private static void ListProductCategories()
    {
        Console.WriteLine("Id | Name ");

        using (ISession session = NHibernateHelper.OpenSession())
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                foreach (var productCategory in session.Query<ProductCategory>())
                {
                    Console.WriteLine(productCategory.Id + " " + productCategory.Name);
                }
            }
        }
    }

    private static void AddProductCategory()
    {
        Console.Write("Name: ");
        var name = Console.ReadLine();       

        using (ISession session = NHibernateHelper.OpenSession())
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                var productCategory = new ProductCategory
                {
                    Name = name                
                };

                session.Save(productCategory);
                transaction.Commit();
            }
        }

        Console.WriteLine("Product Category added successfully.");
    }

    private static void DeleteProductCategory()
    {
        Console.Write("Enter Product Category Id to delete: ");
        var input = Console.ReadLine();

        if (int.TryParse(input, out var productCategoryId))
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var productCategory = session.Get<ProductCategory>(productCategoryId);

                    if (productCategory != null)
                    {
                        session.Delete(productCategory);
                        transaction.Commit();
                        Console.WriteLine("Product Category {0} deleted Successfully", productCategory.Name);
                    }
                    else
                    {
                        Console.WriteLine("{0} The Product Id is not found", productCategoryId);
                    }

                }
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
}
