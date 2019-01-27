namespace The.Machine.Models
{
    public class EmployeePrefenceDTO
    {
        public long Id { get; set; }
        public DrinkDTO Drink { get; set; }
        public bool UsePersonalMug { get; set; }
        public short SugarQuantity { get; set; }
    }
}
