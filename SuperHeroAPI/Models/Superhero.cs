namespace SuperHeroAPI.Models
{
    //initially created to be added into local DB and altered to use online API
    public class Superhero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Powerstats Powerstats { get; set; }
        public Biography Biography { get; set; }
        public Appearance Appearance { get; set; }
        public Work Work { get; set; }
        public Connections Connections { get; set; }
        public string ImageUrl { get; set; }
    }

    public class Powerstats
    {
        public int Intelligence { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int Durability { get; set; }
        public int Power { get; set; }
        public int Combat { get; set; }
    }

    public class Biography
    {
        public string FullName { get; set; }
        public string AlterEgos { get; set; }
        public List<string> Aliases { get; set; }
        public string PlaceOfBirth { get; set; }
        public string FirstAppearance { get; set; }
        public string Publisher { get; set; }
        public string Alignment { get; set; }
    }

    public class Appearance
    {
        public string Gender { get; set; }
        public string Race { get; set; }
        public List<string> Height { get; set; }
        public List<string> Weight { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
    }

    public class Work
    {
        public string Occupation { get; set; }
        public string Base { get; set; }
    }

    public class Connections
    {
        public string GroupAffiliation { get; set; }
        public string Relatives { get; set; }
    }

}
