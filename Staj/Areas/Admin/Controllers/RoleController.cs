using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staj.Areas.Admin.Models;
using Staj.Extensions;
using Staj.Repository.Models;

namespace Staj.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [Authorize(Roles = "role-editor")]
        public async Task<IActionResult> Index()
        {
            var roles =await _roleManager.Roles.Select(x => new RoleViewModel()
            {
                Id = x.Id,
                Name = x.Name!
            }).ToListAsync();
            return View(roles);
        }

        [Authorize(Roles = "role-editor")]
        public IActionResult RoleCreate()
        {
            return View();
        }
        [Authorize(Roles = "role-editor")]
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleCreateViewModel request)
        {
            var result = await _roleManager.CreateAsync(new AppRole() { Name = request.Name });
            if (!result.Succeeded)
            {
                ModelState.AddModelErrorList(result.Errors);
                return View();
            }
            TempData["SuccessMessage"] = "ne gerek var bu kadar role ";
            return RedirectToAction(nameof(RoleController.Index));
        }

        [Authorize(Roles = "role-editor")]
        public async Task<IActionResult> RoleUpdate(string Id)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(Id);

            if (roleToUpdate == null)
            {
                throw new Exception("Güncellenecek Role yok");
            }

            
            return View(new RoleUpdateViewModel() { Id=roleToUpdate.Id,Name=roleToUpdate.Name!});
        }
        [Authorize(Roles = "role-editor")]
        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleUpdateViewModel request)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(request.Id);
            if (roleToUpdate == null)
            {
                throw new Exception("Güncellenecek Rol Yok knks");
            }
            roleToUpdate.Name = request.Name;

            await _roleManager.UpdateAsync(roleToUpdate);

            ViewData["SuccessMessage"] = "Rol bilgisi güncellenmiştir";
            return View();
        }

        [Authorize(Roles = "role-editor")]
        public async Task<IActionResult> RoleDelete(string id) 
        {
            var roleDelete = await _roleManager.FindByIdAsync(id);
            if (roleDelete == null)
            {
                throw new Exception("Silinecek Rol Bulunamadı");
            }
             var result = await _roleManager.DeleteAsync(roleDelete);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.Select(x => x.Description).First());
            }

            TempData["SuccessMessage"] = "niye sildin rolü ? ";

            return RedirectToAction(nameof(RoleController.Index));
        }

        public async Task<IActionResult> AssingRoleToUser(string Id)
        {
            var currentUser = await _userManager.FindByIdAsync(Id);
            ViewBag.userId = Id;
            var roles = await _roleManager.Roles.ToListAsync();
           
            var UserRoles = await _userManager.GetRolesAsync(currentUser!);
            
            var roleViewModelList = new List<AssingRoleToUserViewModel>();

            
            foreach (var role in roles)
            {
                var assingRoleToUserViewModel = new AssingRoleToUserViewModel() { Id = role.Id, Name = role.Name! };
                if (UserRoles.Contains(role.Name!))
                {
                    assingRoleToUserViewModel.Exist = true;
                }
                roleViewModelList.Add(assingRoleToUserViewModel);
            }
            return View(roleViewModelList);
        }

        [HttpPost]
        public async Task<IActionResult> AssingRoleToUser(string Id,List<AssingRoleToUserViewModel> requestList) 
        {
            var userToAssingRoles =await _userManager.FindByIdAsync(Id);

            foreach (var role in requestList)
            {
                if (role.Exist)
                {
                    await _userManager.AddToRoleAsync(userToAssingRoles, role.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(userToAssingRoles,role.Name);
                }
            }


            return RedirectToAction(nameof(HomeController.UserList),"Home");
        }
    }
}
