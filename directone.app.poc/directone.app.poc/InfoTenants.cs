using System;

namespace DirectOne.App.Poc
{
    public class InfoTenants
    {
        public string TenantId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public InfoTenants(string tenantId, DateTime startDate, DateTime endDate)
        {
            TenantId = tenantId;
            StartDate = startDate;
            EndDate = endDate;
        }        
    }
}