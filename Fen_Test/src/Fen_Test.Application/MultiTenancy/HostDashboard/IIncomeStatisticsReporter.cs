using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fen_Test.MultiTenancy.HostDashboard.Dto;

namespace Fen_Test.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}