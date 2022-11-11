using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public float F { set; get; }
    public float H { set; get; }
    public float G { set; get; }
    public Node parent { set; get; }
    public bool canWalk { set; get; }
    public bool inOpen { set; get; }
    public bool inClose { set; get; }

    public static float k = 0;
    public Vector2 selfPos;
    public Node()
    {
        F = 999999;
        H = 999999;
        G = 999999;
        parent = null;
        canWalk = true;
        inOpen = false;
        inClose = false;
    }
    public static void setK(float x)
    {
        if(x > 1f)
        {
            x = 1f;
        }
        if(x < 0)
        {
            x = 0;
        }
        k = x;
    }

    public static bool operator <(Node left, Node right)
    {
        return left.F < right.F;
    }

    public static bool operator >(Node left, Node right)
    {
        return left.F > right.F;
    }

    public static bool operator ==(Node left, Node right)
    {
        return left.selfPos == right.selfPos;
    }

    public static bool operator !=(Node left, Node right)
    {
        return left.selfPos != right.selfPos;
    }

    public void updateF()
    {
        F = k*G + (1-k)*H;
    }

    public void updateH(Vector2 target)
    {
        int x = (int)((selfPos.x - target.x > 0) ? (selfPos.x - target.x) : (target.x - selfPos.x));
        int y = (int)((selfPos.y - target.y > 0) ? (selfPos.y - target.y) : (target.y - selfPos.y));
        H = x + y;
    }

    public void updateG(float x)
    {
        G = x;
    }

    public void setSelfPos(Vector2 pos)
    {
        selfPos = pos;
    }


    public void insertNodeToOpen()
    {
        Astart.open.Add(this);
        for(int i = Astart.open.Count - 1; i > 0; i--)
        {
            if(Astart.open[i] < Astart.open[i-1])
            {
                Node temp = Astart.open[i];
                Astart.open[i] = Astart.open[i - 1];
                Astart.open[i - 1] = temp;
            }
            else
            {
                break;
            }
        }
    }

    public void removeNodeFromOpen()
    {
        for (int i = 0; i < Astart.open.Count; i++)
        {
            if(Astart.open[i] == this)
            {
                Astart.open.RemoveAt(i);
                break;
            }
        }
        insertNodeToOpen();
    }

    public void insertToClose()
    {
        //从open里面移出
        for (int i = 0; i < Astart.open.Count; i++)
        {
            if (Astart.open[i] == this)
            {
                Astart.open.RemoveAt(i);
                break;
            }
        }
        //加入close集
        Astart.close.Add(this);
        inClose = true;
    }
}
