//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_StokTakipOtomasyonu.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ürün
    {
        public Ürün()
        {
            this.Satışlar = new HashSet<Satışlar>();
            this.Sepet = new HashSet<Sepet>();
        }
    
        public int ID { get; set; }
        public int KategoriID { get; set; }
        public int MarkaID { get; set; }
        public string ÜrünAdi { get; set; }
        public string BarkodNo { get; set; }
        public decimal AlisFiyatı { get; set; }
        public decimal SatisFiyatı { get; set; }
        public int KDV { get; set; }
        public int BirimID { get; set; }
        public System.DateTime Tarih { get; set; }
        public byte[] Açıklama { get; set; }
    
        public virtual Birimler Birimler { get; set; }
        public virtual Kategoriler Kategoriler { get; set; }
        public virtual Markalar Markalar { get; set; }
        public virtual ICollection<Satışlar> Satışlar { get; set; }
        public virtual ICollection<Sepet> Sepet { get; set; }
    }
}
