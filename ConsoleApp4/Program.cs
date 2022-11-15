using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string constring = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			string sql = "SELECT Id,Title FROM News WHERE Id>@Id ORDER BY Id DESC";

			SqlDbHelper dbHelper = new SqlDbHelper(constring);
			try
			{
				var parameters = new SqlParameterBuilder().AddNInt("id",0).Build();
				DataTable news = dbHelper.Select(sql, parameters);
				foreach(DataRow row in news.Rows)
				{
					int id = row.Field<int>("id");
					string title = row.Field<string>("title");
					Console.WriteLine($"Id={id},title={title}");
				}
				
			}
			catch (Exception ex)
			{
				Console.WriteLine("錯誤");
			}


























			/*#region 使用Using
			using (var conn = new SqlConnection(constring))
			{
				try
				{
					var command = new SqlCommand(sql, conn);
					var parameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int) { Value = 0 } };
					command.Parameters.AddRange(parameters);
					SqlDataAdapter adapter = new SqlDataAdapter(command);
					DataSet dataSet = new DataSet();
					adapter.Fill(dataSet, "News");
					DataTable news = dataSet.Tables["news"];
					foreach (DataRow row in news.Rows)
					{
						int id = row.Field<int>("id");
						string title = row.Field<string>("title");
						Console.WriteLine($"Id={id},title={title}");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("錯誤");
				}


				#endregion
			}*/


		}
	}
}
