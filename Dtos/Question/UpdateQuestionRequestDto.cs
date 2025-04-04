﻿using Progression.Models;

namespace Progression.Dtos.Question
{
    public class UpdateQuestionRequestDto
    {
        public string Content { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public int Answer { get; set; }
    }
}
