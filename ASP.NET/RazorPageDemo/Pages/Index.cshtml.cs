using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet() //handler
        {

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
