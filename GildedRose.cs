using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable StringLiteralTypo

namespace csharp {
  public class GildedRose {
    public const string
      BackStagePassName = "Backstage passes",
      AgedBrieName = "Aged Brie",
      ConjuredName = "Conjured",
      SulfurasName = "Sulfuras";
    
    /// <summary> mutable </summary>
    public ImmutableItem[] items { get; private set; }
    
    public GildedRose(IEnumerable<Item> items) => this.items = items.Select(ImmutableItem.fromItem).ToArray();

    public ImmutableItem[] updateQualityForXDaysAndGetItems(int days) {
      for (var i = 0; i < days; i++) UpdateQuality();
      return items;
    }
    
    public void UpdateQuality() => items = 
      items.Select(item => {
        var isBackStagePass = item.name.StartsWith(BackStagePassName);
        var isAgedBrie = item.name.StartsWith(AgedBrieName);
        var isConjured = item.name.StartsWith(ConjuredName);
        var isSulfuras = item.name.StartsWith(SulfurasName);
      
        return
          isSulfuras 
            ? item //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality
            : new ImmutableItem(
              name: item.name,
              sellIn: item.sellIn - 1,
              quality: 
                isBackStagePass && item.sellIn < 0 // Quality drops to 0 after the concert
                  ? 0
                  : Math.Max(0, // The Quality of an item is never negative; 
                      Math.Min( // The Quality of an item is never more than 50
                        item.quality 
                          - (// At the end of each day our system lowers both values for every item
                            isBackStagePass && item.sellIn <= 10// Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
                              ? item.sellIn <= 5 
                                ? 3
                                : 2
                              : 1
                          )
                          * (isAgedBrie || isBackStagePass ? -1 : 1) //"Aged Brie" actually increases in Quality the older it gets
                          * (item.sellIn < 0 ? 2 : 1) //Once the sell by date has passed, Quality degrades twice as fast
                          * (isConjured ? 2 : 1) //"Conjured" items degrade in Quality twice as fast as normal items
                        , ImmutableItem.MAX_QUALITY
                      )
                  )
            );
      })
      .ToArray();
  }
}