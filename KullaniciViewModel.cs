using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DialogExample.ViewModel
{
    public class KullaniciViewModel
    {

        public KullaniciViewModel()
        {
            this.ProgramList = new List<SelectListItem>();
            ProgramList.Add(new SelectListItem { Text ="Seçiniz", Value = ""  });
        }

        public int KullaniciID { get; set; }

        [Required(ErrorMessage = "Tc Kimlik Numarasını Girmediniz")]
        [StringLength(11, ErrorMessage = "Tc Numarası alanı en fazla 11 karakter alabilir")]
        [MinLength(5, ErrorMessage = "Tc Kimlik Numarasını 11 karakter olacak şekilde giriniz")]
        public string Tc { get; set; }

        [Required(ErrorMessage = "Ad ve Soyadı Girmediniz")]
        [StringLength(50, ErrorMessage = "Ad ve Soyad  alanı en fazla 50 karakter alabilir")]
        public string AdSoyad { get; set; }

        
        public int Bolumler { get; set; }
        
        public int Programlar { get; set; }

        public int BolumID { get; set; }

        public int ProgramID { get; set;}


         [Required(ErrorMessage = "Cep  Telefonu Girmediniz")]
        [StringLength(11, ErrorMessage = "Cep Telefonu  alanı en fazla 11 karakter alabilir")]
        [MinLength(10, ErrorMessage = "Telefon Numarasını başında 0 olacak şekilde giriniz ")]
        public string Cep { get; set; }


         [Required(ErrorMessage = "Bisiklet Numarasını Girmediniz")]
        [StringLength(6, ErrorMessage = "Bisiklet Numarası alanı en fazla 6 karakter alabilir")]
        public string Bisiklet { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime Verilis { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime Iade { get; set; }

        public List<SelectListItem> BolumList {get; set;}


        public List<SelectListItem> ProgramList { get; set; }



    }
}