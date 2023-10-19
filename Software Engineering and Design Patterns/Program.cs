using System.Runtime.CompilerServices;

public abstract class Clinet
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int? Age { get; set; }
    public bool AccessDisabled { get; set; }
    protected IAccessHandler _accessHandler;
    public virtual bool HandleAccess()
    {
        return _accessHandler.GetAccess(accessDisabled : AccessDisabled);
    }
}
public class User : Clinet
{
    public User() 
    {
        _accessHandler = new HasReputation();
    }
    public int Reputation { get; set; }
    public override bool HandleAccess()
    {
        return _accessHandler.GetAccess(reputation: Reputation);
    }
}
public class Manager : Clinet
{
    public Manager() 
    {
        _accessHandler = new HasAccessAutomatic();
    }
}
public class Admin : Clinet
{
    public Admin()
    {
        _accessHandler = new HasAccessAutomatic();
    }
}
public interface IAccessHandler
{
    public bool GetAccess(int? reputation = 0, bool accessDisabled = false);
}
public class HasReputation : IAccessHandler
{
    public bool GetAccess(int? reputation = 0, bool accessDisabled = false)
    {
        return reputation > 20;
    }
}
public class HasAccessAutomatic : IAccessHandler
{
    public bool GetAccess(int? reputation = 0, bool accessDisabled = false)
    {
        return !accessDisabled;
    }
}