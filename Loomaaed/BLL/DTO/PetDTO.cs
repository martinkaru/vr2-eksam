namespace BLL.DTO
{
    public class PetDTO
    {
        public int PetID { get; set; }
        public string Name { get; set; }

        public string Breed { get; set; }
        public string Age { get; set; }

        public OwnerDTO Owner { get; set; }
    }
}