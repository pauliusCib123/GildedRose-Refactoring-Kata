namespace csharp {
  // immutable data structures makes code more readable and less likely to break
  public struct ImmutableItem {
    public const int MAX_QUALITY = 50;
    
    public readonly string name;
    public readonly int sellIn;
    public readonly int quality;

    public ImmutableItem(string name, int sellIn, int quality) {
      this.name = name;
      this.sellIn = sellIn;
      this.quality = quality;
    }
    
    public static ImmutableItem fromItem(Item item) => new ImmutableItem(name: item.Name, sellIn: item.SellIn, quality: item.Quality);
      
    public override string ToString() => $"{name,-50} {sellIn,4} {quality,4}";
  }
}