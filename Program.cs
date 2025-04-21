Console.WriteLine("Hello, World!");
Console.ReadLine();

int[] a = { };
var res = a.FirstOrDefault();
Console.WriteLine(res);

int[] numbers = { 1, 2, 3, 4, 5 };

var result = numbers.FirstOrDefault();

result = numbers.Sum();

Console.WriteLine(result);

foreach (var number in numbers)
{
	if (number % 2 == 0)
	{
		Console.WriteLine(number);
	}
}

var lst = numbers.Where(x => x % 2 == 0);
foreach (var number in lst)
{
	Console.WriteLine(number);
}

File.WriteAllText("test.txt", "Hello World Testing");

var readText = File.ReadAllText("test.txt");

decimal price = 1000000;
Console.WriteLine(price.ToString("n0"));

DateTime now = DateTime.Now;
Console.WriteLine(now.ToString("yyyy-MM-dd"));

IResume resume = new Resume();
resume = new Resume();

public interface IResume
{ 


}


public class ResumeV2 : IResume
{
	public string Name { get; set; }
	public int Age { get; set; }
}

public class Resume : IResume {
	public string Name { get; set; }
	public int Age { get; set; }
}

interface ITransfer
{
	void Create();
	void Update();
	void Delete();
	void Read();

}

public class KPay : ITransfer
{
	public void Create()
	{
		Console.WriteLine("KPay Create");
	}
	public void Update()
	{
		Console.WriteLine("KPay Update");
	}
	public void Delete()
	{
		Console.WriteLine("KPay Delete");
	}
	public void Read()
	{
		Console.WriteLine("KPay Read");
	}
}

