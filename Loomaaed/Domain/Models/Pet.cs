namespace Domain.Models
{
    public class Pet
    {
        public int PetID { get; set; }
        public string Name { get; set; }

        public string Breed { get; set; }
        public string Age { get; set; }

        public Owner Owner { get; set; }
    }
}