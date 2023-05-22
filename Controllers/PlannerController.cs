using Microsoft.AspNetCore.Mvc;
using algorithm_planner.Data;
using algorithm_planner.Models;
using System.Net;

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
        [Route("")]
        [Route("/planner")]
        public async Task<ActionResult> Index()
        {
            return View(await _dataRepository.GetAllAsync());
        }

        [HttpPost("/planner")]
        public async Task<ActionResult> Insert([FromBody]PlannerModel data)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

            return Json(await _dataRepository.InsertAsync(data));            
        }

        [HttpPut("/planner")]      
        public async Task<ActionResult> Update([FromBody]PlannerModel data)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

            return Json(await _dataRepository.ReplaceAsync(data));
        }

        [HttpDelete("/planner")]
        public JsonResult Delete(int id)
        {
            return Json(null);
        }       
    }
}
