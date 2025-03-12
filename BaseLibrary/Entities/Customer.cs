
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Customer : BaseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama wajib diisi.")]
        public string? Name { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Image { get; set; }
        [Required(ErrorMessage = "KTP wajib diisi.")]
        public string CitizenID { get; set; }
        [Required(ErrorMessage = "Foto KTP wajib diisi.")]
        public string? CitizenImage { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }

        public string? BirthPlace { get; set; }
        public string? BirthDate { get; set; }
        public string? Religion { get; set; }
        [Required(ErrorMessage = "Alamat sesuai KTP wajib diisi.")]
        public string? AddressID  { get;set; }
        [Required(ErrorMessage = "Alamat sesuai Domisili wajib diisi.")]
        public string? AddressDomicili { get; set; }
        public string? AddressStreet { get; set; }
        [Required(ErrorMessage = "Nama Ibu Kandung wajib diisi.")]
        public string? MaindenName { get; set; }
        [Required(ErrorMessage = "No HP wajib diisi.")]
        public string? MobilePhone { get; set; }
        [Required(ErrorMessage = "No Emergency wajib diisi.")]
        public string? EmergencyPhone { get; set; }

        [Required(ErrorMessage = "Email wajib diisi.")]
        public string? Email { get; set; }

        public string? Status { get; set; }

        public List<TransactionHistory> TransactionHistories { get; set; } = new();

    }
}
