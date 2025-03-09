namespace client.Shared
{
    public class DummyService
    {
        public static List<MemberStatus> GetDummyMembers() => new()
    {
        new MemberStatus { NomorAnggota = "123456", NIK = "3201123456789012", NoTelp = "08123456789", Email = "user1@example.com", Status = "Aktif",
            RiwayatTransaksi = new List<string> { "01 Jan 2025: Daftar Anggota", "01 Feb 2025: Pinjaman Rp. 1.300.000 Disetujui" }
        },
        new MemberStatus { NomorAnggota = "654321", NIK = "3201987654321098", NoTelp = "08987654321", Email = "user2@example.com", Status = "Tidak Aktif",
            RiwayatTransaksi = new List<string> { "05 Mar 2024: Daftar Anggota" }
        }
    };
    }

    public class MemberStatus
    {
        public string NomorAnggota { get; set; } = string.Empty;
        public string NIK { get; set; } = string.Empty;
        public string NoTelp { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public List<string> RiwayatTransaksi { get; set; } = new();
    }
}
