using SHLDotNetTrainingBatch1.ConsoleApp2;

//SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=DotNetTrainingBatch1;User ID=sa;Password=sasa@1234;TrustServerCertificate=true;");

//connection.Open();
//connection.Close();

//SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
//connectionStringBuilder.DataSource = "localhost";
//connectionStringBuilder.InitialCatalog = "DotNetTrainingBatch1";
//connectionStringBuilder.UserID = "sa";
//connectionStringBuilder.Password = "sasa@1234";
//connectionStringBuilder.TrustServerCertificate = true;

HomeworkService homeworkService = new HomeworkService();
//homeworkService.Read();
//homeworkService.Detail(1);
//homeworkService.Update();
homeworkService.Delete();

