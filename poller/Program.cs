namespace poller;
using Microsoft.Data.SqlClient;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
		Program.Poll();
		Program.CheckDb();
    }
    static void Poll() {
		// In production code, don't destroy the HttpClient through using, but better use 
		// IHttpClientFactory factory or at least reuse an existing HttpClient instance
		// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests
		// https://www.aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
		using (var httpClient = new HttpClient())
		{
    		using (var request = new HttpRequestMessage(new HttpMethod("GET"), "http://www.example.com/"))
    		{
        		var response = httpClient.Send(request);
        		Console.WriteLine(response.ToString());
    		}
		}
    }

    static void CheckDb() {
		var url = System.Environment.GetEnvironmentVariable("MSSQL_URL");
		using (SqlConnection connection = new SqlConnection(url)) {
			connection.Open();
            Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
            Console.WriteLine("State: {0}", connection.State);
            Console.WriteLine(connection.GetSchema().ToString());
		}
    }
}
