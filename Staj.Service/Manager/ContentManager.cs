using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Staj.Core.Models;
using Staj.Core.ViewModels;
using Staj.Repository.Models;

namespace Staj.Service.Manager
{
    public class ContentManager : IContentManager
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        public ContentManager(AppDbContext context, UserManager<AppUser> userManager)
        {
            _appDbContext = context;
            _userManager = userManager;
        }

        public void Add(ContentCreateViewModel content)
        {
           
                var item = new Content()
                {
                    Name = content.Name,
                    UserId = content.UserId,
                    SurName = content.SurName,
                    Departmant = content.Departmant,
                    StajNo = content.StajNo,
                    StajName = content.StajName,
                    Start = content.Start,
                    End = content.End,
                    StajPlace = content.StajPlace,
                    Description = content.Description,
                    IsyeriAdı = content.IsyeriAdı,
                    Birimi = content.Birimi,
                    IsyeriAdresi = content.IsyeriAdresi,
                    Isyeritelefon = content.Isyeritelefon,
                    IsyeriFax = content.IsyeriFax,
                    IsyeriEposta = content.IsyeriEposta,
                    StajYeriSorumlusuAdı = content.StajYeriSorumlusuAdı,
                    StajYeriSorumlusuSoyAdı = content.StajYeriSorumlusuSoyAdı,
                    StajYeriSorumlusuUnvanı = content.StajYeriSorumlusuUnvanı,
                    UniName = content.UniName,
                };
                _appDbContext.Content.Add(item);
                _appDbContext.SaveChanges();
            
           
        }

        public IEnumerable<ContentViewModel> GetAll(AppUser berkay)
        {
           
                var all = _appDbContext.Content.Where(x => x.UserId == berkay.Id).ToList();
                var turn = new List<ContentViewModel>();
                foreach (var item in all)
                {
                    turn.Add(
                        new ContentViewModel
                        {
                            Id=item.Id,
                            Name = item.Name,
                            UniCover = item.UniCover
                        });
                }
                return turn;
         

        }
        
        public Content GetById(int id)
        {
            Content user = null;
                user = _appDbContext.Content.Find(id);
                return user;
           
        }

        public void Remove(int Id)
        {
            var article = _appDbContext.Content.Find(Id);
            if (article == null)
            {
                throw new Exception();
                
            }
            _appDbContext.Content.Remove(article);
            _appDbContext.SaveChanges();
        }


        public void Update(int ıd,Content content)
        {

            var kayitli_olan = _appDbContext.Content.Find(ıd);
            if (kayitli_olan == null)
            {
                throw new Exception();
            }
            kayitli_olan.Name = content.Name;            
            kayitli_olan.SurName = content.SurName;
            kayitli_olan.Departmant = content.Departmant;
            kayitli_olan.StajNo = content.StajNo;
            kayitli_olan.StajName = content.StajName;
            kayitli_olan.Start=content.Start;
            kayitli_olan.End=content.End;
            kayitli_olan.StajPlace = content.StajPlace;
            kayitli_olan.Description= content.Description;
            kayitli_olan.IsyeriAdı = content.IsyeriAdı;
            kayitli_olan.Birimi=content.Birimi;
            kayitli_olan.IsyeriAdresi= content.IsyeriAdresi;
            kayitli_olan.Isyeritelefon = content.Isyeritelefon;
            kayitli_olan.IsyeriFax=content.IsyeriFax;
            kayitli_olan.IsyeriEposta=content.IsyeriEposta;
            kayitli_olan.StajYeriSorumlusuAdı = content.StajYeriSorumlusuAdı;
            kayitli_olan.StajYeriSorumlusuSoyAdı = content.StajYeriSorumlusuSoyAdı;
            kayitli_olan.StajYeriSorumlusuUnvanı = content.StajYeriSorumlusuUnvanı;
            kayitli_olan.UniName=content.UniName;
            kayitli_olan.UniCover = content.UniCover;

        _appDbContext.Update(kayitli_olan);
        _appDbContext.SaveChanges();
            





        }
    }
}
