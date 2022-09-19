using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Point
{
    public int X;
    public int Y;
    public Point(int x, int y)
    {
        this.X=x;
        this.Y=y;
    }
    public override bool Equals(object obj)
    {
        if(obj==null || !(obj is Point))
            return false;
        else
        {
            var p = obj as Point;
            return this.X==p.X && this.Y==p.Y;
        }  
        return false;  
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 6949;
            hash = hash * 7907 + X.GetHashCode();
            hash = hash * 7907 + Y.GetHashCode();
            return hash;
        }
    }

    public override string ToString()
    {
        return "P("+this.X + "," + this.Y+")";
    }
}

public enum CellType
{
    Empty,
    Road,
    Building,
    Path
}

public class GridBuilder : MonoBehaviour
{
    public int xSize;
    public int ySize;
    float cellSize=10f;

    private CellType[,] _grid;

    private List<Point> _roadCells = new List<Point>();
    private List<Point> _buildingCells = new List<Point>();

    public static bool isCellWakable(CellType cellType, bool hasAI = false)
    {
        if (hasAI)
        {
            return cellType == CellType.Road;
        }
        return false;
    }
}
