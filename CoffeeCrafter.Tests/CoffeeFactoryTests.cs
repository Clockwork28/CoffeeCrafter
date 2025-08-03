using CoffeeCrafter.Beverages;
using CoffeeCrafter.Factory;
using CoffeeCrafter.Interfaces;
using CoffeeCrafter.OrderSystem;
using Xunit;

namespace CoffeeCrafter.Tests;

public class CoffeeFactoryTests
{
    [Fact]
    public async Task Make_InValidOrder_ThrowsInvalidArgumentError()
    {
        // Arrange
        var factory = new CoffeeFactory();
        var order = new OrderDTO(1, "mocha", "vip");

        // Act + Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(async Task () => await factory.Make(order, CancellationToken.None));

        Assert.Equal("Invalid coffee type!", exception.Message);

    }

    public static IEnumerable<object[]> ValidOrders => new[]
    {
        new object[]{new OrderDTO(1,"americano", "vip"), new Americano(7M)},
        new object[]{new OrderDTO(2, "espresso", "normal"), new Espresso(5M)},
        new object[]{new OrderDTO(3, "cappuccino", "normal"), new Cappuccino(9M)},
        new object[]{ new OrderDTO(4, "latte", "vip"), new Latte(10M)}
    };
    [Theory]
    [MemberData(nameof(ValidOrders))]
    public async Task Make_WithValidTypeAndNoExtras_ReturnsCorrectBaseDrink(OrderDTO order, IBeverage expected)
    {
        var factory = new CoffeeFactory();

        var actual = await factory.Make(order, CancellationToken.None);
        
        Assert.Equal(expected.GetCost(), actual.GetCost());
        Assert.Equal(expected.GetDescription(), actual.GetDescription());
    }

}
