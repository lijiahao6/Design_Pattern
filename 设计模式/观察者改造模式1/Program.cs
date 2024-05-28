using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者改造模式1
{

	/// <summary>
	/// 抽象观察者
	/// </summary>
	abstract class Observer
	{
		protected string name;
		public Observer(string name)
		{
			this.name = name;
		}

		public abstract void Activty(string strInfo);
	}

	/// <summary>
	/// 具体观察者 股票观察者
	/// </summary>
	class StockObserber : Observer
	{

		public StockObserber(string name) :base(name)
		{

		}
	
		public override void Activty(string strInfo)
		{
			Console.WriteLine("{0} {1} 关闭股票行情，继续工作！",strInfo,  name);
		}
	}

	/// <summary>
	/// 看NBA观察者
	/// </summary>
	class NBAObserber : Observer
	{
		public NBAObserber(string name):base(name)
		{

		}
		public override void Activty(string strInfo)
		{
			Console.WriteLine("{0} {1} 关闭NBA直播，继续工作！", strInfo, name);
		}
	}


	delegate void NotifyEventHandler(string strInfo);
	abstract class Subject
	{
		public abstract void Notify(string strInfo);
		
	}

	class boss : Subject
	{
		public event NotifyEventHandler NotifyEvent;
		public override void Notify(string strInfo)
		{
			NotifyEvent.Invoke(strInfo);
		}
	}

	class Secretary : Subject
	{
		public event NotifyEventHandler NotifyEvent;
		public override void Notify(string strInfo)
		{
			NotifyEvent.Invoke(strInfo);
		}
	}



	internal class Program
	{
		static void Main(string[] args)
		{
			boss boss1 = new boss();
			Observer observer1 = new StockObserber("张三");
			Observer observer2 = new NBAObserber("李四");

			boss1.NotifyEvent += observer1.Activty;
			boss1.NotifyEvent += observer2.Activty;

			boss1.Notify("老板来了");

		}

		
	}
}
