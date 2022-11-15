using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string constring = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			Console.WriteLine(constring);

			var conn = new SqlConnection(constring);
			conn.Open();

			Console.WriteLine("connected");
			conn.Close();

		}
	}
}
