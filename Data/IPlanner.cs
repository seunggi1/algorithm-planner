using algorithm_planner.Models;

namespace algorithm_planner.Data
{
    public interface IPlanner
    {
        public Task<List<PlannerModel>> GetAllAsync();
        public Task<List<PlannerModel>> GatAllTypeAsync();
        public Task<int> InsertAsync(PlannerModel data);
        public Task<int> UpdateAsync(PlannerUpdateModel data);
        public Task<int> DeleteAsync();
    }
}
