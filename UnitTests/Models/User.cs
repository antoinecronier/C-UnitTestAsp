using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTests.Models
{
    public class User : DbEntity
    {
        private string firstname;
        private string lastname;
        private Role role;

        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public Role Role { get => role; set => role = value; }
    }
}