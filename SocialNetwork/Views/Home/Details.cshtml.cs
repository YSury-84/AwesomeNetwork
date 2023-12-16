using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialNetwork.Views.Home
{
    public class DetailsModel : PageModel
    {
        public string uLogin;
        public void OnGet(string userLogin)
        {
            uLogin = userLogin;
        }
    }
}
