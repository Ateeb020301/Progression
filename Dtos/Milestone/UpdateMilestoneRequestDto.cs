﻿using Progression.Models;

namespace Progression.Dtos.Milestone
{
    public class UpdateMilestoneRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
