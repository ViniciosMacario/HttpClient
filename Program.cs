using Newtonsoft.Json;
using System.Net;

internal class Program
{
    private static async Task Main()
    {
        string key;
        key = "cIgTeVupgjEESFYRtFYISdYiBNaPPtCVq4QtDusC";

        var browser = new HttpClient
        {
            BaseAddress = new Uri("https://api.nasa.gov/")
        };
        var response = await browser.GetAsync($"/planetary/apod?api_key={key}");
        var data = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        var dataobj = JsonConvert.DeserializeObject<TypeData>(data);

        Console.WriteLine($"<------ Nasa Corporação ------>");
        Console.WriteLine($"\n - Título: {dataobj!.title} \n - Data: {dataobj.date} \n - descrição: {dataobj.explanation} \n - Link: {dataobj.url} \n");

        var imageUrl = new WebClient();
        imageUrl.DownloadFile($"{dataobj.url}", @$"c:\{dataobj.url}");
    }
}

public class TypeData
{
    public string? date;
    public string? explanation;
    public string? title;
    public string? url;
}

//Instânciando class para inicialização
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

//var client = new HttpClient();
////Enviando a solicitação
//var request = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");

////Acessando o conteudo da api e convertendo ela em uma string data.
//var data = await request.EnsureSuccessStatusCode().Content.ReadAsStringAsync();

//var obj = JsonConvert.DeserializeObject<JsonTypeReflector[]>(data)![7]!;

////Imprimindo dados fornecidos da Api
//Console.WriteLine(obj.userID);

//// JSON["JAMES"]["NOME"]["sobrenome"]

//public class JsonTypeReflector
//{
//    public string? userID;
//}