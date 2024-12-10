namespace Progression.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //En til mange relsasjon mot Profile
        public int ProfileId { get; set; } // Add this property
        public Profile Profile { get; set; }

    }
}
