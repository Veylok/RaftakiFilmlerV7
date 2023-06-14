using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesV7.Classes;
using ServicesV7.ViewModels;

namespace RaftakiFilmlerV7.Controllers
{
    
    public class FilmController : Base
    {
        private FilmService filmService;

        public FilmController()
        {
           filmService = new FilmService();
        }
        public IActionResult Index()
        {           
            var vm = filmService.getFilmVMList();
            return View(vm);
            //var filmService= new FilmService();
        }
        public IActionResult Create()
        {        
            //var filmService = new FilmService();
            var vm = filmService.GetFilmVM_CE();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(FilmVM_CE vm)
        {
            //var filmService = new FilmService();
            filmService.SaveFilm(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            var result =filmService.DeleteFilm(id);         
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var vm = filmService.GetFilmVMEdit_CE(id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(FilmVM_CE vm)
        {     
            filmService.EditFilm(vm);
            return RedirectToAction("Index");
        }
    }
}
