using System.Text;

namespace mywebsite_nugetpackage
{
    public class Convert
    {
        public static string ToBase64(string str)
        {
            return System.Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        public static string FromBase64(string str)
        {
            return Encoding.UTF8.GetString(System.Convert.FromBase64String(str));
        }
    }
}
