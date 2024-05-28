using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式_改造抽象工厂模式_
{

	public class DataDB
	{
		private  string _db ;

		public string DB
		{
			get { return _db; }
			set { _db = value; }
		}
		//private readonly string db = "Access";
		
		public DataDB(string DB) {
			this.DB = DB;
		}
		public IUser CreateUser()
		{
			IUser result = null;
			switch (DB)
			{
				case "Sqlserver":
					result = new SqlserverUser();
					break;
				case "Access":
					result = new AccessUser();
					break;
			}
			return result;
		}

		public IDepartment CreateDepartment()
		{
			IDepartment result = null;
			switch (DB)
			{
				case "Sqlserver":
					result = new SqlserverDepartment();
					break;
				case "Access":
					result = new AccessDepartment();
					break;
			}
			return result;
		}
	}


	public interface IUser
	{
		void Insert(User user);

		User GetUser(int id);
	}

	public interface IDepartment
	{
		void Insert(Department department);

		Department GetDepartment(int id);
	}

	public class SqlserverUser : IUser
	{
		public void Insert(User user)
		{
			Console.WriteLine("在SQL Server中给User表增加一条记录");
		}

		public User GetUser(int id)
		{
			Console.WriteLine("在SQL Server中根据ID得到User表一条记录");
			return null;
		}
	}

	public class AccessUser : IUser
	{
		public void Insert(User user)
		{
			Console.WriteLine("在Access中给User表增加一条记录");
		}

		public User GetUser(int id)
		{
			Console.WriteLine("在Access中根据ID得到User表一条记录");
			return null;
		}
	}

	public class SqlserverDepartment : IDepartment
	{
		public void Insert(Department department)
		{
			Console.WriteLine("在SQL Server中给Department表增加一条记录");
		}

		public Department GetDepartment(int id)
		{
			Console.WriteLine("在SQL Server中根据ID得到Department表一条记录");
			return null;
		}
	}

	public class AccessDepartment : IDepartment
	{
		public void Insert(Department department)
		{
			Console.WriteLine("在Access中给Department表增加一条记录");
		}

		public Department GetDepartment(int id)
		{
			Console.WriteLine("在Access中根据ID得到Department表一条记录");
			return null;
		}
	}

	public class User
	{
		private int _id;
		private string _name;
		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
	}

	public class Department
	{
		private int _id;
		private string _name;
		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			User user = new User();
			Department department = new Department();


			DataDB dataAccsee = new DataDB("Sqlserver");

			IUser iu =dataAccsee.CreateUser();
			iu.Insert(user);
			iu.GetUser(1);

			IDepartment id = dataAccsee.CreateDepartment();
			id.Insert(department);
			id.GetDepartment(1);



		}
	}
}
