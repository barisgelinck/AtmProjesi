using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmProjesi
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

//.
public class Account
{
    public string CardNumber { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }
    public List<string> TransactionHistory { get; private set; }
    public Account(string cardNumber, string password, decimal balance)
    {
        CardNumber = cardNumber;
        Password = password;
        Balance = balance;
        TransactionHistory = new List<string>();
    }
    public bool ValidatePassword(string password)
    {
        return Password == password;
    }
    public void ViewBalance()
    {
        Console.WriteLine($"Bakiyeniz: {Balance} TL");
    }
    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance = Balance - amount;
            TransactionHistory.Add($"Çekilen: {amount} TL");
            return true;
        }
        return false;
    }
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance = Balance + amount;
            TransactionHistory.Add($"Yatırılan: {amount} TL");
        }

    }
    public void ViewTransactionHistory()
    {
        if (TransactionHistory.Count == 0)
        {
            Console.WriteLine("Henüz işlem yapılmadı.");
        }
        else
        {
            Console.WriteLine("\nİşlem Geçmişi:");
            foreach (var transaction in TransactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}

public class ATM
{
    private Account account;

    public ATM(Account account)
    {
        this.account = account;
    }

   
    public void ViewBalance()
    {
        account.ViewBalance();  
    }

 
    public void WithdrawMoney()
    {
        Console.Write("Çekim yapacağınız miktarı giriniz: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        if (account.Withdraw(amount))
        {
            Console.WriteLine($"Çekilen miktar {amount} TL. Kalan bakiyeniz: {account.Balance} TL");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye veya geçersiz değer girdiniz.");
        }
    }


    public void DepositMoney()
    {
        Console.Write("Yatırmak istediğiniz miktarı giriniz: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        account.Deposit(amount);
        Console.WriteLine($"{amount} TL başarıyla yatırıldı. Yeni bakiyeniz: {account.Balance} TL");
    }
    public void ViewTransactionHistory()
    {
        account.ViewTransactionHistory();
    }
}

class Program
{
    static void Main(string[] args)
    {
       
        Account account = new Account("1234", "1234", 1000);
        ATM atm = new ATM(account); 

        
        Console.WriteLine("=== XYZ Bank ATM iyi günler diler. ===");
        Console.Write("Kart numaranızı giriniz: ");
        string cardNumber = Console.ReadLine();

        Console.Write("Şifrenizi giriniz: ");
        Console.WriteLine("  ");
        string password = Console.ReadLine();

        if (cardNumber == account.CardNumber && account.ValidatePassword(password))
        {
            Console.WriteLine("Giriş başarılı!\n");
                

            while (true)
            {
                Console.WriteLine("Ana Menü:");
                Console.WriteLine("1. Bakiyeyi gör");
                Console.WriteLine("2. Para çek");
                Console.WriteLine("3. Para yatır");
                Console.WriteLine("4. İşlem geçmişi");
                Console.WriteLine("5. Çıkış");
                Console.Write("Bir seçenek seçiniz. (1-5): ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        atm.ViewBalance();
                        break;
                    case 2:
                        atm.WithdrawMoney();
                        break;
                    case 3:
                        atm.DepositMoney(); 
                        break;
                    case 4:
                        atm.ViewTransactionHistory();
                        break;
                    case 5:
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Hatalı seçim yaptınız.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Yanlış numara veya şifre girdiniz.");
        }
    }
}

