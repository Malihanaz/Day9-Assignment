using System;
using System.Collections.Generic;

class LargeDataCollection : IDisposable
{
    private List<object> internalData;

    public LargeDataCollection(IEnumerable<object> initialData)
    {
        internalData = new List<object>(initialData);
    }

    public void AddElement(object element)
    {
        internalData.Add(element);
    }

    public void RemoveElement(object element)
    {
        internalData.Remove(element);
    }

    public object GetElement(int index)
    {
        return internalData[index];
    }

    public void Dispose()
    {
        // Release any unmanaged resources here

        // Set the internal data structure to null to free up memory
        internalData = null;

        Console.WriteLine("LargeDataCollection resources released.");
    }
}

class Program
{
    static void Main()
    {
        // Create an instance of LargeDataCollection
        using (var dataCollection = new LargeDataCollection(new List<object> { 1, "Two", 3.0 }))
        {
            // Demonstrate adding, removing, and accessing elements
            dataCollection.AddElement("New Element");
            Console.WriteLine("Element at index 2: " + dataCollection.GetElement(2));
            dataCollection.RemoveElement(3.0);

            // Explicitly call Dispose to release resources
            dataCollection.Dispose();
        }

        // The following line is optional but ensures resources are released immediately
        GC.Collect();
    }
}
