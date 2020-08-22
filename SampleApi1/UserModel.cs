using System;

namespace SampleApi1
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string AccountName { get; set; }
    }
}
