using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class LoanTransaction : BaseEntity
    {
        public LoanTransaction()
        {
            // LoanID otomatis dibuat berdasarkan timestamp + angka random (unik)
            LoanID = $"{DateTime.UtcNow:yyyyMMddHHmmssfff}{new Random().Next(100, 999)}";
            LoanStatus = "Pending";
        }

        public string LoanID { get; set; }
        [Required(ErrorMessage = "MemberID wajib diisi.")]
        public string MemberID { get; set; }
        [Required(ErrorMessage = "Tujuan wajib diisi.")]
        public string LoanPurpose { get; set; }
        [Required(ErrorMessage = "Tenor tidak boleh 0 ")]
        [Range(1, int.MaxValue, ErrorMessage = "Tenor harus lebih dari 0.")]
        public int LoanTenor { get; set; }
        [Required(ErrorMessage = "Tenor tidak boleh 0 ")]
        [Range(1, double.MaxValue, ErrorMessage = "Jumlah pinjaman harus lebih dari 0.")]
        public decimal LoanAmount { get; set; }
        public string LoanStatus { get; set; }
    }
}
