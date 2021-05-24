using System;
using System.Collections.Generic;
using System.Linq;
using leave_management.Contracts;
using leave_management.Data;

namespace leave_management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository 
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db; 
        }

        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save(); 
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save(); 
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            throw new NotImplementedException();
        }

        public LeaveAllocation FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsPresent(int id)
        {
            var present = _db.LeaveAllocations.Any(q => q.Id == id);
            return present;
        }

        public bool Save()
        {
           var changes =  _db.SaveChanges();
            return changes > 0; 
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save(); 
        }
    }
}
