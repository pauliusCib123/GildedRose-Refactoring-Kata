﻿using System;
using System.Collections.Generic;

namespace csharp {
  public class Program {
    
    public static IList<Item> getItemsList() => new List<Item> {
      new Item {Name = "+5 Dexterity Vest",                         SellIn = 10, Quality = 20},
      new Item {Name = "Aged Brie",                                 SellIn = 2,  Quality = 0},
      new Item {Name = "Elixir of the Mongoose",                    SellIn = 5,  Quality = 7},
      new Item {Name = "Sulfuras, Hand of Ragnaros",                SellIn = 0,  Quality = 80},
      new Item {Name = "Sulfuras, Hand of Ragnaros",                SellIn = -1, Quality = 80},
      new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
      new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
      new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5,  Quality = 49},
      new Item {Name = "Conjured Mana Cake",                        SellIn = 3,  Quality = 6}
    };
    
    
    public static void Main(string[] args) {
      Console.WriteLine("OMGHAI!");

      var app = new GildedRose(getItemsList());
      for (var i = 0; i < 31; i++) {
        Console.WriteLine("-------- day " + i + " --------");
        Console.WriteLine($"{"Name",-50} {"SellIn",4} {"Quality",4}");
        foreach (var item in app.items) {
          Console.WriteLine(item);
        }

        Console.WriteLine("");
        app.UpdateQuality();
      }
    }
  }
}