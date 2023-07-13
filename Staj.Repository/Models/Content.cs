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
        public string Article { get; set; }

        
        public string Cover { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        
        
    }
}
