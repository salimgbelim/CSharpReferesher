using Xunit.Abstractions;

namespace GradeBook.Tests.PrototypePattern
{
    public abstract class Prototype
    {
        public abstract Prototype ShallowCopy();

        public abstract Prototype DeepCopy();
        public abstract void Debug();
    }

    public class OrderInfo
    {
        public int id;

        public OrderInfo(int id)
        {
            this.id = id;
        }
    }

    public class FoodOrder : Prototype
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public string customerName;
        public bool isDelivery;
        public string[] orderContents;
        public OrderInfo info;

        public FoodOrder(string name, bool isDelivery, string[] orderContents, 
            ITestOutputHelper testOutputHelper,
            OrderInfo info)
        {
            this.customerName = name;
            this.isDelivery = isDelivery;
            this.orderContents = orderContents;
            this._testOutputHelper = testOutputHelper;
            this.info = info;
        }

        public override Prototype ShallowCopy()
        {
            return (Prototype) this.MemberwiseClone();
        }

        public override Prototype DeepCopy()
        {
            FoodOrder clonedOrder = (FoodOrder) this.MemberwiseClone();
            
            clonedOrder.info = new OrderInfo(clonedOrder.info.id);

            return clonedOrder;
        }

        public override void Debug()
        {
            _testOutputHelper.WriteLine("----- Prototype Food Order -----");
            _testOutputHelper.WriteLine($"\nName : {this.customerName} \nDelivery : {this.isDelivery}");
            _testOutputHelper.WriteLine($"ID: {this.info.id}");
            _testOutputHelper.WriteLine($"Order Contents : {string.Join(",", orderContents)}\n");
        }
    }
}