using BaseDemo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseDemo.Models
{
    public class KullaniciViewModel
    {
        public Kullanici Kullanici { get; set; }
        public List<Kullanici> Kullanicis { get; set; }
        public List<KullaniciTip> KullaniciTips { get; set; }
        public List<Iller> Illers { get; set; }


    }
}