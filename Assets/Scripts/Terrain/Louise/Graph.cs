using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Node
    {
        public Vector3 position;
        public float cost;
        public Node previous=null;
        public List<Node> neighbours;
        public Node(Vector3 position)
        {
            this.position = position;
            neighbours = new List<Node>();
        }
        public float GetDistance(Node other) 
        {
            return Vector3.Distance(position,other.position);
        }
        public void AddNeighbour(Node element)
        {
            neighbours.Add(element);
        }

        public override string ToString()
        {
            return "P("+this.position.x + "," + this.position.z+")";
        }
    }


public class Graph 
{
    public List<Node> nodes;
    public Graph()
    {
        nodes=new List<Node>();
    }
    public Graph(List<Node> points)
    {
        this.nodes = points;
    }

    public void AddCoordinates(Vector3 position, List<Vector3> neighbours)
    {
       var newNode = Get(position);
       foreach(var element in neighbours)
       {
            var neighbour = Get(element);
            newNode.AddNeighbour(neighbour);
       }
    }

    private void Append(Vector3 point)
    {
        nodes.Add(new Node(point));
    }

    private Node Get(Vector3 point)
    {
        int index = Find(point);
        if(index==-1)
        {
            Append(point);
            index = nodes.Count-1;
        }
        return nodes[index];
    }

    private int Find(Vector3 point)
    {
        int index=0;
        foreach(var element in nodes)
        {
            if (point == element.position)
            {
                return index;
            }
            index++;
        }
        //return -1 if not found
        return -1;
    }

    public Node FindNode(Vector3 position)
    {
        int index = Find(position);
        if (index==-1)
            return null;
        return nodes[index];
    }


    public int Size()
    {
        return nodes.Count;
    }





}
