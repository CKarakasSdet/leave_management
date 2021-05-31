﻿using System;
using System.Collections.Generic;
using System.Linq;
using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;

namespace leave_management.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository 
    {
        private readonly ApplicationDbContext _db;

        public LeaveRequestRepository(ApplicationDbContext db)
        {
            _db = db; 
        }

        public bool Create(LeaveRequest entity)
        {
            _db.LeaveRequests.Add(entity);
            return Save(); 
        }

        public bool Delete(LeaveRequest entity)
        {
            _db.LeaveRequests.Remove(entity);
            return Save(); 
        }

        public ICollection<LeaveRequest> FindAll()
        {
            var LeaveRequests = _db.LeaveRequests
                                .Include(q => q.RequestingEmployee)
                                .Include(q => q.ApprovedBy)
                                .Include(q => q.LeaveType)
                                .ToList(); 
            return LeaveRequests; 
        }

        public LeaveRequest FindById(int id)
        {
            var LeaveRequest = _db.LeaveRequests
                                .Include(q => q.RequestingEmployee)
                                .Include(q => q.ApprovedBy)
                                .Include(q => q.LeaveType)
                                .FirstOrDefault(q => q.Id == id);
            return LeaveRequest; 

        }

        public ICollection<LeaveRequest> GetRequestsByEmployee(string employeeid)
        {
            throw new NotImplementedException();
        }

        public bool IsPresent(int id)
        {
            var present = _db.LeaveRequests.Any(q => q.Id == id);
            return present;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();

            return changes > 0; 
        }

        public bool Update(LeaveRequest entity)
        {
            _db.LeaveRequests.Update(entity);
            return Save(); 
        }
    }
}