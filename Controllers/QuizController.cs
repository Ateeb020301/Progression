using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public QuizController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpPost("generate")]
    //henter quiz fra OpenAi APi i JSON format
    public async Task<IActionResult> GenerateQuiz([FromBody] QuizRequest request)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "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");

            var prompt = $@"
Create a multiple-choice quiz on the topic '{request.Topic}' with {request.NumberOfQuestions} questions.
Each question should have:
1. The question text.
2. Four answer choices labeled A, B, C, and D.
3. The correct answer.

Return the result as a JSON array. Example format:
[
    {{
        ""question"": ""What is the capital of France?"",
        ""options"": {{
            ""A"": ""Berlin"",
            ""B"": ""Madrid"",
            ""C"": ""Paris"",
            ""D"": ""Rome""
        }},
        ""correctAnswer"": ""C""
    }}
]
";

            var content = new
            {
                model = "gpt-3.5-turbo",
                prompt = prompt,
                max_tokens = 500,
                temperature = 0.7
            };

            var response = await client.PostAsync("https://api.openai.com/v1/completions",
                new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json"));

            var responseBody = await response.Content.ReadAsStringAsync();
            //får error mld fra OpenAi om hva som er feil
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, new
                {
                    Message = "Failed to generate quiz",
                    Error = responseBody
                });
            }

            return Ok(responseBody);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                Message = "An internal server error occurred",
                Error = ex.Message
            });
        }
    }


    public class QuizRequest
    {
        public string Topic { get; set; }
        public int NumberOfQuestions { get; set; }
    }
}
