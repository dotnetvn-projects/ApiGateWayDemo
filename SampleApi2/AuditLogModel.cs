using System;

namespace SampleApi2
{
    public class AuditLogModel
    {
        public Guid Id { get; set; }
        public string AccountName { get; set; }
        public string Module { get; set; }
        public string Action { get; set; }
        public DateTime IssuedDate { get; set; }
    }
}
