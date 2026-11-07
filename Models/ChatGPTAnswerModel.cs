namespace HomeControlBlazor.Models
{
    public class ChatCompletionResponse
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public long Created { get; set; }
        public string Model { get; set; }
        public Choice[] Choices { get; set; }
        public Usage Usage { get; set; }
        public object SystemFingerprint { get; set; }
    }

    public class Choice
    {
        public int Index { get; set; }
        public Message Message { get; set; }
        public object Logprobs { get; set; } // Adjust the type as per actual data
        public string FinishReason { get; set; }
    }

    public class Message
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }

    public class Usage
    {
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
        public int TotalTokens { get; set; }
    }
    //public class ChatGPTAnswerModel
    //{
    //    public class Rootobject
    //    {
    //        public string id { get; set; }
    //        public string _object { get; set; }
    //        public int created { get; set; }
    //        public string model { get; set; }
    //        public Choice[] choices { get; set; }
    //        public Usage usage { get; set; }
    //        public object system_fingerprint { get; set; }
    //    }

    //    public class Usage
    //    {
    //        public int prompt_tokens { get; set; }
    //        public int completion_tokens { get; set; }
    //        public int total_tokens { get; set; }
    //    }

    //    public class Choice
    //    {
    //        public int index { get; set; }
    //        public Message message { get; set; }
    //        public object logprobs { get; set; }
    //        public string finish_reason { get; set; }
    //    }

    //    public class Message
    //    {
    //        public string role { get; set; }
    //        public string content { get; set; }
    //    }

    //}
}
