using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;


class Program
    {

    static async Task Main()
        {
        using HttpClient client = new HttpClient();
        string url = "https://t.me/Vizov20Day2_bot";
        string json = "{\"title\":\"\foo\",\"bode\":\"bar\",\"usetId\":1}";
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync(url, content);
        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);


        var client1 = new TelegramBotClient("7062379992:AAH0aXkZ0pS5AI5YSbi1daaYfmAqXEKzyBI");
        client1.StartReceiving(Update, Error);
        Console.ReadLine();
        }

    private static async Task Error(ITelegramBotClient client, Exception exception,CancellationToken token)
    { 
        

    }
    private static async Task Update(ITelegramBotClient Botclient, Update update,CancellationToken token)
    {
        Program pro = new Program();
        var massange = update.Message;
        Console.WriteLine(massange.Chat.Id);
        if (massange.Text != null)
        {
            if(massange.Text.ToLower().Contains("привет")|| massange.Text.ToLower().Contains("здравствуйте") || massange.Text.ToLower().Contains("здравствуй"))
            {
                await Botclient.SendTextMessageAsync(massange.Chat.Id, "Здравствуйте");
                return;
            }
        }
    }
}










