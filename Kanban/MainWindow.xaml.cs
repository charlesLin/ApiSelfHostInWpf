using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Web.Http.SelfHost;

namespace Kanban
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private int _count = 0;
		public MainWindow()
		{
			InitializeComponent();
			InitWebApi();
		}

		private void InitWebApi()
		{

			var config = new HttpSelfHostConfiguration("http://localhost:8080");
			config.Routes.MapHttpRoute(
				name: "API",
				routeTemplate: "{controller}/{id}",
				defaults: new { id = RouteParameter.Optional});


			var server = new HttpSelfHostServer(config);
				server.OpenAsync().Wait();
		}

		public void Increase()
		{
			Interlocked.Increment(ref _count);
			_count++;

			Action action = () =>
			{
				Count.Text = _count.ToString();
			};
			Dispatcher.BeginInvoke(action);

		}
	}
}
