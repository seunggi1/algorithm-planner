﻿using algorithm_planner.Models;

namespace algorithm_planner.Data
{
    public interface IPlanner
    {
        public Task<List<PlannerModel>> GetAllAsync();
        public Task<List<PlannerModel>> GatAllTypeAsync(EPlanner type);
        public Task<int> InsertAsync(PlannerModel data);
        public Task<int> UpdateAsync(PlannerModel data);
        public Task<int> ReplaceAsync(PlannerModel data);
        public Task<int> DeleteAsync(PlannerModel data);
    }
}
