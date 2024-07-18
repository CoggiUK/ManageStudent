using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Net.Http;
using ManageStudentWeb.Models;

namespace ManageStudentWebWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            HttpClient _httpClient = new HttpClient();

            HttpResponseMessage responseAuthor = _httpClient.GetAsync("https://localhost:7135/api/Students").Result;
            var Student = responseAuthor.Content.ReadFromJsonAsync<List<Student>>().Result;
            var rs1 = new List<Student>();
            rs1 = Student.ToList();
            ViewData["student"] = Student.ToList();
        }

         
    }
}
