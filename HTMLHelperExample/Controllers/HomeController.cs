using System.Collections.Generic;
using System.Web.Mvc;

namespace HTMLHelperExample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //some sample meaningless data. One thing to note, your data is usually IEnumerable or a List, you can convert your data to a dictionary and have key value pairs
            var data = new Dictionary<string, List<int>>
            {
                {"New Zealand", new List<int>
                {
                    5, 23, 15
                }},
                {"UK",  new List<int>
                {
                    2, 6, 12
                }},
                {"USA", new List<int>
                {
                    8, 3
                }},
                {"China", new List<int>
                {
                    5
                }},
                {"Australia", new List<int>
                {
                    4
                }},
                {"France", new List<int>
                {
                    7, 1
                }}
            };

            return View(data);
        }
    }
}