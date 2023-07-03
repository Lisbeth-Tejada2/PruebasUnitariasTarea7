using System.Text;

namespace PruebasUnitarias;

public class UnitTest1
{
    [Fact]
    public void IsPasswordSecure_returns_false_if_password_has_less_than_8_characters() {

        var registerviewmodel = new RegisterViewModel();
        bool result = registerviewmodel.IsPasswordSecured("12345");
      
        Assert.False(result);
    }

    [Fact]
    public void IsPasswordSecure_returns_false_if_password_does_not_contain_uppercase_character()
    {
      
        var registerviewmodel = new RegisterViewModel();

        bool result = registerviewmodel.IsPasswordSecured("123457l");

     
        Assert.False(result);
    }

    [Fact]
    public void IsPasswordSecure_returns_false_if_password_does_not_contain_a_symbol()
    {
       
        var registerviewmodel = new RegisterViewModel();
        bool result = registerviewmodel.IsPasswordSecured("$3b2Mal");
 
        Assert.False(result);
    }
}
internal class RegisterViewModel
{
    internal bool IsPasswordSecured(string password) {

        if (password.Length < 8)
        {
            return false;
        }
        if (!ContieneMayusculas(password))
        {
            return false;
        }
        if (!ContieneSimbolos(password))
        {
            return false;
        }

        return true;
    }
    public bool ContieneMayusculas(string password) {

        char[] passwordChars = password.ToCharArray();
        foreach (char c in passwordChars)
        {
            if (Char.IsLetter(c) && IsUpper(c))
            {
                return true;
            }
        }
        return false;
    }
    public bool ContieneSimbolos(string password)
    {
        char[] passwordChars = password.ToCharArray();

        foreach (char c in passwordChars)
        {
            if (!Char.IsLetterOrDigit(c) && !Char.IsWhiteSpace(c) )
            {
                return true;
            }
        }
        return false;
    }

    private bool IsUpper(char c)
    {
        int codigoAscii = Convert.ToInt32(c);

        return (codigoAscii >= 65 && codigoAscii <= 90);
    }
}
