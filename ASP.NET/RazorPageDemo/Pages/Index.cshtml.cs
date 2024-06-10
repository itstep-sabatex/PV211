using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace RazorPageDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IStringLocalizer<IndexModel> _localizer;

        public IndexModel(ILogger<IndexModel> logger,IStringLocalizer<IndexModel> stringLocalizer)
        {
            _logger = logger;
            _localizer = stringLocalizer;
        }

        public void OnGet() //handler
        {
            var userName = "Den Rukle";
            var str = $"User {userName} loggin to system!";
            var s = _localizer["User {0} loggin to system!",userName];

        }
        public void OnPost() //handler
        {

        }
        public async Task OnPostAsync() //handler
        {
            await Task.Yield();
        }
    }
}
