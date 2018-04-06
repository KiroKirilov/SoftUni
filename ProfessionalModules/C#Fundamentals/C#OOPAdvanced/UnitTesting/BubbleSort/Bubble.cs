using System;
using System.Collections.Generic;
using System.Text;


public class Bubble<T>
    where T: IComparable<T>
{
    private IList<T> collection;

    public Bubble(IList<T> collectionToSort)
    {
        if (collectionToSort==null)
        {
            throw new ArgumentNullException();
        }

        if (collectionToSort.Count<2)
        {
            throw new ArgumentException("Collection must have at least 2 items.");
        }

        this.collection = collectionToSort;
    }

    public IReadOnlyCollection<T> Collection => this.collection as IReadOnlyCollection<T>;

    public ICollection<T> Sort()
    {
        var exchanges=int.MaxValue;
        while (exchanges>0)
        {
            exchanges = 0;

            for (int currentIndex = 0; currentIndex < collection.Count-1; currentIndex++)
            {
                var nextIndex = currentIndex + 1;
                var currentItem = collection[currentIndex];
                var nextItem = collection[nextIndex];
                var compareResult = currentItem.CompareTo(nextItem);

                if (compareResult>0)
                {
                    var temp = currentItem;
                    collection[currentIndex] = collection[nextIndex];
                    collection[nextIndex] = temp;
                    exchanges++;
                }
            }
        }
        return this.collection;
    }
}

