using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleApi1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{v:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IList<UserModel> _userModels;
        public UserController(ILogger<UserController> logger)
        {
            CreateDemoData();
            _logger = logger;
        }

        [HttpGet("list")]
        public IEnumerable<UserModel> GetList()
        {
            return _userModels;
        }

        [HttpGet("info/{accountName}")]
        public UserModel GetUserInfo(string accountName)
        {
            return _userModels.FirstOrDefault(c=>c.AccountName == accountName);
        }

        private void CreateDemoData()
        {
            _userModels = new List<UserModel>();

            for (int i = 0; i < 5; i++)
            {
                var index = i + 1;
                _userModels.Add(new UserModel
                {
                    AccountName = $"LinhPham_{index}",
                    CreatedDate = DateTime.Now.AddDays(-index),
                    Email = $"LinhPham_{index}@gmail.com",
                    Id = Guid.NewGuid(),
                    Name = $"LinhPham_{index}"
                });
            }
        }
    }
}
