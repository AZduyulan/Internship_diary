using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Staj.Core.ViewModels
{
    public class ContentCreateViewModel
    {
        
        [Display(Name = "Adı : ")]
        public string Name { get; set; }

        public string UserId { get; set; }



        [Display(Name = "Soyadınız : ")]
        public string SurName { get; set; }

        [Display(Name = "Bölümünüz : ")]
        public string Departmant { get; set; }

        [Display(Name = "Staj Numaranız : ")]
        public int StajNo { get; set; }

        [Display(Name = "Staj Adınız : ")]
        public string StajName { get; set; }

        [Display(Name = "Staj Başlama Tarihi : ")]
        public DateTime Start { get; set; }

        [Display(Name = "Staj Bitirme Tarihi : ")]
        public DateTime End { get; set; }


        [Display(Name = "Staj Yeri Adınız : ")]
        public string StajPlace { get; set; }


        [Display(Name = "Staj Günlüğü : ")]
        public string Description { get; set; }

        [Display(Name = "İş Yeri Adı : ")]
        public string IsyeriAdı { get; set; }


        [Display(Name = "Birimi : ")]
        public string Birimi { get; set; }

        [Display(Name = "İş Yeri Adresi: ")]
        public string IsyeriAdresi { get; set; }

        [Display(Name = "İş Yeri Telefonu : ")]
        public string Isyeritelefon { get; set; }

        [Display(Name = "İş Yeri Faxı : ")]
        public string IsyeriFax { get; set; }

        [Display(Name = "İş Yeri E-postası : ")]
        public string IsyeriEposta { get; set; }
        [Display(Name = "Staj Yeri Sorumlusu Adı : ")]
        public string StajYeriSorumlusuAdı { get; set; }
        [Display(Name = "Staj Yeri Sorumlusu Soyadı : ")]
        public string StajYeriSorumlusuSoyAdı { get; set; }
        [Display(Name = "Staj Yeri Sorumlusu Ünvanı : ")]
        public string StajYeriSorumlusuUnvanı { get; set; }


        [Display(Name = "Üniversite Adı : ")]
        public string UniName { get; set; }

        //[Display(Name = "Üniversite Logosu : ")]
        //public IFormFile UniCover { get; set; }
    }
}
