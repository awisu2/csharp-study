using AspNetCoreEmptyNet6;

namespace AspNetCoreEmptyNet6Test;

public class CalcTest
{
    private Calc calc = new Calc();

    [Fact]
    public void SumTest()
    {
        Assert.Equal(4, calc.Sum(1, 3));
    }

    [Fact]
    public void DecTest()
    {
        Assert.Equal(3, calc.Dec(5, 2));
    }

    [Fact]
    public void MultiTest()
    {
        Assert.Equal(10, calc.Multi(5, 2));
    }
}