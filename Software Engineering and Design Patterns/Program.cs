Client user = new User
{
    Username = "JohnDoe",
    Email = "john@example.com"
};
Console.WriteLine(user.GetDescription());
Console.WriteLine(user.GetBadges());
user = new AddBadge(user);
Console.WriteLine("After add badge");
Console.WriteLine(user.GetDescription());
Console.WriteLine(user.GetBadges());
public abstract class Client
{
    public string Username { get; set; }
    public string Email { get; set; }
    protected string _description = "No Description";

    public virtual string GetDescription()
    {
        return _description;
    }
    public virtual string GetBadges()
    {
        return $"{Username}, {GetDescription()}, no badges now.";
    }
}
public class User : Client
{
    public User()
    {
        _description = "Base-level User";
    }
}
public abstract class BadgeDecorator : Client
{
    public Client Client { get; set; }
    public BadgeDecorator(Client client)
    {
        Client = client;
    }
    public abstract override string GetBadges();
}
public class AddBadge : BadgeDecorator
{
    public AddBadge(Client client) : base(client)
    {
        Username = client.Username;
        Email = client.Email;
        _description = client.GetDescription();
    }
    public override string GetBadges()
    {
        return $"{Client.Username}, {Client.GetDescription()}, one badge.";
    }
}