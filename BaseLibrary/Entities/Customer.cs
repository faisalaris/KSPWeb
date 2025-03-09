
namespace BaseLibrary.Entities
{
    public class Customer : BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Image { get; set; }
        public string? CitizenID { get; set; }  
        public string? CitizenImage { get; set; }  
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? BirthPlace { get; set; }
        public string? BirthDate { get; set; }
        public string? Religion { get; set; }
        public string? Address  { get;set; }
        public string? AddressStreet { get; set; }
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }

    }
}
