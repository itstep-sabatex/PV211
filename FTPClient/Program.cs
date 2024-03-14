// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Net;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Hello, World!");
FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://ftp.gnu.org");
request.Credentials = new NetworkCredential("anonymous", "");
request.Method= WebRequestMethods.Ftp.ListDirectoryDetails;
try
{
    var data = new byte[8000];
    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    Int32 bytes = response.GetResponseStream().Read(data, 0, data.Length);
    Console.WriteLine(Encoding.ASCII.GetString(data, 0, bytes));

}
catch (Exception e)
{

}

request = (FtpWebRequest)WebRequest.Create("ftp://ftp.gnu.org/welcome.msg");
request.Credentials = new NetworkCredential("anonymous", "");
request.Method = WebRequestMethods.Ftp.DownloadFile;
try
{
    var data = new byte[80000];
    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    Int32 bytes = response.GetResponseStream().Read(data, 0, data.Length);
    Console.WriteLine(Encoding.ASCII.GetString(data, 0, bytes));

}
catch (Exception e)
{

}