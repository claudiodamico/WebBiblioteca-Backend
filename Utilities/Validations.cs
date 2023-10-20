namespace WebBiblioteca.Utilities
{
    public class Validations
    {
        public static bool HayStock(int stock, string ISBN)
        {
            if (stock > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsUserValid(string username, string password)
        {
            return (username == "usuario" && password == "contraseña");
        }
    }
}
