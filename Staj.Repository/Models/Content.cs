using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Staj.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Staj.Core.Models
{
    public class Content
    {
        
        public int Id { get; set; }


        public string Name { get; set; }
        public string? SurName { get; set; }

        public string? Departmant { get; set; }
        public int StajNo { get; set; }

        public string? StajName { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string? StajPlace { get; set; }

        public string? Description { get; set; }

        public string? IsyeriAdı { get; set; }

        public string? Birimi { get; set; }

        public string? IsyeriAdresi { get; set; }

        public string? Isyeritelefon { get; set; }

        public string? IsyeriFax { get; set; }

        public string? IsyeriEposta { get; set; }

        public string? StajYeriSorumlusuAdı { get; set; }
        public string? StajYeriSorumlusuSoyAdı { get; set; }
        public string? StajYeriSorumlusuUnvanı { get; set; }

       

        public string? UniName { get; set; }

        public string? UniCover { get; set; }

        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser? User { get; set; }

        
        
    }
}
