using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Staj.Areas.Admin.Models;
using Staj.Core.Models;
using Staj.Core.ViewModels;
using Staj.Repository.Models;
using Staj.Service.Manager;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Staj.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentManager _contentManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _appDbContext;
        private readonly IFileProvider _fileProvider;
        private string userName => User.Identity!.Name!;


        public ContentController(IContentManager contentManager, UserManager<AppUser> userManager,IFileProvider fileProvider)
        {
            _contentManager = contentManager;
            _userManager = userManager;
            _fileProvider = fileProvider;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
         
            return View(_contentManager.GetAll(currentUser));
           

            //var roles = await _roleManager.Roles.Select(x => new RoleViewModel()
            //{
            //    Id = x.Id,
            //    Name = x.Name!
            //}).ToListAsync();
            //return View(roles);
        }

        public IActionResult Create()
        {
            
            return View("ContentCreate");
        }

        public IActionResult ContentEdit(int id)
        {
            
            
            var request = _contentManager.GetById(id);
            
            
            var contentEditGet = new ContentEditViewModel()
            {
                Id = id,
                Name = request.Name,
                SurName = request.SurName,
                Departmant = request.Departmant,
                StajNo = request.StajNo,
                StajName = request.StajName,
                Start = request.Start,
                End = request.End,
                StajPlace = request.StajPlace,
                Description = request.Description,
                IsyeriAdı = request.IsyeriAdı,
                Birimi = request.Birimi,
                IsyeriAdresi = request.IsyeriAdresi,
                Isyeritelefon = request.Isyeritelefon,
                IsyeriFax = request.IsyeriFax,
                IsyeriEposta = request.IsyeriEposta,
                StajYeriSorumlusuAdı = request.StajYeriSorumlusuAdı,
                StajYeriSorumlusuSoyAdı = request.StajYeriSorumlusuSoyAdı,
                StajYeriSorumlusuUnvanı = request.StajYeriSorumlusuUnvanı,
                UniName = request.UniName,
                


            };  
            return View(contentEditGet);

        }
        [HttpPost]
        public async Task<IActionResult> Create(ContentCreateViewModel request)
        {
            

            //.FindByNameAsync(HttpContext.User.Identity.Name);
            var currentUser = await  _userManager.GetUserAsync(HttpContext.User);
            _contentManager.Add(new ContentCreateViewModel()
            {
                Name = request.Name,
                UserId = currentUser.Id,
                SurName = request.SurName,
                Departmant = request.Departmant,
                StajNo = request.StajNo,
                StajName = request.StajName,
                Start = request.Start,
                End = request.End,
                StajPlace = request.StajPlace,
                Description = request.Description,
                IsyeriAdı = request.IsyeriAdı,
                Birimi = request.Birimi,
                IsyeriAdresi = request.IsyeriAdresi,
                Isyeritelefon = request.Isyeritelefon,
                IsyeriFax = request.IsyeriFax,
                IsyeriEposta = request.IsyeriEposta,
                StajYeriSorumlusuAdı = request.StajYeriSorumlusuAdı,
                StajYeriSorumlusuSoyAdı = request.StajYeriSorumlusuSoyAdı,
                StajYeriSorumlusuUnvanı = request.StajYeriSorumlusuUnvanı,
                UniName = request.UniName
            });




            //var currentUser = _userManager.FindByIdAsync(request.Id);

            //SurName=request.SurName,
            //Departmant=request.Departmant,
            //StajNo=request.StajNo,
            //StajName=request.StajName,
            //Start=request.Start,
            //End=request.End,
            //StajPlace=request.StajPlace,
            //Description=request.Description,
            //IsyeriAdı=request.IsyeriAdı,
            //Birimi=request.Birimi,
            //IsyeriAdresi=request.IsyeriAdresi,
            //Isyeritelefon=request.Isyeritelefon,
            //IsyeriEposta=request.IsyeriEposta,
            //IsyeriFax=request.IsyeriFax,
            //StajYeriSorumlusuAdı=request.StajYeriSorumlusuAdı,
            //StajYeriSorumlusuSoyAdı=request.StajYeriSorumlusuSoyAdı,
            //StajYeriSorumlusuUnvanı=request.StajYeriSorumlusuUnvanı,
            //UniName=request.UniName,
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> Delete(ContentViewModel content)
        {
            
            _contentManager.Remove(content.Id);
            return RedirectToAction("Index");

        }

        public IActionResult ContentPDF(int id)
        {
            var content=_contentManager.GetById(id);
            
            var see = new ContentPDFViewModel()
            {
                Id = id,
                Name = content.Name,
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
                UniCover=content.UniCover

            };
            return View(see);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ContentEditViewModel request)
        {

            var contentEditViewModel = new Content()
            {
                Id = request.Id,
                Name = request.Name,
                SurName = request.SurName,
                Departmant = request.Departmant,
                StajNo = request.StajNo,
                StajName = request.StajName,
                Start = request.Start,
                End = request.End,
                StajPlace = request.StajPlace,
                Description = request.Description,
                IsyeriAdı = request.IsyeriAdı,
                Birimi = request.Birimi,
                IsyeriAdresi = request.IsyeriAdresi,
                Isyeritelefon = request.Isyeritelefon,
                IsyeriFax = request.IsyeriFax,
                IsyeriEposta = request.IsyeriEposta,
                StajYeriSorumlusuAdı = request.StajYeriSorumlusuAdı,
                StajYeriSorumlusuSoyAdı = request.StajYeriSorumlusuSoyAdı,
                StajYeriSorumlusuUnvanı = request.StajYeriSorumlusuUnvanı,
                UniName = request.UniName
               
            };
            if (request.UniCover != null && request.UniCover.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(request.UniCover.FileName)}";

                var newPicturePath = Path.Combine(wwwrootFolder!.First(x => x.Name == "userpictures").PhysicalPath!, randomFileName);

                using var stream = new FileStream(newPicturePath, FileMode.Create);

                await request.UniCover.CopyToAsync(stream);

                contentEditViewModel.UniCover = randomFileName;
            }

            _contentManager.Update(request.Id,contentEditViewModel);

            return RedirectToAction("Index");
        }
    }
}
