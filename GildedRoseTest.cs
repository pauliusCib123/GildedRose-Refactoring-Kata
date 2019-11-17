using NUnit.Framework;
using System.Linq;

namespace csharp {
  [TestFixture]
  public class GildedRoseTest {
    void assertItem(ImmutableItem item, int expectedResultQuality, int expectedResultSellIn) {
      Assert.AreEqual(expectedResultQuality, item.quality, item.name + " Quality");
      Assert.AreEqual(expectedResultSellIn, item.sellIn, item.name + " SellIn");
    }
    
    // this test includes all mentioned scenarios
    [Test]
    public void makeSureNothingBreaks() {
      var resultItems =
        new GildedRose(Program.getItemsList())
          .updateQualityForXDaysAndGetItems(30);

      (int SellIn, int Quality)[] expectedResults = {
        (-20, 0), // simple item
        (-28, 50), // Aged Brie, added quality
        (-25, 0), // simple item
        (0,   80), // Sulfuras, not change
        (-1,  80), // Sulfuras with negative sellin
        (-15, 0), // Backstage passes 15d
        (-20, 0), // Backstage passes 10d
        (-25, 0), // Backstage passes 5d
        (-27, 0) // Conjured
      };

      var zipped = expectedResults.Zip(resultItems, (expectedResult, item) => (expectedResult, item));
      foreach (var (expectedResult, item) in zipped) {
        assertItem(item, expectedResult.Quality, expectedResult.SellIn);
      }
    }

    [Test]
    public void makeSureSulfurasNotChange() =>
      assertItem(
        item: new GildedRose(new[] {
            new Item {Name = GildedRose.SulfurasName, Quality = 123, SellIn = 22}
          })
          .updateQualityForXDaysAndGetItems(123)[0],
        expectedResultQuality: 123,
        expectedResultSellIn: 22
      );
    
    [Test]
    public void makeSureItemQualityIsMaxed() =>
      Assert.AreEqual(
        new GildedRose(new[] {
            new Item {Name = GildedRose.AgedBrieName, Quality = 123, SellIn = 22}
          })
          .updateQualityForXDaysAndGetItems(123)[0].quality,
        ImmutableItem.MAX_QUALITY
      );
    
    [Test]
    public void makeSureQualityDropsTo0AfterTheConcert() =>
      Assert.AreEqual(
        new GildedRose(new[] {
            new Item {Name = GildedRose.BackStagePassName, Quality = 123000, SellIn = 22}
          })
          .updateQualityForXDaysAndGetItems(33)[0].quality,
        0
      );


  }
}