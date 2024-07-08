using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DomainShared
{
	public class DomainResponseEntity<T>
	{
		public bool IsSuccess { get; set; } = false;
		public string ErrorDetail { get; set; } = string.Empty;
		public T? Entity { get; set; }
	}
}
