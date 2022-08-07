// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

var userName = "servilift";
var passwd = "etXk83Wtg56MLMJcwtuUgAQe";




string fechai = String.Empty;
string fechaf = String.Empty;

int fechaiu;
int fechafu;

#region "Lectura de parametros"

Console.Write("Fecha inicial:");
fechai = Console.ReadLine();
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
Console.Write("Fecha final:");
fechaf = Console.ReadLine();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
#endregion

#region "Tranformacion de parametros"
DateTime fechaii = Convert.ToDateTime(fechai);
DateTime fechaff = Convert.ToDateTime(fechaf);
fechaii = fechaii.ToUniversalTime();
fechaff = fechaff.ToUniversalTime();



TimeSpan epochTicks = new(new DateTime(1970, 1, 1).Ticks);


////Creating Second Time Interval and Substracting its Value from the First One
TimeSpan unixTicks = new TimeSpan(fechaii.Ticks) - epochTicks;

////Converting time interval to seconds to represent Unix Timestamp
Int64 unixTimestamp = (Int32)unixTicks.TotalSeconds;
unixTimestamp *= 1000;


TimeSpan unixTicksf = new TimeSpan(fechaff.Ticks) - epochTicks;

//Converting time interval to seconds to represent Unix Timestamp
Int64 unixTimestampf = (Int32)unixTicksf.TotalSeconds;
unixTimestampf *= 1000;


#endregion


#region "Obtecion de Datos



//https://api.fieldbeat.com/fleets/servilift/tasks?from=<timestamp_start>&until=<timestamp_end>
//https://api.fieldbeat.com/fleets/{{fleet}}/tasks/{{task_id}}

var url = "https://api.fieldbeat.com/fleets/servilift/tasks?from=" + unixTimestamp + "&until=" + unixTimestampf;

//var url = "https://api.fieldbeat.com/fleets/servilift/tasks/1362";


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

#endregion



string path = "C:\\paso\\file-ahora" + Convert.ToString(fechaii).Replace(":", "") + " " + Convert.ToString(fechaff).Replace(":", "") + ".json";
//string path = "C:\\paso\\file-ahora-1362.json";

//string Text = "Hello, Hi, ByeBye";
File.WriteAllText(path, f);
StringBuilder sbguias = new();





Console.Read();


try
{

    List<consolaApi.Registro> Registros = new List<consolaApi.Registro>();


    var guias = JsonSerializer.Deserialize<consolaApi.Registro>(f);

    Console.WriteLine("Numero de Guias {0}", guias.count);

#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
    foreach (var ltareas in guias.tasks)
    {

        DateTimeOffset dateTimeOffSet = DateTimeOffset.FromUnixTimeMilliseconds(ltareas.created_at);
        DateTime dateTime = dateTimeOffSet.DateTime;
        try
        {
            string disc = ltareas.@type
;
            if (disc != null && disc.Contains("PRESUPUESTOS"))
            {

                Console.WriteLine("Guias {0} responsable {1} Creada {2}  Cliente {3}  Rut: {4} Tarea {5}  Duracion: {6}", ltareas.task_id, ltareas.assigned_to, dateTime, ltareas.client.name, ltareas.client.rut, ltareas.report.name, ltareas.duration);

            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Generic Exception Handler: {e}");
        }


    }


}
catch (Exception e)
{
    Console.WriteLine($"Generic Exception Handler: {e}");



    Console.Read();

    //JsonTextReader reader = new(new StringReader(f));
    //while (reader.Read())
    //{
    //    if (reader.Value != null)
    //    {
    //        String linea = string.Concat("Token: ", reader.TokenType, "\t Valor: ", reader.Value);
    //        Console.WriteLine("Token: {0}, Valor: {1}", reader.TokenType, reader.Value);
    //#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
    //        var c1 = reader.Value.ToString().Trim();

    //#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
    //        string c0;

    //        c0 = reader.TokenType.ToString();
    //        c0 = c0.TrimEnd().TrimStart().Trim();
    //        c0 = c0.Replace("\"", "\t");
    //        c0 = c0.Replace("PropertyName", "");
    //        String dato = String.Concat(c0, "  ", c1.ToString());
    //        dato = dato.Replace("String", "").Replace("Integer", "").Replace("publicBoolean", "");
    //        sbguias.Append(dato);




    //    }
    //    else
    //    {
    //        Console.WriteLine("Token: {0}", reader.TokenType);
    //        sbguias.Append('\n');
    //    }
    //}




    //Console.Read();

    //path = "C:\\paso\\file-texto" + Convert.ToString(fechaii).Replace(":", "") + " " + Convert.ToString(fechaff).Replace(":", "") + ".txt";

    //var path2 = path;
    //string Text = "Hello, Hi, ByeBye";
    //File.WriteAllText(path, sbguias.ToString());




    //JArray reader = new(new StringReader(f));

    //JArray jsonPreservar = JArray.Parse(f);
    //StreamReader reader1 = new StreamReader(f);
    //JArray jsonPreservar = JArray.Parse(reader1.ReadToEnd());

    //foreach (JObject jsonOperaciones in jsonPreservar.Children<JObject>())
    //{
    //    Aqui para poder identificar las propiedades y sus valores
    //    /*foreach (JProperty jsonOPropiedades in jsonOperaciones.Properties())
    //    {
    //        string propiedad = jsonOPropiedades.Name;
    //        if (propiedad.Equals("idgoOperacion"))
    //        {
    //            var idgoOperacion = Convert.ToInt32(jsonOPropiedades.Value);
    //        }
    //    }*/
    //    Aqui puedes acceder al objeto y obtener sus valores
    //    JObject data = JObject.Parse(jsonPreservar[0].ToString());
    //    var rut = Convert.ToInt32(data["rut"]);
    //    Console.Write($"rut: ");
    //    Console.ReadKey();
    //}

    //Console.WriteLine("valor original " + fechaii);
    //Console.WriteLine("Valor de la fecha inicial es:" + unixTimestamp);




    //Console.WriteLine("Valor de la fecha final es:" + fechaff);
    //Console.WriteLine("Valor calculado final:" + unixTimestampf);

    //Console.ReadKey();


    //Console.Write("Valor a convertir en fecha: ");
    //Int64 valor = Console.Read();


    //Console.WriteLine(valor);
    //Console.WriteLine(DateTimeOffset.FromUnixTimeMilliseconds(valor));

    Console.Read();
}

