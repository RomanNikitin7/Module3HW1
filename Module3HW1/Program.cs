namespace Module3HW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection = new CollectionGeneric<int>();
            
            for (int i = 0; i < 11; i++)
            {
                collection.Add(i);
            }
            foreach (int item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
