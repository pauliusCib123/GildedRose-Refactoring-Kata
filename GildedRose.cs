﻿using System.Collections.Generic;
// ReSharper disable StringLiteralTypo

namespace csharp {
  public class GildedRose {
    const int MAX_QUALITY = 50;
    
    readonly IList<Item> Items;
    public GildedRose(IList<Item> Items) { this.Items = Items; }

    
    
    
    
    public void UpdateQuality() {
      foreach (var item in Items) {
        if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert") {
          if (item.Quality > 0) {
            if (item.Name != "Sulfuras, Hand of Ragnaros") {
              item.Quality--;
            }
          }
        }
        else {
          if (item.Quality < MAX_QUALITY) {
            item.Quality++;
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert") {
              if (item.SellIn < 11) {
                if (item.Quality < 50) {
                  item.Quality += 1;
                }
              }

              if (item.SellIn < 6) {
                if (item.Quality < MAX_QUALITY) {
                  item.Quality += 1;
                }
              }
            }
          }
        }

        if (item.Name != "Sulfuras, Hand of Ragnaros") {
          item.SellIn--;
        }

        if (item.SellIn < 0) {
          if (item.Name != "Aged Brie") {
            if (item.Name != "Backstage passes to a TAFKAL80ETC concert") {
              if (item.Quality > 0) {
                if (item.Name != "Sulfuras, Hand of Ragnaros") {
                  item.Quality--;
                }
              }
            }
            else {
              item.Quality -= item.Quality;
            }
          }
          else {
            if (item.Quality < MAX_QUALITY) {
              item.Quality++;
            }
          }
        }
        
      }
    }
  }
}