using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象工厂模式
{
	/// <summary>
	/// 部分表 的是数据类
	/// </summary>
	public class Department
	{
		private int _id;
		private string _deptName;
		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}

		public string DeptName
		{
			get { return _deptName; }
			set { _deptName = value; }
		}
	}

	/// <summary>
	/// 部门表的操作接口
	/// </summary>
	public interface IDepartment
	{
		void Insert(Department department);

		Department GetDepartment(int id);
	}

	/// <summary>
	/// Sql Server 部门表 操作类
	/// </summary>
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
	/// <summary>
	/// Access 部门表 操作类
	/// </summary>
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



	/// <summary>
	/// 用户类
	/// </summary>
	public class User
	{
		private int _id;

		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

	}

	/// <summary>
	/// 接口 IUser
	/// </summary>
	public interface IUser
	{
		void Insert(User user);
		User GetUser(int id);
	}

	/// <summary>
	/// sql server 操作类
	/// </summary>
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

	/// <summary>
	/// Access 操作类
	/// </summary>
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

	/// <summary>
	///  工厂接口 返回 不同操作类接口
	/// </summary>
	public interface IFactory
	{
		IUser CreateUser();
		IDepartment CreateDepartment();
	}

	/// <summary>
	/// sqlserver 工厂 返回sqlserver 操作类
	/// </summary>
	public class SqlserverFactory : IFactory
	{
		public IUser CreateUser()
		{
			return new SqlserverUser();
		}

		public IDepartment CreateDepartment()
		{
			return new SqlserverDepartment();
		}
	}

	/// <summary>
	///  Access 工厂  返回 Access 操作类
	/// </summary>
	public class AccessFactory : IFactory
	{
		public IUser CreateUser()
		{
			return new AccessUser();
		}

		public IDepartment CreateDepartment()
		{
			return new AccessDepartment();
		}
	}




	public class Program
	{
		static void Main(string[] args)
		{
			User user = new User();
			Department department = new Department();


			IFactory factory = new AccessFactory();//通过切换工厂，切换不同的操作类 IFactory factory = new SqlserverFactory();

			IDepartment id = factory.CreateDepartment();
			IUser iu = factory.CreateUser();

			id.Insert(department);
			id.GetDepartment(1);


			iu.Insert(user);
			iu.GetUser(1);
			Console.ReadLine();
		}
	}
}
