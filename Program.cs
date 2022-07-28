using System.Net;
using System.Text.Json;
namespace TP10
{

class Program {

    static int Main(string[] args){

        List<Civilization> miLista = ObtenerLista();

        return 0;
    }

    public static List<Civilization> ObtenerLista(){
        
        List<Civilization> lista = new List<Civilization>();

        string url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
        var request = (HttpWebRequest) WebRequest.Create(url);

        request.Method = "GET";
        request.Accept = "application/json";
        request.ContentType = "application/json";

        try
        {
            using (WebResponse respuesta = request.GetResponse())
            {
                using (Stream reader = respuesta.GetResponseStream())
                {
                    if(reader != null){

                        using (StreamReader objectReader = new StreamReader(reader))
                        {
                            string JsonString = objectReader.ReadToEnd();
                            lista = JsonSerializer.Deserialize<List<Civilization>>(JsonString);
                        }
                    }
                }
            }
        }
        catch (WebException excepcion)
        {
            Console.WriteLine("Se produjo error");
        }

        return lista;

    }

}

}