using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PriorityQueue<T>
{
    private List<Tuple<T,int>> items = new List<Tuple<T,int>>();
    
    public void Enqueue(T item, int priority)
    {
        items.Add(Tuple.Create(item,priority));
    }
    public T Dequeue()
    {
        int index = Peek();
        var item = items[index].Item1;
        items.RemoveAt(index);
        return item;
    }
    private int Peek()
    {
        int hightestP = int.MinValue;
        int index = 0;
        foreach (var item in items)
        {
            if(item.Item2 < items[hightestP].Item2)
            {
                hightestP=index;
            }
            index++;
        }
        return hightestP;
    }
}