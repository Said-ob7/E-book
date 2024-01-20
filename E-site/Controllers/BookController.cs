using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_site.Controllers
{
	public class BookController : Controller
	{
        private readonly LivreService _livreService;

        public BookController(LivreService livreService)
        {
            _livreService = livreService;
        }

        // GET: Book
        public ActionResult Index()
        {
            var allBooks = _livreService.ListAllBooks();
            return View(allBooks);
        }


        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            // Fetch the book details by ID
            var bookDetails = _livreService.GetBookDetails(id);

            if (bookDetails == null)
            {
                return NotFound(); // Return a 404 Not Found if the book is not found
            }

            return View(bookDetails);
        }
        public ActionResult ChapterDetails(int livreId, int chapitreId)
        {
            var chapterDetails = _livreService.GetChapterDetails(livreId, chapitreId);

            if (chapterDetails == null)
            {
                return NotFound(); // Or handle the case where the chapter is not found
            }

            return View(chapterDetails);
        }


        // GET: Book/Create
        public ActionResult Create()
		{
			return View();
		}

		// POST: Book/Create
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

		// GET: Book/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Book/Edit/5
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

		// GET: Book/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Book/Delete/5
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
