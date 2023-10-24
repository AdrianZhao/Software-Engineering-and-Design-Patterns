UserSystem twoFactorRequired = new TwoFactorRequired();
UserSystem twoFactorNotRequired = new TwoFactorNotRequired();
try
{
    User firstUser = twoFactorRequired.CreateUser(true, true);
    User secondUser = twoFactorRequired.CreateUser(false, false);
    User thirdUser = twoFactorNotRequired.CreateUser(true, true);
    User fourthUser = twoFactorNotRequired.CreateUser(false, false);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
public abstract class UserSystem
{
    public virtual void PasswordHash() { }
    public User CreateUser(bool json, bool isAdmin)
    {
        User user;
        user = TwoFactor(json, isAdmin);
        return user;
    }
    protected abstract User TwoFactor(bool json, bool isAdmin);
}
public class TwoFactorRequired : UserSystem
{
    protected override User TwoFactor(bool json, bool isAdmin)
    {
        User newUser;
        if (json && isAdmin)
        {
            newUser = new Administrator();
        } 
        else if (json && !isAdmin)
        {
            newUser = new AuthorizedUser();
        }
        else
        {
            throw new InvalidOperationException();
        }
        return newUser;
    }
}
public class TwoFactorNotRequired : UserSystem
{
    protected override User TwoFactor(bool json, bool isAdmin)
    {
        User newUser;
        if (isAdmin)
        {
            newUser = new Administrator();
        }
        else
        {
            newUser = new AuthorizedUser();
        }
        return newUser;
    }
}
public abstract class User
{

}
public class Administrator : User
{

}
public class AuthorizedUser : User
{

}