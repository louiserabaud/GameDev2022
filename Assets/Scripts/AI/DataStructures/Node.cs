using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Node
{
    public Node(Vector3 _position, Transform _transform)
    {
        position=_position;
        transform=_transform;;
    }
    public Node Duplicate()
    {
       return new Node(position,transform);
    }
    public Node Duplicate(Node singleChild, Node parent)
    {
        Node newNode = Duplicate();
        newNode.next.Add(singleChild);
        newNode.parent = parent;
       return newNode;
    }
    public Vector3 position;
    public Transform transform;

    public float cost;

    public List<Node> next= new List<Node>();
    public Node parent=null;

    
   public  bool Equals(Node other)
   {
      //Check for null and compare run-time types.
      if ((other == null) || ! this.GetType().Equals(other.GetType()))
      {
         return false;
      }
      else {
         Node p = (Node) other;
         return (position == other.position);
      }
   }

}