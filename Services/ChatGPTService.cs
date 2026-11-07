using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using OpenAI.API;
using OpenAI.API.Completions;
using static HomeControlBlazor.Pages.ChatGPT;
using HomeControlBlazor.Models;


namespace HomeControlBlazor.Services
{
    public interface IChatGPTService
    {
        public  Task<string> GetCompletionAsync(string question);
    }

    public class ChatGPTService : IChatGPTService
    {
        //private OpenAIAPI APIclient;
        string apiKey = "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";
       // private string promptText;
        private string generatedText;
        private readonly HttpClient httpClient;
        private const string ApiKey = "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"; // Replace with your API key
        private const string ApiBaseUrl = "https://api.openai.com/v1/chat/completions";

        public ChatGPTService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
        }

        //  public async Task<string> GetCompletionAsync()
        public async Task<string> GetCompletionAsync(string question)
        {
            try
            {
                var requestBody = new
                {
                    messages = new[]
                    {
                new { role = "system", content = question }
            },
                    model = "gpt-4-1106-preview"
                };

                string jsonContent = System.Text.Json.JsonSerializer.Serialize(requestBody);
                var response = await httpClient.PostAsync(ApiBaseUrl, new StringContent(jsonContent, Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                //ChatGPTAnswerModel completion = System.Text.Json.JsonSerializer.Deserialize<ChatGPTAnswerModel>(responseContent);
                //var completion = System.Text.Json.JsonSerializer.Deserialize<ChatCompletionResponse>(responseContent);
                ChatCompletionResponse tmp = JsonConvert.DeserializeObject<ChatCompletionResponse>(responseContent);

                return tmp?.Choices?[0]?.Message.Content;
                //return completion[0].
            }
            catch (Exception ex) { return ex.Message; }
        }

        private class CompletionResponse
        {
            public Choice[] Choices { get; set; }
        }

        private class Choice
        {
            public string Text { get; set; }
        }


        /*
        public async Task<string> AskChatGPT(string question)
        {
            try
            {
                OpenAIAPI client = new OpenAIAPI(apiKey)
                    client.cha
                var options = new OpenAI.API.Completions.CompletionRequest
                {
                    Prompt = question,
                    MaxTokens = 100
                };

                var response = await client.GenerateTextAsync(options);
                return response.Text;
                //var parameters = new CompletionRequest
                //{
                //    Model = "gpt-4-1106-preview", // "text -davinci-002",
                //    Prompt = question,
                //    Temperature = 0.7,
                //    MaxTokens = 100
                //};

                //var response = await APIclient.Completions.CreateCompletionAsync(parameters);

                //generatedText = response.Completions[0].Text;
                //return generatedText;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
                    }
        }
        */


        /*
        public  async Task<string> AskChatGPT(string question)
        {
            // This URL is hypothetical and does not actually exist.
            var url = "https://api.openai.com/v1/chatgpt";

            // Replace with your actual API key.
            var apiKey = "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";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var response = await client.GetAsync($"{url}?question={question}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                    return apiResponse.Answer;
                }
                else
                {
                    return "Error: " + response.StatusCode;
                }
            }
        }
        */
    }

    public class ApiResponse
    {
        public string Answer { get; set; }
    }

   
}
