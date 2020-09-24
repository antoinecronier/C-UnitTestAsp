using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTests.Models
{
    public class Role : DbEntity
    {
        private string name;

        public string Name { get => name; set => name = value; }
    }
}