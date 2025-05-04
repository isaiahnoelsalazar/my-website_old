using System.Diagnostics;
using System.IO.Compression;
using System.Reflection;
using System.Text;

namespace mywebsite_nugetpackage
{
    public class PyCS
    {
        bool console = true, exist1 = false, exist2 = false, exist3 = false;

        public PyCS()
        {
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
                Directory.CreateDirectory("python3_12");
                if (!Directory.Exists("python3_12\\python312"))
                {
                    if (console)
                    {
                        Console.WriteLine("Extracting Python 3.12 resources...");
                    }
                    try
                    {
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
                        FileStream getpip = File.Create("python3_12\\get-pip.py");
                        FileStream sitecustomize = File.Create("python3_12\\sitecustomize.py");
                        Assembly.GetExecutingAssembly().GetManifestResourceStream("mywebsite_nugetpackage.get-pip.pycsfile").CopyTo(getpip);
                        Assembly.GetExecutingAssembly().GetManifestResourceStream("mywebsite_nugetpackage.sitecustomize.pycsfile").CopyTo(sitecustomize);
                        getpip.Close();
                        sitecustomize.Close();
                    }
                    catch
                    {
                        Console.WriteLine("Failed to extract Python 3.12 resources.");
                    }
                }
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
                if (!Directory.Exists("python3_12\\Lib") || !Directory.Exists("python3_12\\Scripts"))
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
                                    Console.WriteLine("PyCS initialized.");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to initialize PyCS. Connect to the internet to initialize PyCS.");
                                }
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Failed to download pip.");
                    }
                }
            }
        }

        public PyCS(bool console)
        {
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
                Directory.CreateDirectory("python3_12");
                if (!Directory.Exists("python3_12\\python312"))
                {
                    if (console)
                    {
                        Console.WriteLine("Extracting Python 3.12 resources...");
                    }
                    try
                    {
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
                        FileStream getpip = File.Create("python3_12\\get-pip.py");
                        FileStream sitecustomize = File.Create("python3_12\\sitecustomize.py");
                        Assembly.GetExecutingAssembly().GetManifestResourceStream("mywebsite_nugetpackage.get-pip.py").CopyTo(getpip);
                        Assembly.GetExecutingAssembly().GetManifestResourceStream("mywebsite_nugetpackage.sitecustomize.py").CopyTo(sitecustomize);
                        getpip.Close();
                        sitecustomize.Close();
                    }
                    catch
                    {
                        Console.WriteLine("Failed to extract Python 3.12 resources.");
                    }
                }
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
                if (!Directory.Exists("python3_12\\Lib") || !Directory.Exists("python3_12\\Scripts"))
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
                                    Console.WriteLine("PyCS initialized.");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to initialize PyCS. Connect to the internet to initialize PyCS.");
                                }
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Failed to download pip.");
                    }
                }
            }
        }

        public PyCS run(string script)
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
            return this;
        }

        public PyCS runFile(string filePath)
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
            return this;
        }
    }
}