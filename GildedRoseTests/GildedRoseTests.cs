using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTests
{
    [Fact]
    public void ExampleTest()
    {
        var Items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
    }

    [Fact]
    public void NormalItem_DecreasesQualityBeforeSellDate()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(19, items[0].Quality);
    }

    [Fact]
    public void NormalItem_DegradesTwiceAfterSellDate()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(8, items[0].Quality);
    }

    [Fact]
    public void AgedBrie_IncreasesQuality()
    {
        var items = new List<Item> { new() { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(1, items[0].SellIn);
        Assert.Equal(1, items[0].Quality);
    }

    [Fact]
    public void Sulfuras_Unchanged()
    {
        var items = new List<Item> { new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(5, items[0].SellIn);
        Assert.Equal(80, items[0].Quality);
    }

    [Fact]
    public void Quality_NeverGoesBelowZero()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = 1, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void Quality_NeverGoesAbove50()
    {
        var items2 = new List<Item> { new() { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
        var app2 = new GildedRose(items2);
        app2.UpdateQuality();
        Assert.Equal(50, items2[0].Quality);
    }
}