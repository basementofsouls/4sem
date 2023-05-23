using Lec03LibN;
class Program
{
	private static void Main()
	{
		Console.WriteLine("Лаборатнорная работа 3");

		IFactory level1Factory = Lec03Blib.GetL1();
		IFactory level2Factory = Lec03Blib.GetL2(2.0f);
		IFactory level3Factory = Lec03Blib.GetL3(1.5f, 10.0f);

		Employee employee1 = new Employee(level1Factory.GetA(8.0f));
		Employee employee2 = new Employee(level1Factory.GetB(20.0f, 4.0f));
		Employee employee3 = new Employee(level1Factory.GetC(15.0f, 5.0f, 55.0f));


		float bonus1 = employee1.CalculateBonus(8.0f);
		float bonus2 = employee2.CalculateBonus(6.0f);
		float bonus3 = employee3.CalculateBonus(7.0f);

		Employee employee4 = new Employee(level2Factory.GetA(8.0f));
		Employee employee5 = new Employee(level2Factory.GetB(20.0f, 4.0f));
		Employee employee6 = new Employee(level2Factory.GetC(15.0f, 5.0f, 55.0f));


		float bonus4 = employee4.CalculateBonus(8.0f);
		float bonus5 = employee5.CalculateBonus(6.0f);
		float bonus6 = employee6.CalculateBonus(7.0f);

		Employee employee7 = new Employee(level3Factory.GetA(8.0f));
		Employee employee8 = new Employee(level3Factory.GetB(20.0f, 4.0f));
		Employee employee9 = new Employee(level3Factory.GetC(15.0f, 5.0f, 55.0f));


		float bonus7 = employee7.CalculateBonus(8.0f);
		float bonus8 = employee8.CalculateBonus(6.0f);
		float bonus9 = employee9.CalculateBonus(7.0f);

		Console.WriteLine($"L1-A bonus: {bonus1}");
		Console.WriteLine($"L1-B bonus: {bonus2}");
		Console.WriteLine($"L1-C bonus: {bonus3}");
		Console.WriteLine($"L2-A bonus: {bonus4}");
		Console.WriteLine($"L2-B bonus: {bonus5}");
		Console.WriteLine($"L2-C bonus: {bonus6}");
		Console.WriteLine($"L3-A bonus: {bonus7}");
		Console.WriteLine($"L3-B bonus: {bonus8}");
		Console.WriteLine($"L3-C bonus: {bonus9}");
	}
}