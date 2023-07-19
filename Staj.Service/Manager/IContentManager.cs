using Staj.Core.Models;
using Staj.Core.ViewModels;
using Staj.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staj.Service.Manager
{
    public interface IContentManager
    {
        void Add(ContentCreateViewModel content);

        void Remove(int Id);

        void Update(int Id,Content content);

        IEnumerable<ContentViewModel> GetAll(AppUser berkay);

        Content GetById(int id);    


    }
}
