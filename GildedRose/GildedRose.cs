using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> Items)
{
    private readonly IList<Item> Items = Items;

    private const string AgedBrie = "Aged Brie";
    private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    private const string Sulfuras = "Sulfuras, Hand of Ragnaros";    

    public void UpdateQuality()
    {
        foreach (Item item in Items)
        {
            if (item.Name != AgedBrie && item.Name != BackstagePasses)
            {
                if (item.Quality > 0)
                {
                    if (item.Name != Sulfuras)
                    {
                        DecreaseQuality(item, 1);
                    }
                }
            }
            else
            {
                if (item.Quality < 40)
                {
                    IncreaseQuality(item, 1);

                    if (item.Name == BackstagePasses)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                IncreaseQuality(item, 1);
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                IncreaseQuality(item, 1);
                            }
                        }
                    }
                }
            }

            if (item.Name != Sulfuras)
            {
                UpdateSellin(item);
            }

            if (item.SellIn < 0)
            {
                if (item.Name != AgedBrie)
                {
                    if (item.Name != BackstagePasses)
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != Sulfuras)
                            {
                                DecreaseQuality(item, 1);
                            }
                        }
                    }
                    else
                    {
                        DecreaseQuality(item, 2);
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        IncreaseQuality(item, 1);
                    }
                }
            }
        }
    }

    private static void UpdateSellin(Item item)
    {
        item.SellIn = item.SellIn - 1;
    }

    private static Item DecreaseQuality(Item item, int times)
    {
        if (item.Quality > 0)
        {
            item.Quality -= times;
        }
        return item;
    }

    private static Item IncreaseQuality(Item item, int times)
    {
        if (item.Quality < 40)
        {
            item.Quality += times;
        }
        return item;
    }
}