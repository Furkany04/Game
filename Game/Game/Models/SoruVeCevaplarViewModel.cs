using Model.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Game.Models
{
    public class SoruVeCevaplarViewModel
    {
        public string SoruText { get; set; }
        public List<string> Cevaplar { get; set; }
        public int puan {  get; set; }
        public int HighScore {  get; set; }
        public string Username {  get; set; }
        public string Password {  get; set; }
    }
}
