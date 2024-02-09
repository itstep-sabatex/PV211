// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

[DllImport("user32.dll",CallingConvention =CallingConvention.StdCall)]
static extern void MessageBox(IntPtr hWhd, string tesxt, string caption, uint uType = 0x02);
IntPtr ptr = Process.GetCurrentProcess().MainWindowHandle;

MessageBox(ptr, "Hello world", "Test");

Console.WriteLine("Hello, World!");
