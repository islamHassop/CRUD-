using CRECT2.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace CRECT2.Controllers
{
    

    public class AcountVMController : Controller
    {
       private  UserManager<IdentityUser> userManager;
       private  SignInManager<IdentityUser> signInManager;
        public AcountVMController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public IActionResult Regstration()
        {
            return View();
        }
        [HttpPost]
        public  async Task <IActionResult> Regstration(USER_VM  newacountVM)
        {
            if(ModelState.IsValid==true)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = newacountVM.UserName;
                user.Email = newacountVM.Email;

               IdentityResult result = await userManager.CreateAsync(user,newacountVM.password);
                    if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Regstration");
                }
                else
                {
                    foreach (var item in result.Errors)
                        ModelState.AddModelError("",item.Description);
            
                }
            }
            return View(newacountVM);

        }
    }
}
