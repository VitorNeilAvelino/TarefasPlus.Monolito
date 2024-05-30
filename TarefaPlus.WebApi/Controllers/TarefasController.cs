using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TarefaPlus.WebApi.Controllers
{
    public class TarefasController : Controller
    {
        // GET: TarefasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TarefasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TarefasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TarefasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TarefasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TarefasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TarefasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TarefasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
