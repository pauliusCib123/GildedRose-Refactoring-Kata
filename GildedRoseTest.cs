using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace csharp {
  [TestFixture]
  public class GildedRoseTest {
    [Test]
    public void foo() {
      var Items = new List<Item> {new Item {Name = "foo", SellIn = 0, Quality = 0}};
      var app = new GildedRose(Items);
      app.UpdateQuality();
      //Assert.AreEqual("fixme", Items[0].Name); todo
    }
    
    [Test]
    public void makeSureNothingBreaks() {
      var items = Program.getItemsList();
      var app = new GildedRose(items);
      for (var i = 0; i < 30; i++) app.UpdateQuality();

      (int SellIn, int Quality)[] expectedResults = {(-20, 0), (-28, 50), (-25, 0), (0, 80), (-1, 80), (-15, 0), (-20, 0), (-25, 0), (-27, 0)};
      
      foreach (var (expectedResult, item) in expectedResults.Zip(items, (expectedResult, item) => (expectedResult, item))) {
        Assert.AreEqual(expectedResult.Quality, item.Quality);
        Assert.AreEqual(expectedResult.SellIn, item.SellIn);
      }
    }
  }
  
  
}