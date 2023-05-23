namespace Lab_2;

class Program
{
	static public void Main()
	{

		Organization organization = new Organization("Org1","Orga", "djksk");


		University university = new University();


		Department department = new Department("Dep1","01","aaahhh456");
		Department department1 = new Department("Dep2", "02", "aETKS5");

		Faculty faculty = new Faculty("FIT", "IT", " as");
		Faculty faculty1 = new Faculty("HTIT", "TIT", " 392");
		faculty.addDepartment(department);
		faculty1.addDepartment(department1);
		university.addFaculty(faculty);
		university.addFaculty(faculty1);
		//university.delFaculty(0);
		organization.printinfo();
		
		faculty.printinfo();
		faculty1.printinfo();
		faculty.updDepartment(0);
		faculty.printinfo();





	}
}
public class Job
{
	public string NameDepartament
	{
		get;
	}
}
public class JobVacancy
{
	public string NameDepartament
	{
		get;
		set;
	}
}
public class Empoloee
{
	public string NameDepartament 
	{ 
		get;
	}
}