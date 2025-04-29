using Microsoft.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SHLDotNetTrainingBatch1.ConsoleApp2
{
	internal class HomeworkService
	{
		private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
		{
			DataSource = ".",
			InitialCatalog = "DotNetTrainingBatch1",
			UserID = "sa",
			Password = "sasa@1234",
			TrustServerCertificate = true
		};

		public void Read()
		{
			SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
			connection.Open();
			string query = "select * from Tbl_Homework";
			SqlCommand cmd = new SqlCommand(query, connection);
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);

			connection.Close();

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				DataRow dr = dt.Rows[i];
				Console.WriteLine(dr["No"]);
				Console.WriteLine(dr["Name"]);
				Console.WriteLine(dr["GitHubUserName"]);
				Console.WriteLine("-------------------------");
			}
			foreach (DataRow dr in dt.Rows)
			{
				Console.WriteLine(dr["No"]);
				Console.WriteLine(dr["Name"]);
				Console.WriteLine(dr["GitHubUserName"]);
				Console.WriteLine("-------------------------");
			}
		}

		public void Detail(int no)
		{
			SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
			connection.Open();

			string query = $"select * from Tbl_Homework where No = @No";

			SqlCommand cmd = new SqlCommand(query, connection);
			cmd.Parameters.AddWithValue("@No", no);

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);

			connection.Close();

			if (dt.Rows.Count == 0)
			{
				Console.WriteLine("No record found.");
				return;
			}

			DataRow dr = dt.Rows[0];
			Console.WriteLine(dr["No"]);
			Console.WriteLine(dr["Name"]);
			Console.WriteLine(dr["GitHubUserName"]);
			Console.WriteLine("-------------------------");
		}

		public void Create()
		{
			Console.Write("Enter Name: ");
			string name = Console.ReadLine()!;

			Console.Write("Enter GitHubUserName: ");
			string githubUserName = Console.ReadLine()!;

			Console.Write("Enter GitHubRepoLink: ");
			string githubRepoLink = Console.ReadLine()!;

			SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
			connection.Open();

			string query = $@"
							INSERT INTO [dbo].[Tbl_Homework]
									   ([Name]
									   ,[GitHubUserName]
									   ,[GitHubRepoLink])
								 VALUES
									   (@Name
									   ,@GitHubUserName
									   ,@GitHubRepoLink)";
			SqlCommand cmd = new SqlCommand(query, connection);
			cmd.Parameters.AddWithValue("@Name", name);
			cmd.Parameters.AddWithValue("@GitHubUserName", githubUserName);
			cmd.Parameters.AddWithValue("@GitHubRepoLink", githubRepoLink);

			int result = cmd.ExecuteNonQuery();

			connection.Close();
		}

		public void Update()
		{
		BeforeInputId:
			Console.Write("Enter Id: ");
			string inputId = Console.ReadLine()!;
			int id = 0;
			bool isInt = int.TryParse(inputId , out id);
			if (!isInt)
			{
				Console.WriteLine("Invalid Id.");
				goto BeforeInputId;
			}

			SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
			connection.Open();
			string query = $"select * from Tbl_Homework where No = @Id";
			SqlCommand cmd = new SqlCommand(query, connection);
			cmd.Parameters.AddWithValue("@Id", id);
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);
			connection.Close();
			if(dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				Console.WriteLine(dr["No"]);
				Console.WriteLine(dr["Name"]);
				Console.WriteLine(dr["GitHubUserName"]);
				Console.WriteLine("-------------------------");
			}
			else
			{
				Console.WriteLine("No record found.");
				return;
			}

			Console.Write("Enter Name: ");
			string name = Console.ReadLine()!;

			Console.Write("Enter GitHubUserName: ");
			string githubUserName = Console.ReadLine()!;

			Console.Write("Enter GitHubRepoLink: ");
			string githubRepoLink = Console.ReadLine()!;

			SqlConnection updateConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
			connection.Open();

			string updateQuery = $@"
									UPDATE [dbo].[Tbl_Homework]
									   SET [Name] = @Name
										  ,[GitHubUserName] = @GitHubUserName 
										  ,[GitHubRepoLink] = @GitHubRepoLink
									 WHERE No = @Id";
			SqlCommand updateCmd = new SqlCommand(query, connection);
			cmd.Parameters.AddWithValue("@Id", id);
			cmd.Parameters.AddWithValue("@Name", name);
			cmd.Parameters.AddWithValue("@GitHubUserName", githubUserName);
			cmd.Parameters.AddWithValue("@GitHubRepoLink", githubRepoLink);

			int result = cmd.ExecuteNonQuery();

			connection.Close();
		}

		public void Delete()
		{
			Console.Write("Enter Id: ");
			string inputId = Console.ReadLine()!;
			int id = 0;
			bool isInt = int.TryParse(inputId, out id);
			if (!isInt)
			{
				Console.WriteLine("Invalid Id.");
				return;
			}

			Console.Write("Are you sure to delete this id? (y/n): ");
			string confirm = Console.ReadLine()!;
			if (confirm is "y")
			{
				SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
				connection.Open();
				string query = $"delete from Tbl_Homework where No = @Id";
				SqlCommand cmd = new SqlCommand(query, connection);
				cmd.Parameters.AddWithValue("@Id", id);
				int result = cmd.ExecuteNonQuery();
				connection.Close();
				Console.WriteLine("Deleted Successfully.");
			}			
		}

		public void Login()
		{
			Console.Write("Enter UserName: ");
			string userName = Console.ReadLine()!;

			Console.Write("Enter Password: ");
			string password = Console.ReadLine()!;

			string query = @$"select * from Tbl_User 
								where 
								UserName = @UserName and 
								Password = @Password";

			SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
			connection.Open();
			SqlCommand cmd = new SqlCommand(query, connection);
			cmd.Parameters.AddWithValue("@UserName", userName);
			cmd.Parameters.AddWithValue("@Password", password);

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);

			connection.Close();
		}

		public void LoginWithStoredProcedure()
		{
			Console.Write("Enter UserName: ");
			string userName = Console.ReadLine()!;

			Console.Write("Enter Password: ");
			string password = Console.ReadLine()!;

			string query = @$"Sp_Login";

			SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
			connection.Open();
			SqlCommand cmd = new SqlCommand(query, connection);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@UserName", userName);
			cmd.Parameters.AddWithValue("@Password", password);

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);

			connection.Close();
		}
	}
}
