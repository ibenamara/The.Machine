using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The.Machine.Entities
{
    public class EmployeePreference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Drink Drink { get; set; }
        public bool UsePersonalMug { get; set; }
        public short SugarQuantity { get; set; }
    }
}
