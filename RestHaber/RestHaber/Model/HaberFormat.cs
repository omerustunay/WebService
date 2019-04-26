using System;
namespace RestHaber.Model
{
    public class HaberFormat
    {



        public int idHaber { get; set; }
        public string HaberBaslik { get; set; }
        public string HaberIcerik { get; set; }
        public string HaberTuru { get; set; }
        public DateTime? YayinlanmaTarihi { get; set; }
        public int BegenmeSayisi { get; set; }

        }
}
