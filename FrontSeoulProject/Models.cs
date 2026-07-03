using System;
using System.Text.Json.Serialization;

namespace SeoulProject;

public class LoginClass
{
    [JsonPropertyName("access_token")]
    public string token{get;set;}="";
}

public class Registration
{
    [JsonPropertyName("username")]
    public string name{get;set;}="";
    [JsonPropertyName("fullname")]
     public string fullname{get;set;}="";

    public string password {get;set;}="";
    // public string token{get;set;}="";

     public string gender{get;set;}="";
     [JsonPropertyName("family_count")]
     public int familycount{get;set;}=0;
     
     [JsonPropertyName("birthdate")]
     public DateTime birthday{get;set;}

}