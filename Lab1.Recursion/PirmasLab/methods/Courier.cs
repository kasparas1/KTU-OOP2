public class Courier
{
    // Fields
   

    // Properties
    public int Count { get; }
    public int[,] Prices { get; }
    private int[] Route;
    // Indexer
    public int this[int index]
    {
        get => Route[index];
        set => Route[index] = value;
    }
    // Constructor
    public Courier(int count, int[,] prices)
    {
        Count = count;
        Prices = prices;
        Route = FirstRoute(Count);
    }
    // Private method
    private int[] FirstRoute(int count)
    {
        int[] points = new int[count + 1];
        for (int i = 0; i < count; i++)
        {
            points[i] = i + 1;
        }
        points[count] = 1;

        return points;
    }
}