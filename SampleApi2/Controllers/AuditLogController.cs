using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleApi2.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{v:apiVersion}/[controller]")]
    public class AuditLogController : ControllerBase
    {

        private readonly ILogger<AuditLogController> _logger;
        private IList<AuditLogModel> _auditLogModels;

        public AuditLogController(ILogger<AuditLogController> logger)
        {
            _logger = logger;
            CreateDemoData();
        }

        [HttpGet("list")]
        public IEnumerable<AuditLogModel> GetList()
        {
            return _auditLogModels;
        }

        [HttpGet("list-by-user/{accountName}")]
        public IEnumerable<AuditLogModel> GetListByUser(string accountName)
        {
            return _auditLogModels.Where(c=>c.AccountName == accountName);
        }

        private void CreateDemoData()
        {
            _auditLogModels = new List<AuditLogModel>();
            for (int i = 0; i < 5; i++)
            {
                var index = i + 1;
                _auditLogModels.Add(new AuditLogModel
                {
                    AccountName = $"LinhPham_{index}",
                    IssuedDate = DateTime.Now.AddDays(-index),
                    Action = GetAction(index),
                    Module = GetModule(index),
                    Id = Guid.NewGuid(),
                });
            }
        }

        private string GetAction(int i)
        {
            if (i % 2 == 0)
            {
                return "Insert Data";
            }
            return "Update Data";
        }

        private string GetModule(int i)
        {
            switch (i)
            {
                case 1:
                    return "UserManagement";
                case 2:
                    return "ProductManagement";
                case 3:
                    return "CatalogManagement";
                case 4:
                    return "ArticleManagement";
                case 5:
                    return "Configuration";
                default:
                    return string.Empty;
            }
        }
    }
}
