namespace Progression.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public List<Milestone> MilestoneList { get; set; } = new List<Milestone>();

        //En til mange relasjon mellom Goal og profil
        public Profile Profile { get; set; }

        //public List<Milestone> GenerateMilestone()
        //{
        //    // Generate Milestones logic
        //    return new List<Milestone>();
        //}

        //public void CreateMilestone(Milestone milestone)
        //{
        //    MilestoneList.Add(milestone);
        //}

        //public void GenerateQuiz()
        //{
        //    // Generate Quiz logic
        //}
    }
}
