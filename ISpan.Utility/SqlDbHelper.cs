using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Utility
{
	public class SqlDbHelper
	{
		private string constring;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="keyOfConstring">app.config裡的值,例如'default'</param>
		public SqlDbHelper(string keyOfConstring)
		{
			 constring = System.Configuration.ConfigurationManager.ConnectionStrings[keyOfConstring].ConnectionString;
		}
		public void ExecuteNonQuery(string sql, SqlParameter[] parameter)
		{
			using (var conn = new SqlConnection(constring))
			{
				SqlCommand command = new SqlCommand(sql, conn);
				conn.Open();
				command.Parameters.AddRange(parameter);
				command.ExecuteNonQuery();
			}
		}
		public DataTable Select(string sql, SqlParameter[] parameters)
		{
			using(var conn = new SqlConnection(constring))
			{
				var command = new SqlCommand(sql, conn);
				if(parameters != null)
				{command.Parameters.AddRange(parameters);}
				
				SqlDataAdapter adapter = new SqlDataAdapter(command);
				DataSet dataSet = new DataSet();
				adapter.Fill(dataSet, "News");
				return dataSet.Tables["News"];  
			}
		}
	}
}
