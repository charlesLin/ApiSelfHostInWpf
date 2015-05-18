using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows;

namespace Kanban
{
	public class CountingController : ApiController
	{
		public void Post()
		{
			Action action = () =>
			{
				var main = Application.Current.MainWindow as MainWindow;
				main.Increase();
			};
			Application.Current.Dispatcher.Invoke(action);

		}
	}
}
