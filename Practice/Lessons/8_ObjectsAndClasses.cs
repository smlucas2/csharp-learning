using System.Text;
using System.Xml.Linq;

public class BankAccount
{
    private static int id { get; } = 1234567890;
    private List<Transaction> AllTransactions = new List<Transaction>();
    public List<string> Owners { get; set; }
    public decimal Balance { 
        get
        {
            decimal balance = 0;
            foreach (var item in AllTransactions)
            {
                balance += item.amount;
            }
            return balance;
        } 
    }

    public BankAccount(String owner, decimal initialBalance)
    {
        this.Owners = new List<string>();
        this.Owners.Add(owner);
        Deposit(initialBalance, DateTime.Now, "Initial deposit.");
    }

    public void Deposit(decimal amount, DateTime date, string note)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive.");
        }
        var deposit = new Transaction(amount, date, note);
        AllTransactions.Add(deposit);
    }

    public void Withdraw(decimal amount, DateTime date, string note)
    {
       if (amount <= 0)
       {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdraw must be positive.");
       }
       if ( Balance - amount < 0)
       {
            throw new InvalidOperationException("Not sufficient funds for this withdraw.");
       }
       var withdrawal = new Transaction(-amount, date, note);
       AllTransactions.Add(withdrawal);
    }

    public string GetAccountHistory()
    {
        var report = new StringBuilder();
        report.AppendLine("date\t\tamount\tnote");
        foreach (var item in AllTransactions)
            report.AppendLine($"{item.date.ToShortDateString()}\t{item.amount}\t{item.notes}");
        return report.ToString();
    }

    public void AddOwner(string owner)
    {
        this.Owners.Add(owner);
    }

    public void RemoveOwner(string owner)
    {
        if (this.Owners.Contains(owner))
            this.Owners.Remove(owner);
    }
}

public class Transaction
{
    public decimal amount { get; }
    public DateTime date { get; }
    public string notes { get; }

    public Transaction(decimal amount, DateTime date, string notes)
    {
        this.amount = amount;
        this.date = date;
        this.notes = notes;
    }
}

