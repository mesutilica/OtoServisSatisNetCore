using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities
{
    public class Kullanici : IEntity
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Adi { get; set; }
        [StringLength(50)]
        public string Soyadi { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Telefon { get; set; }
        [StringLength(50)]
        public string KullaniciAdi { get; set; }
        [StringLength(50)]
        public string Sifre { get; set; }
        public bool AktifMi { get; set; }
        public DateTime? EklenmeTarihi { get; set; } = DateTime.Now;
        public int RolId { get; set; }
        public virtual Rol? Rol { get; set; }
    }
}
