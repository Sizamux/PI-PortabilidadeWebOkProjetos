using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PI_PorrtabilidadeWebOkPrrojetos.Controllers
{
    [Authorize]//Anotação Identity
    public class FinanceiroController : Controller
    {
        // GET: FinanceiroController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FinanceiroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FinanceiroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinanceiroController/Create
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

        // GET: FinanceiroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FinanceiroController/Edit/5
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

        // GET: FinanceiroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FinanceiroController/Delete/5
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
