using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UnitTests.Models
{
    public class DbEntity
    {
		private long id;

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id
		{
			get { return id; }
			set { id = value; }
		}

	}
}