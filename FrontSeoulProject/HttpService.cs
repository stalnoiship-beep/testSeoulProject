using System.Net.Http;

namespace SeoulProject;

public class HttpService
{
    public string baseUrl;

    public string token;

    public HttpClient client;

    public HttpService(string burl)
    {
        baseUrl = burl;
        client =  new HttpClient()
        {
            BaseAddress = new System.Uri(burl)
        };
    }

    

}