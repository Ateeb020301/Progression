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
                                    ""content"": ""What is the capital of France?"",
                                    ""options"":[ 
                                        ""A: Berlin"",
                                        ""B: Madrid"",
                                        ""C: Paris"",
                                        ""D: Rome""
                                    ],
                                    ""answer"": ""C""
                                }}
                            ]
                            ";

            var content = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
            {
                new { role = "system", content = "You are a helpful assistant that creates multiple-choice quizzes." },
                new { role = "user", content = prompt }
            },
                max_tokens = 500,
                temperature = 0.7
            };

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions",
                new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json"));

            var responseBody = await response.Content.ReadAsStringAsync();
            //fÃ¥r error mld fra OpenAi om hva som er feil
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
        public string NumberOfQuestions { get; set; }
    }
}
