﻿using System;
using System.Collections.Generic;
using leave_management.Data;

namespace leave_management.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation> 
    {
        bool CheckAllocation(int leavetypeid, string employeeid);

        ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string id);

        LeaveAllocation GetLeaveAllocationByEmployeeAndType(string id, int leavetypeid);
    }
}
