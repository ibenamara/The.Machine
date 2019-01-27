namespace The.Machine.Models
{
    public class EmployeeDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public EmployeePrefenceDTO Preference { get; set; }
    }
}
