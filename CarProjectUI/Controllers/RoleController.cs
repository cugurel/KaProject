using CarProjectUI.Identity;
using CarProjectUI.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace CarProjectUI.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<User> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Role");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index", "Role");
        }

        public async Task<IActionResult> UpdateRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonMembers = new List<User>();

            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }

            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };

            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleEditModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);

                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }

                }

				foreach (var userId in model.IdsToDelete ?? new string[] { })
				{
					var user = await _userManager.FindByIdAsync(userId);
					if (user != null)
					{
						var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);

						if (!result.Succeeded)
						{
							foreach (var error in result.Errors)
							{
								ModelState.AddModelError("", error.Description);
							}
						}
					}

				}

			}
			return RedirectToAction("UpdateRole", "Role", new {id = model.RoleId});

		}
        
	}
}
