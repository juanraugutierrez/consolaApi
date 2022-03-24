// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

var userName = "servilift";
var passwd = "etXk83Wtg56MLMJcwtuUgAQe";
var url = "https://api.fieldbeat.com/fleets/servilift/tasks?from=1643673600000&until=1646092799000";

using var client = new HttpClient();

var authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
        Convert.ToBase64String(authToken));

var result = await client.GetAsync(url);

var content = await result.Content.ReadAsStringAsync();
Console.WriteLine(content);

var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
var f = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
Console.WriteLine(f);

string path = "C:\\paso\\file-ahora.json";
//string Text = "Hello, Hi, ByeBye";
File.WriteAllText(path, f);
StringBuilder sbguias = new StringBuilder();


JsonTextReader reader = new JsonTextReader(new StringReader(f));
while (reader.Read())
{
    if (reader.Value != null)
    {
        Console.WriteLine("Token: {0}, Valor: {1}", reader.TokenType, reader.Value);
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
        var c1 = reader.Value.ToString().Trim();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
        string c0;

        c0 = reader.TokenType.ToString();
        c0 = c0.TrimEnd().TrimStart().Trim();
        c0 = c0.Replace("\"","\t");
        sbguias.AppendJoin(c0, "\t", c1, "\n");
    }
    else
    {
        Console.WriteLine("Token: {0}", reader.TokenType);
        sbguias.Append('\n');
    }
}
path = "C:\\paso\\file-texto.txt";
//string Text = "Hello, Hi, ByeBye";
File.WriteAllText(path, sbguias.ToString());
