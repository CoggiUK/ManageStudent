using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManageStudent.Models;
using System.Net.Http;
using ManageStudent.DTO;

namespace ManageStuden.Pages.Lecture
{
    public class ScheduleModel : PageModel
    {
        public void OnGet(int id)
        {
            HttpClient _httpClient = new HttpClient();

            HttpResponseMessage rp_grades = _httpClient.GetAsync("https://localhost:7135/api/Grades").Result;
            ViewData["rp_grades"] = rp_grades.Content.ReadFromJsonAsync<List<Grade>>().Result;

            HttpResponseMessage rp_semesters = _httpClient.GetAsync("https://localhost:7135/api/Semesters").Result;
            ViewData["rp_semesters"] = rp_semesters.Content.ReadFromJsonAsync<List<Semester>>().Result;

            HttpResponseMessage rp_Schedules = _httpClient.GetAsync("https://localhost:7135/api/Schedules").Result;
            ViewData["rp_Schedules"] = rp_Schedules.Content.ReadFromJsonAsync<List<ScheduleDTO>>().Result;

            HttpResponseMessage rp_semesters_id = _httpClient.GetAsync($"https://localhost:7135/api/Schedules/FindbySemeter/{id}").Result;
            ViewData["rp_semesters_id"] = rp_semesters_id.Content.ReadFromJsonAsync<List<Schedule>>().Result;
        }
        



            HttpClient _httpCilent = new HttpClient();

            HttpResponseMessage rp_grades = _httpCilent.GetAsync("https://localhost:7135/api/Grades").Result;
            ViewData["rp_grades"] = rp_grades.Content.ReadFromJsonAsync<List<Grade>>().Result;

            HttpResponseMessage rp_semesters = _httpCilent.GetAsync("https://localhost:7135/api/Semesters").Result;
            ViewData["rp_semesters"] = rp_semesters.Content.ReadFromJsonAsync<List<Semester>>().Result;

            HttpResponseMessage rp_Schedules = _httpCilent.GetAsync("https://localhost:7135/api/Schedules").Result;
            ViewData["rp_Schedules"] = rp_Schedules.Content.ReadFromJsonAsync<List<Schedule>>().Result;

            HttpResponseMessage rp_semesters_id = _httpCilent.GetAsync($"https://localhost:7135/api/Schedules/FindbySemeter/{id}").Result;
            ViewData["rp_semesters_id"] = rp_semesters_id.Content.ReadFromJsonAsync<List<Semester>>().Result;
        }
    }
}
