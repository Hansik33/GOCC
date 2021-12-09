using System.IO;
using System.Net;
using GOCC.Model;


namespace GOCC.Model
{
    internal static class Connector
    {
        static user _user = new user();
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
        public static bool LogIn(user U)
        {
            var request = WebRequest.Create("http://wospchorzow.pl/zaloguj.php?bieg=1&email=" +
                U.email
                + "&haslo=" +
                U.password
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
        public static bool Register(string imie, string nazwisko, string data, string email, string haslo, string numer, string miejscowosc, string adres)
        {
            var request = WebRequest.Create("http://wospchorzow.pl/rejestracja.php?bieg=1&imie=" + imie +
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
        public static bool Register(user U)
        {
            var request = WebRequest.Create("http://wospchorzow.pl/rejestracja.php?bieg=1&imie=" + U.name +
                "&nazwisko=" + U.lastName +
                "&data=" + U.birthdate +
                "&email=" + U.email + "&haslo=" + U.password +
                "&numer=" + U.phoneNumber +
                "&miejscowosc=" + U.city +
                "&adres=" + U.address + "&regulamin=TAK&submit=submitApp") as HttpWebRequest;
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
        public static string IsLogedIn()
        {
            var request = WebRequest.Create("http://wospchorzow.pl/dashboard.php?key=" + sessionKey) as HttpWebRequest;
            // request.Method = "GET";
            request.Method = "GET";
            request.Headers.Add("Cache-Control: max-age=0");
            request.Headers.Add("Upgrade-Insecure-Requests: 1");
            request.Headers.Add("Accept-Language: en-US,en;q=0.9");
            HttpWebResponse Httpresponse = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(Httpresponse.GetResponseStream());
            string r = reader.ReadToEnd();
            return r;
        }
    }
}