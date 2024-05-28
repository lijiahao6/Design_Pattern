using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/// <summary>
/// 前台秘书和老板，老板提前进门，秘书通知员工老板来了，老板来了，员工可以看到老板来了，员工收到老板来的信息，就会主动去干活。
/// 
/// 设计思路，通知者需要抽象出来，秘书和老板都继承抽象通知类，观察者也需要抽象出来，员工继承观察者，收到通知，立马工作
/// </summary>
namespace 观察者模式
{
	/// <summary>
	/// 抽象观察者
	/// </summary>
	 abstract class Observer
	{
		protected string name;
		protected ISubject sub;
		public Observer(string name, ISubject sub ) {
			this.name = name;
			this.sub = sub;
		}

		public abstract void Update();
	}

	/// <summary>
	/// 具体观察者 股票观察者
	/// </summary>
	class StockObserber : Observer
	{

		public StockObserber(string name, ISubject sub) : base(name, sub)
		{

		}
		public override void Update()
		{
            Console.WriteLine("{0} {1} 关闭股票行情，继续工作！",sub.SubjectState,name);
        }
	}

	/// <summary>
	/// 看NBA观察者
	/// </summary>
	class NBAObserber : Observer
	{
        public NBAObserber(string name, ISubject sub):base(name,sub)
        {
				
        }
        public override void Update()
		{
			Console.WriteLine("{0} {1} 关闭NBA直播，继续工作！", sub.SubjectState, name);
		}
	}

	/// <summary>
	/// 抽象通知类
	/// </summary>
	interface ISubject
	{
		void Attch(Observer obs);
		void Detach(Observer obs);

		void Notify();

		string SubjectState { get; set; }
	}

	class Boss : ISubject
	{
		IList<Observer> observers = new List<Observer>();
		public string SubjectState { get ; set ; }

		public void Attch(Observer obs)
		{
			observers.Add(obs);
		}

		public void Detach(Observer obs)
		{
			observers.Remove(obs);
		}

		public void Notify()
		{
            Console.WriteLine("boss 来了。");
            foreach (Observer obs in observers)
			{
				obs.Update();
			}
		}
	}


	internal class Program
	{
		static void Main(string[] args)
		{
			ISubject boss = new Boss();
			Observer NBAobserver = new NBAObserber("Lee", boss);
			Observer Stockobserver = new StockObserber("Lss", boss);
			boss.Attch(NBAobserver);
			boss.Attch(Stockobserver);
			boss.Detach(Stockobserver);
			boss.Notify();
		}
	}
}
