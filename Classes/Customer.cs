namespace CarServiceDB.Classes;

public class Customer
{
    private readonly string? _name, _surname, _phoneNumber, _email;

    public int CustomersId { get; set; }

    public string? CustomersName
    {
        get => _name;
        init => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string? CustomersSurname
    {
        get => _surname;
        init => _surname = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string? CustomersPhoneNumber
    {
        get => _phoneNumber;
        init => _phoneNumber = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string? CustomersEmail
    {
        get => _email;
        init => _email = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double CustomersDiscount { get; init; }

    public string? CustomersIsVip { get; init; }

    public DateTime CustomersRegistrationDate { get; set; }
}