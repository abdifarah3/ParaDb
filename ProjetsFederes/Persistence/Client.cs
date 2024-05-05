namespace ProjetsFederes.Persistence;

public class Client
{
    //For EF
    public Client()
    {
        
    }
    public Client(string name, string email, string address, string skinType)
    {
        Name = name;
        Email = email;
        Address = address;
        SkinType = skinType;
    }
    
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string SkinType { get; set; }

    public ICollection<Order> Orders { get; set; } = [];
}