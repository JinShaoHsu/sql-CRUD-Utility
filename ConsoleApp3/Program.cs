using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"UPDATE News 
	SET Title=@Title, 
	vContent=@vContent, 
	ModifyTime=getdate() 
WHERE Id=@Id";

			var dbHelper = new SqlDbHelper("default");
			try
			{
				var parameters = new SqlParameterBuilder()
					.AddNVarchar("title", 50, "t2 modified")
					.AddNVarchar("vContent", 3000, "c2 modified")
					.AddNInt("id", 3)
					.Build();

				dbHelper.ExecuteNonQuery(sql, parameters);

				Console.WriteLine("記錄已 update");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"操作失敗, 原因 :{ex.Message}");
			}
		}
	}
}
