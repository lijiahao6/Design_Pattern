using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建造者模式
{

	/// <summary>
	/// 产品类 ，负责产品的各个部件的建造
	/// </summary>
	class Prouduct
	{
		IList<string> parts = new List<string>();
		public void Add(string part)
		{
			parts.Add(part);
		}

		public void Show()
		{
			Console.WriteLine("产品 创建----");
			foreach (string part in parts)
			{
				Console.WriteLine(part);
			}
		}
	}

	/// <summary>
	/// 建筑者抽象类，规范产品的各个组成部分的建造
	/// </summary>
    abstract class  Builder
    {
		public abstract void BuildPartA();
		public abstract void BuildPartB();
		public abstract Prouduct GetResult();

    }

	/// <summary>
	/// 创建具体的建造者类，实现抽象类，完成产品各个部件的具体建造
	/// </summary>
	class ConcreteBuilder1 : Builder
	{
		private Prouduct product = new Prouduct();
		public override void BuildPartA()
		{
			product.Add("部件A");
		}

		public override void BuildPartB()
		{
			product.Add("部件B");
		}

		public override Prouduct GetResult()
		{
			return product;
		}
	}

	class ConcreteBuilder2 : Builder
	{
		private Prouduct product = new Prouduct();
		public override void BuildPartA()
		{
			product.Add("部件X");
		}

		public override void BuildPartB()
		{
			product.Add("部件Y");
		}

		public override Prouduct GetResult()
		{
			return product;
		}
	}

	/// <summary>
	/// 指挥者类，负责产品的构建顺序
	/// </summary>
	class Director
	{
		public void Construct(Builder builder)
		{
			builder.BuildPartA();
			builder.BuildPartB();
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{

			Director director = new Director();
			Builder b1 = new ConcreteBuilder1();
			Builder b2 = new ConcreteBuilder2();
			director.Construct(b1);//按照顺序构建产品
			Prouduct p1 = b1.GetResult(); //获取产品 然后展示
			p1.Show();
		}
	}
}
