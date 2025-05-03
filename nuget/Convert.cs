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

        // I have not tested the functions below. Proceed with caution.
        
        public static string FromHex(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i += 2)
            {
                string byteStr = str.Substring(i, 2);
                sb.Append((char)Convert.ToByte(byteStr, 16));
            }
            return sb.ToString();
        }

        public static string FromBinary(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i += 8)
            {
                string byteStr = str.Substring(i, 8);
                sb.Append((char)Convert.ToByte(byteStr, 2));
            }
            return sb.ToString();
        }

        public static string ToBinary(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
        
        public static string ToHex(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                sb.AppendFormat("{0:X2}", (int)c);
            }
            return sb.ToString();
        }

        public static int ToInt(string str)
        {
            return int.Parse(str);
        }

        public static double ToDouble(string str)
        {
            return double.Parse(str);
        }

        public static long ToLong(string str)
        {
            return long.Parse(str);
        }

        public static float ToFloat(string str)
        {
            return float.Parse(str);
        }
    }
}
