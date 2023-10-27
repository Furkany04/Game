using Business.Services.Abstract;
using Game.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using System;
using System.Diagnostics;

namespace Game.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQuestionService questionService;
        private readonly IAnswerService answerService;
        private readonly Random random = new Random();
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public HomeController(ILogger<HomeController> logger, IUserService userService, IQuestionService questionService, IAnswerService answerService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            this.questionService = questionService;
            this.answerService = answerService;
            _userManager=userManager;
            _signInManager=signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OnlineOrOffline()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GameStart(SoruVeCevaplarViewModel Model)
        {
            TempData["Username"] = Model.Username;
            User user;
            if (Model.Username!=null && Model.Password!=null)
            {

                user = await _userManager.FindByNameAsync(Model.Username);

                if (user!=null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, Model.Password, false, true);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Play");
                    }
                    else
                    {
                        //Şifre yanlış
                        ModelState.AddModelError("", "şifre hatalı");
                        return View("Index");
                    }
                }


            else
                {
                    //boş girtilirse hata
                    ModelState.AddModelError("", "Kullanıcı  bulunamadı");
                    return View("Index");
                }
            }
            return View("Index");
            
        }
        [HttpPost]
        public async Task<IActionResult> Kaydol(SoruVeCevaplarViewModel Model)
    {
            TempData["Username"] = Model.Username;
            if (Model.Username!=null && Model.Password!=null)
            {
                var Users = await _userManager.FindByNameAsync(Model.Username);
                if (Users!= null)
                {
                    //kullanıcı adı kullanılıyor
                    return View("Index");
                }
                else
                {
                    var user = new User(Model.Username)
                    {
                        Score=0,
                        HighScore=0,     
                        UserName=Model.Username,
                    };
                    var result = await _userManager.CreateAsync(user, Model.Password);
                    if (result.Succeeded)
                    {

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Play");
                    }
                    return View("Index");
                }
            }
            else
            {
                //boş girtilirse hata
                return View("Index");
            }
    }
            public async Task<IActionResult> Play(SoruVeCevaplarViewModel Model)
        {
            var username = TempData["Username"] as string;
            TempData["Username"] = username;
            int randomValue = random.Next(1, 3);
            TempData["randomValue"] = randomValue;
            int puan = TempData["Puan"] as int? ?? 0;
            var b = questionService.GetAll().Where(m=>m.Id== randomValue);
            var k = answerService.GetAll().Where(m => m.QuestionID==randomValue).ToList(); 
            var d = b.SingleOrDefault();

            Model.SoruText = d.QuestionText;
            Model.Username=username;
            Model.puan = puan;


            Model.Cevaplar = new List<string>();
            foreach (var item in k)
            {
                Model.Cevaplar.Add(item.AnswerText);             
            }

            return View(Model);

        }

        [HttpPost]
        public async Task<IActionResult> Play(string SecilenCevap , SoruVeCevaplarViewModel Model)
        {
            
            var username = TempData["Username"] as string;
            int? randomValue = TempData["randomValue"] as int?;
            TempData["UsernameLast"] = username;
            var b = questionService.GetAll().Where(m => m.Id== randomValue);
            var p = b.SingleOrDefault();
            var k = answerService.GetAll().Where(m => m.QuestionID==randomValue && m.IsCorrect==true).ToList();
            var d = k.SingleOrDefault();
            var user = await _userManager.FindByNameAsync(username);
            
            if (SecilenCevap == d.AnswerText)
            {
                user.Score = user.Score + p.PointValue;
                TempData["Puan"] = user.Score;
                await _userManager.UpdateAsync(user);
            }
            else
            {
                TempData["EndPuan"] = user.Score;
                Model.puan = 0;
                user.Score = 0;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("GameEnd");
            }

            await _userManager.UpdateAsync(user);
            return RedirectToAction("Play");
        }
        public async Task<IActionResult> GameEnd(SoruVeCevaplarViewModel model)
        {
            var username = TempData["UsernameLast"] as string;
            var user = await _userManager.FindByNameAsync(username);
            
            
            int EndScore = TempData["EndPuan"] as int? ?? 0;
            model.puan = EndScore;
            model.Username = username;
            
            if (user.HighScore >=EndScore)
            {
                user.HighScore = user.HighScore;
                int a = user.HighScore as int? ??0;
                model.HighScore =a;


            }
            else
            {
                user.HighScore = EndScore;
                int a = user.HighScore as int? ??0;
                model.HighScore =a;
                await _userManager.UpdateAsync(user);

            }
            
            return View(model);
        }
        public IActionResult BestUsers()
        {
            var top10Users = _userManager.Users
    .OrderByDescending(u => u.HighScore)
    .Take(10)
    .ToList();

            return View(top10Users);
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}