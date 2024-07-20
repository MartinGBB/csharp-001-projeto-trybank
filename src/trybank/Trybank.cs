namespace Trybank.Lib;

public class TrybankLib
{
    public bool Logged;
    public int loggedUser;

    //0 -> Número da conta
    //1 -> Agência
    //2 -> Senha
    //3 -> Saldo
    public int[,] Bank;
    public int registeredAccounts;
    private readonly int maxAccounts = 50;

    public TrybankLib()
    {
        loggedUser = -99;
        registeredAccounts = 0;
        Logged = false;
        Bank = new int[maxAccounts, 4];
    }

    // 1. Construa a funcionalidade de cadastrar novas contas
    public void RegisterAccount(int number, int agency, int pass)
    {
        bool accountInUse = AccountInUse(number, agency);
        if (accountInUse)
            throw new ArgumentException("A conta já está sendo usada!");

        Bank[registeredAccounts, 0] = number;
        Bank[registeredAccounts, 1] = agency;
        Bank[registeredAccounts, 2] = pass;
        Bank[registeredAccounts, 3] = 0;
        registeredAccounts++;
    }

    // 2. Construa a funcionalidade de fazer Login
    public void Login(int number, int agency, int pass)
    {
        if (Logged) throw new AccessViolationException("Usuário já está logado");

        for (int i = 0; i < registeredAccounts; i++)
        {
            if (Bank[i, 0] == number && Bank[i, 1] == agency)
            {
                if (Bank[i, 2] == pass)
                {
                    Logged = true;
                    loggedUser = i;
                }
                else throw new ArgumentException("Senha incorreta");
            }
            else throw new ArgumentException("Agência + Conta não encontrada");
        }
    }

    // 3. Construa a funcionalidade de fazer Logout
    public void Logout()
    {
        ValidateUserLogget();

        loggedUser = -99;
        Logged = false;
    }

    // 4. Construa a funcionalidade de checar o saldo
    public int CheckBalance()
    {
        ValidateUserLogget();

        int cash = Bank[loggedUser, 3];
        return cash;
    }

    // 5. Construa a funcionalidade de depositar dinheiro
    public void Deposit(int value)
    {
        ValidateUserLogget();
        Bank[loggedUser, 3] += value;
    }

    // 6. Construa a funcionalidade de sacar dinheiro
    public void Withdraw(int value)
    {
        ValidateUserLogget();
        ValidateCash(value);

        Bank[loggedUser, 3] -= value;
    }

    // 7. Construa a funcionalidade de transferir dinheiro entre contas
    public void Transfer(int destinationNumber, int destinationAgency, int value)
    {
        ValidateUserLogget();
        ValidateCash(value);

        int userTransfer = -1;

        for (int i = 0; i < registeredAccounts; i++)
        {
            if (Bank[i, 1] == destinationAgency && Bank[i, 0] == destinationNumber)
                userTransfer = i;
        }

        if (userTransfer == -1) throw new ArgumentException("Dados não encontrados");

        Bank[loggedUser, 3] -= value;
        Bank[userTransfer, 3] += value;
    }

    private bool AccountInUse(int number, int agency)
    {
        bool accountRegistered = false;
        if (registeredAccounts > 0)
        {
            for (int i = 0; i < registeredAccounts; i++)
            {
                if (Bank[i, 0] == number && Bank[i, 1] == agency)
                {
                    accountRegistered = true;
                    break;
                }
            }
        }
        return accountRegistered;
    }

    private void ValidateUserLogget()
    {
        if (!Logged || loggedUser == -99)
            throw new AccessViolationException("Usuário não está logado");
    }

    private void ValidateCash(int value)
    {
        int cash = Bank[loggedUser, 3];
        if (cash < value)
            throw new InvalidOperationException("Saldo insuficiente");
    }
}
