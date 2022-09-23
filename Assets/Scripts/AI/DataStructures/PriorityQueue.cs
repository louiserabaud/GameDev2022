using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PriorityQueue
{
    private List<Node> items = new List<Node>();
    
    public void Enqueue(Node item)
    {
        items.Add(item);
    }
    public Node Dequeue()
    {
        int index = Peek();
        var item = items[index];
        items.RemoveAt(index);
        return item;
    }
    private int Peek()
    {
        var bestValue = float.MaxValue;
        int bestIndex = 0;
        int index = 0;
        foreach (var item in items)
        {
            if(item.cost < bestValue)
            {
                bestIndex=index;
                bestValue = item.cost;
            }
            index++;
        }
        return bestIndex;
    }

    public bool isEmpty()
    {
        if (items.Count==0)
            return true;
        return false;
    }

    public int Size()
    {
        return items.Count;
    }
}