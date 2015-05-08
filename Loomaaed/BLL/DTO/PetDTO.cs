namespace BLL.DTO
{
    public class PetDTO
    {
        public int PetID { get; set; }
        public string Name { get; set; }

        public string Breed { get; set; }
        public string Age { get; set; }

        public int? OwnerID { get; set; }
    }
}