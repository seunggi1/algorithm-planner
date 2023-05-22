using Microsoft.AspNetCore.Mvc;
using algorithm_planner.Data;
using algorithm_planner.Models;

namespace algorithm_planner.Controllers
{      
    public class PlannerController : Controller
    {
        private readonly IPlanner _dataRepository;

        public PlannerController(IPlanner dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _dataRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<JsonResult> Insert([FromBody]PlannerModel data)
        {
            return Json(await _dataRepository.InsertAsync(data));            
        }

        [HttpPut]
        public async Task<JsonResult> Update([FromBody] PlannerModel data)
        {
            return Json(await _dataRepository.ReplaceAsync(data));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            return Json(null);
        }       
    }
}
