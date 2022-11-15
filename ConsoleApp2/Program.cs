using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = "INSERT INTO News(Title,vContent,ModifyTime)VALUES(@Title,@vContent,getdate())";
			var dpHelper = new SqlDbHelper("default");
			
			
				try
				{
					
				    SqlParameter titleParam = new SqlParameter("@Title", SqlDbType.NVarChar, 50){Value = "create test -title"};
					SqlParameter contentParam = new SqlParameter("@vContent", SqlDbType.NVarChar, 3000){Value = "create test -content"};
				    var parameters =new SqlParameter[] {titleParam,contentParam};

				    



				    dpHelper.ExecuteNonQuery(sql, parameters);
					Console.WriteLine("紀錄已新增");
					

				}
				catch (Exception ex)
				{
					Console.WriteLine();
				}
				

			}
		}
	}
}
