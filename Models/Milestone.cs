namespace Progression.Models
{
    public class Milestone
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }


        //En til mange relasjon til milestone
        public Goal Goal { get; set; }


        //public Quiz GenerateQuiz()
        //{
        //    // Generate Quiz logic
        //    return new Quiz();
        //}

        //public void CRUD()
        //{
        //    // CRUD operations
        //}

        //public void SoftDeleteMilestone()
        //{
        //    Status = false;
        //}
    }
}
