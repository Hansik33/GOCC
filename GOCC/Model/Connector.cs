using System.IO;
using System.Net;


namespace GOCC.Model
{
    internal static class Connector
    {
        public static string sessionKey = "";
        public static string lastError = "";
        public static bool LogIn(string email, string password)
        {
            var request = WebRequest.Create("http://wospchorzow.pl/zaloguj.php?bieg=1&email=" +
                email
                + "&haslo=" +
                password
                + "&login=loginApp") as HttpWebRequest;
            // request.Method = "GET";
            request.Method = "GET";
            request.Headers.Add("Cache-Control: max-age=0");
            request.Headers.Add("Upgrade-Insecure-Requests: 1");
            request.Headers.Add("Accept-Language: en-US,en;q=0.9");
            HttpWebResponse Httpresponse = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(Httpresponse.GetResponseStream());

            string r = reader.ReadToEnd();
            if (r[0] == '1')
            {
                string session = r.Substring(2);
                sessionKey = session;
                return true;
            }
            else
            {
                string message = r.Substring(2);
                lastError = message;
                return false;
            }
            
            
        }
 
        public static bool Register(string bieg, string opcja2,string opcja1, string imie, string nazwisko, string data, string email, string haslo, string numer, string miejscowosc, string adres)
        {
            var request = WebRequest.Create("http://wospchorzow.pl/aplikacjaRejestracja.php?bieg=" + bieg + "&opcja2=" + opcja2 + "&opcja1=" + opcja1 + "&imie=" + imie +
                "&nazwisko=" + nazwisko +
                "&data=" + data +
                "&email=" + email + "&haslo=" + haslo +
                "&numer=" + numer +
                "&miejscowosc=" + miejscowosc +
                "&adres=" + adres + "&regulamin=TAK&submit=submitApp") as HttpWebRequest;
            // request.Method = "GET";
            request.Method = "GET";
            request.Headers.Add("Cache-Control: max-age=0");
            request.Headers.Add("Upgrade-Insecure-Requests: 1");
            request.Headers.Add("Accept-Language: en-US,en;q=0.9");
            HttpWebResponse Httpresponse = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(Httpresponse.GetResponseStream());
            string r = reader.ReadToEnd();
            if (r[0] == '1')
            {
                return true;
            }
            else
            {
                string message = r.Substring(2);
                lastError = message;
                return false;
            }
        }
      
    }
   
}