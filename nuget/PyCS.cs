using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Text;

namespace mywebsite_nugetpackage
{
    public class PyCS
    {
        bool console = true, exist1 = false, exist2 = false, exist3 = false;

        void AllowTLS12()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        }

        public PyCS()
        {
            AllowTLS12();
            if (!File.Exists("python-3.12.9-embed-win32.zip"))
            {
                if (console)
                {
                    Console.WriteLine("Creating Python 3.12 resources...");
                }
                try
                {
                    FileStream zip = File.Create("python-3.12.9-embed-win32.zip");
                    Assembly.GetExecutingAssembly().GetManifestResourceStream("mywebsite_nugetpackage.python-3.12.9-embed-win32.zip").CopyTo(zip);
                    zip.Close();
                }
                catch
                {
                    Console.WriteLine("Failed to create Python 3.12 resources.");
                }
            }
            else
            {
                if (console)
                {
                    Console.WriteLine("Python 3.12 resources already created.");
                }
            }
            try
            {
                using (File.OpenRead("python-3.12.9-embed-win32.zip"))
                {
                    exist1 = true;
                }
            }
            catch
            {
            }
            if (exist1)
            {
                if (!Directory.Exists("python3_12\\python312"))
                {
                    if (console)
                    {
                        Console.WriteLine("Extracting Python 3.12 resources...");
                    }
                    try
                    {
                        Directory.CreateDirectory("python3_12");
                        string zipPath = "python-3.12.9-embed-win32.zip";
                        string extractPath = "python3_12";
                        ZipFile.ExtractToDirectory(zipPath, extractPath);

                        using (FileStream fs = File.OpenWrite("python3_12\\python312._pth"))
                        {
                            string toWrite = "python312\r\n.\r\n\r\n# Uncomment to run site.main() automatically\r\nimport site\r\n";
                            fs.Write(Encoding.UTF8.GetBytes(toWrite), 0, Encoding.UTF8.GetBytes(toWrite).Length);
                        }

                        string zipPath1 = "python3_12\\python312.zip";
                        string extractPath1 = "python3_12\\python312";
                        ZipFile.ExtractToDirectory(zipPath1, extractPath1);

                        FileStream sitecustomize = File.Create("python3_12\\sitecustomize.py");
                        Assembly.GetExecutingAssembly().GetManifestResourceStream("mywebsite_nugetpackage.sitecustomize.py").CopyTo(sitecustomize);
                        sitecustomize.Close();
                    }
                    catch
                    {
                        if (console)
                        {
                            Console.WriteLine("Failed to extract Python 3.12 resources.");
                        }
                    }
                }
                else
                {
                    if (console)
                    {
                        Console.WriteLine("Python 3.12 resources already extracted.");
                    }
                }
            }
            try
            {
                if (!File.Exists("python3_12\\get-pip.py")){
                    if (console)
                    {
                        Console.WriteLine("Downloading get-pip...");
                    }
                    var webReq = (HttpWebRequest)HttpWebRequest.Create("https://bootstrap.pypa.io/get-pip.py");
                    var res = webReq.GetResponse();
                    var content = res.GetResponseStream();

                    using (var fileStream = File.Create("python3_12\\get-pip.py"))
                    {
                        content.CopyTo(fileStream);
                    }
                }
                else
                {
                    if (console)
                    {
                        Console.WriteLine("get-pip already downloaded.");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Failed to download get-pip. Connect to the internet to download get-pip.");
            }
            try
            {
                using (File.OpenRead("python3_12\\get-pip.py"))
                {
                    exist2 = true;
                }
            }
            catch
            {
            }
            try
            {
                using (File.OpenRead("python3_12\\sitecustomize.py"))
                {
                    exist3 = true;
                }
            }
            catch
            {
            }
            if (exist2 && exist3)
            {
                if (!Directory.Exists("python3_12\\Lib") || !Directory.Exists("python3_12\\Scripts") ||
                    !File.Exists("python3_12\\Scripts\\pip.exe") || !File.Exists("python3_12\\Scripts\\pip3.12.exe") || !File.Exists("python3_12\\Scripts\\pip3.exe"))
                {
                    if (console)
                    {
                        Console.WriteLine("Downloading pip...");
                    }
                    try
                    {
                        ProcessStartInfo run0 = new ProcessStartInfo();
                        run0.FileName = "python3_12\\python.exe";
                        run0.Arguments = "python3_12\\get-pip.py";
                        run0.UseShellExecute = false;
                        run0.RedirectStandardOutput = true;
                        run0.CreateNoWindow = true;
                        using (Process process = Process.Start(run0))
                        {
                            using (StreamReader reader = process.StandardOutput)
                            {
                                string result = reader.ReadToEnd();
                                if (result.Length != 0)
                                {
                                    Console.WriteLine("pip downloaded.");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to download pip. Connect to the internet to download pip.");
                                }
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Failed to download pip.");
                    }
                }
                else
                {
                    if (console)
                    {
                        Console.WriteLine("pip already downloaded.");
                    }
                }
            }
        }

        public PyCS(bool console)
        {
            AllowTLS12();
            this.console = console;
            if (!File.Exists("python-3.12.9-embed-win32.zip"))
            {
                if (console)
                {
                    Console.WriteLine("Creating Python 3.12 resources...");
                }
                try
                {
                    FileStream zip = File.Create("python-3.12.9-embed-win32.zip");
                    Assembly.GetExecutingAssembly().GetManifestResourceStream("mywebsite_nugetpackage.python-3.12.9-embed-win32.zip").CopyTo(zip);
                    zip.Close();
                }
                catch
                {
                    Console.WriteLine("Failed to create Python 3.12 resources.");
                }
            }
            else
            {
                if (console)
                {
                    Console.WriteLine("Python 3.12 resources already created.");
                }
            }
            try
            {
                using (File.OpenRead("python-3.12.9-embed-win32.zip"))
                {
                    exist1 = true;
                }
            }
            catch
            {
            }
            if (exist1)
            {
                if (!Directory.Exists("python3_12\\python312"))
                {
                    if (console)
                    {
                        Console.WriteLine("Extracting Python 3.12 resources...");
                    }
                    try
                    {
                        Directory.CreateDirectory("python3_12");
                        string zipPath = "python-3.12.9-embed-win32.zip";
                        string extractPath = "python3_12";
                        ZipFile.ExtractToDirectory(zipPath, extractPath);

                        using (FileStream fs = File.OpenWrite("python3_12\\python312._pth"))
                        {
                            string toWrite = "python312\r\n.\r\n\r\n# Uncomment to run site.main() automatically\r\nimport site\r\n";
                            fs.Write(Encoding.UTF8.GetBytes(toWrite), 0, Encoding.UTF8.GetBytes(toWrite).Length);
                        }

                        string zipPath1 = "python3_12\\python312.zip";
                        string extractPath1 = "python3_12\\python312";
                        ZipFile.ExtractToDirectory(zipPath1, extractPath1);

                        FileStream sitecustomize = File.Create("python3_12\\sitecustomize.py");
                        Assembly.GetExecutingAssembly().GetManifestResourceStream("mywebsite_nugetpackage.sitecustomize.py").CopyTo(sitecustomize);
                        sitecustomize.Close();
                    }
                    catch
                    {
                        if (console)
                        {
                            Console.WriteLine("Failed to extract Python 3.12 resources.");
                        }
                    }
                }
                else
                {
                    if (console)
                    {
                        Console.WriteLine("Python 3.12 resources already extracted.");
                    }
                }
            }
            try
            {
                if (!File.Exists("python3_12\\get-pip.py")){
                    if (console)
                    {
                        Console.WriteLine("Downloading get-pip...");
                    }
                    var webReq = (HttpWebRequest)HttpWebRequest.Create("https://bootstrap.pypa.io/get-pip.py");
                    var res = webReq.GetResponse();
                    var content = res.GetResponseStream();

                    using (var fileStream = File.Create("python3_12\\get-pip.py"))
                    {
                        content.CopyTo(fileStream);
                    }
                }
                else
                {
                    if (console)
                    {
                        Console.WriteLine("get-pip already downloaded.");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Failed to download get-pip. Connect to the internet to download get-pip.");
            }
            try
            {
                using (File.OpenRead("python3_12\\get-pip.py"))
                {
                    exist2 = true;
                }
            }
            catch
            {
            }
            try
            {
                using (File.OpenRead("python3_12\\sitecustomize.py"))
                {
                    exist3 = true;
                }
            }
            catch
            {
            }
            if (exist2 && exist3)
            {
                if (!Directory.Exists("python3_12\\Lib") || !Directory.Exists("python3_12\\Scripts") ||
                    !File.Exists("python3_12\\Scripts\\pip.exe") || !File.Exists("python3_12\\Scripts\\pip3.12.exe") || !File.Exists("python3_12\\Scripts\\pip3.exe"))
                {
                    if (console)
                    {
                        Console.WriteLine("Downloading pip...");
                    }
                    try
                    {
                        ProcessStartInfo run0 = new ProcessStartInfo();
                        run0.FileName = "python3_12\\python.exe";
                        run0.Arguments = "python3_12\\get-pip.py";
                        run0.UseShellExecute = false;
                        run0.RedirectStandardOutput = true;
                        run0.CreateNoWindow = true;
                        using (Process process = Process.Start(run0))
                        {
                            using (StreamReader reader = process.StandardOutput)
                            {
                                string result = reader.ReadToEnd();
                                if (result.Length != 0)
                                {
                                    Console.WriteLine("pip downloaded.");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to download pip. Connect to the internet to download pip.");
                                }
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Failed to download pip.");
                    }
                }
                else
                {
                    if (console)
                    {
                        Console.WriteLine("pip already downloaded.");
                    }
                }
            }
        }

        public void pip(string[] args)
        {
            ProcessStartInfo run0 = new ProcessStartInfo();
            run0.FileName = "python3_12\\Scripts\\pip.exe";
            run0.Arguments = string.Join(" ", args);
            run0.UseShellExecute = false;
            run0.RedirectStandardOutput = true;
            run0.CreateNoWindow = true;
            using (Process process = Process.Start(run0))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }
        }

        public void run(string script)
        {
            File.Create("python3_12\\main.py").Close();
            File.WriteAllText("python3_12\\main.py", script);

            ProcessStartInfo run0 = new ProcessStartInfo();
            run0.FileName = "python3_12\\python.exe";
            run0.Arguments = "python3_12\\main.py";
            run0.UseShellExecute = false;
            run0.RedirectStandardOutput = true;
            run0.CreateNoWindow = true;
            using (Process process = Process.Start(run0))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }
        }

        public void runFile(string filePath)
        {
            ProcessStartInfo run0 = new ProcessStartInfo();
            run0.FileName = "python3_12\\python.exe";
            run0.Arguments = filePath;
            run0.UseShellExecute = false;
            run0.RedirectStandardOutput = true;
            run0.CreateNoWindow = true;
            using (Process process = Process.Start(run0))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }
        }
    }
}