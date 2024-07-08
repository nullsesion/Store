using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.CQRS
{
	public class AbstractRequestPages
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}
