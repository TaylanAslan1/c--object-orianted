using System;
using System.Collections.Generic;

// Müşteri sınıfı
public class Customer
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}

// Müşteri yöneticisi sınıfı
public class CustomerManager
{
    private List<Customer> customers = new List<Customer>();

    // Yeni müşteri ekleme
    public void AddCustomer(Customer customer)
    {
        customers.Add(customer);
    }

    // Tüm müşterileri listeleme
    public void ListCustomers()
    {
        Console.WriteLine("Müşteri Listesi:");
        foreach (var customer in customers)
        {
            Console.WriteLine($"Adı: {customer.Name}, Soyadı: {customer.LastName}, Adres: {customer.Address}, Telefon: {customer.PhoneNumber}");
        }
    }

    // Belirli bir müşteriyi silme
    public void RemoveCustomer(Customer customer)
    {
        customers.Remove(customer);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Müşteri yöneticisi oluştur
        CustomerManager customerManager = new CustomerManager();

        // Kullanıcı arayüzü
        while (true)
        {
            Console.WriteLine("1. Yeni Müşteri Ekle");
            Console.WriteLine("2. Müşteri Listesini Görüntüle");
            Console.WriteLine("3. Müşteri Sil");
            Console.WriteLine("4. Çıkış");
            Console.Write("Seçiminiz: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Müşteri Adı: ");
                    string name = Console.ReadLine();
                    Console.Write("Müşteri Soyadı: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Müşteri Adresi: ");
                    string address = Console.ReadLine();
                    Console.Write("Müşteri Telefon Numarası: ");
                    string phoneNumber = Console.ReadLine();

                    // Yeni müşteri oluştur
                    Customer newCustomer = new Customer
                    {
                        Name = name,
                        LastName = lastName,
                        Address = address,
                        PhoneNumber = phoneNumber
                    };

                    // Müşteriyi ekle
                    customerManager.AddCustomer(newCustomer);
                    Console.WriteLine("Müşteri başarıyla eklendi.");
                    break;
                case "2":
                    // Müşteri listesini görüntüle
                    customerManager.ListCustomers();
                    break;
                case "3":
                    // Müşteri silme
                    Console.WriteLine("Silmek istediğiniz müşterinin numarasını girin:");
                    int index = int.Parse(Console.ReadLine());
                    if (index >= 0 && index < customerManager.Count)
                    {
                        customerManager.RemoveCustomer(customerManager[index]);
                        Console.WriteLine("Müşteri başarıyla silindi.");
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz müşteri numarası.");
                    }
                    break;
                case "4":
                    // Programdan çıkış
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}
