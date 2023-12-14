using System.Xml.Linq;

public class BankAccount
{
    public static int id { get; } = 1234567890;
    public List<string> owners { get; set; }
    public decimal balance { get; }

    public BankAccount(String owner, decimal initialbalance)
    {
        this.owners = new List<string>();
        this.owners.Add(owner);
        if (initialbalance > 0)
            this.balance = initialbalance;
        else
            this.balance = 0;
    }

    /*
    public void deposit(decimal deposit)
    {
        this.balance += deposit;
    }

    public double withdraw(decimal withdraw)
    {
        if (balance >= withdraw)
        {
            this.balance -= withdraw;
            return withdraw;
        }
        else
        {
            this.balance = 0;
            return balance;
        }
    }

    public void addOwner(string owner)
    {
        this.owners.Add(owner);
    }

    public void removeOwner(string owner)
    {
        if (this.owners.Contains(owner))
            this.owners.Remove(owner);
    }
    */
}

