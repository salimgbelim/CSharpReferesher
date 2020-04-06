using System.Threading.Tasks;
using GradeBook.Tests.AdapterPattern;
using Xunit;
using Xunit.Abstractions;

namespace GradeBook.Tests.PrototypePattern
{
    public class PrototypePatternTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public PrototypePatternTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void it_prints_food_order()
        {
            // Arrange
            FoodOrder savedOrder = new FoodOrder("Harrison",
                true,
                new[] {"Pizza", "Coke"},
                _testOutputHelper,
                new OrderInfo(2345));

            // Act - Assert
            _testOutputHelper.WriteLine("Original order: ");
            savedOrder.Debug();
        }

        [Fact]
        public void it_shallow_copies_non_reference_items()
        {
            _testOutputHelper.WriteLine("Original order: ");

            FoodOrder savedOrder = new FoodOrder("Harrison",
                true,
                new[] {"Pizza", "Coke"},
                _testOutputHelper,
                new OrderInfo(2345));

            savedOrder.Debug();

            _testOutputHelper.WriteLine("Cloned Order");
            FoodOrder clonedOrder = (FoodOrder) savedOrder.ShallowCopy();
            clonedOrder.Debug();
        }

        [Fact]
        public void it_does_not_shallow_copies_reference_items()
        {
            _testOutputHelper.WriteLine("Original order: ");
            FoodOrder savedOrder = new FoodOrder("Harrison",
                true,
                new[] {"Pizza", "Coke"},
                _testOutputHelper,
                new OrderInfo(2345));
            savedOrder.Debug();

            _testOutputHelper.WriteLine("Cloned Order");
            FoodOrder clonedOrder = (FoodOrder) savedOrder.ShallowCopy();
            clonedOrder.Debug();

            // change one non reference item and one reference item and it will change the reference item which it should not
            // i.e The id in the cloned order is changed to 5555 when it shouldn't 
            // It should be same behaviour as name and not change the name for cloned order variable
            _testOutputHelper.WriteLine("Order changes :");
            savedOrder.customerName = "Jeff";
            savedOrder.info.id = 5555;
            savedOrder.Debug();
            clonedOrder.Debug();
        }

        [Fact]
        public void it_does_deep_copies_of_all_properties()
        {
            _testOutputHelper.WriteLine("Original order: ");
            FoodOrder savedOrder = new FoodOrder("Harrison",
                true,
                new[] {"Pizza", "Coke"},
                _testOutputHelper,
                new OrderInfo(2345));
            savedOrder.Debug();

            _testOutputHelper.WriteLine("Cloned Order");
            FoodOrder clonedOrder = (FoodOrder) savedOrder.DeepCopy();
            clonedOrder.Debug();

            _testOutputHelper.WriteLine("Order changes :");
            savedOrder.customerName = "Jeff";
            savedOrder.info.id = 5555;
            savedOrder.Debug();
            clonedOrder.Debug();
        }
    }
}