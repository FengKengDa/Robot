using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Astart : MonoBehaviour
{
    public static List<Node> open;
    public static List<Node> close;
    public static List<Node> path;
    int count = 0;
    public Tilemap map;
    public GameObject circle;

    private void Start()
    {
        open = new List<Node>();
        close = new List<Node>();
        path = new List<Node>();
    }

    public void AStartSearch()
    {
        getMap.mapMatrix[39, 0].H = 39 + 71;
        getMap.mapMatrix[39, 0].F = getMap.mapMatrix[39, 0].G;
        getMap.mapMatrix[39, 0].G = 0;
        open.Add(getMap.mapMatrix[39, 0]);
        while(open.Count > 0)
        {
            count++;
            Node topVal = open[0];
            int x = (int)topVal.selfPos.x;
            int y = (int)topVal.selfPos.y;
            //up
            if (x - 1 >= 0 && getMap.mapMatrix[x - 1, y].canWalk && !getMap.mapMatrix[x - 1, y].inClose)  
            {
                if(getMap.mapMatrix[x-1,y].inOpen)
                {
                    if (getMap.mapMatrix[x - 1, y].G > getMap.mapMatrix[x, y].G + 10) 
                    {
                        getMap.mapMatrix[x - 1, y].updateG(getMap.mapMatrix[x, y].G + 10);
                        getMap.mapMatrix[x - 1, y].updateF();
                        getMap.mapMatrix[x - 1, y].parent = getMap.mapMatrix[x, y];
                        //删除原先旧的，把新的数据补回去
                        getMap.mapMatrix[x - 1, y].removeNodeFromOpen();
                    }
                }
                else
                {
                    getMap.mapMatrix[x - 1, y].updateG(getMap.mapMatrix[x, y].G + 10);
                    getMap.mapMatrix[x - 1, y].updateF();
                    getMap.mapMatrix[x - 1, y].parent = getMap.mapMatrix[x, y];
                    getMap.mapMatrix[x - 1, y].inOpen = true;
                    getMap.mapMatrix[x - 1, y].insertNodeToOpen();
                }
            }
            //down
            if (x + 1 < 40 && getMap.mapMatrix[x + 1, y].canWalk && !getMap.mapMatrix[x + 1, y].inClose) 
            {
                if (getMap.mapMatrix[x + 1, y].inOpen)
                {
                    if (getMap.mapMatrix[x + 1, y].G > getMap.mapMatrix[x, y].G + 10)
                    {
                        getMap.mapMatrix[x + 1, y].updateG(getMap.mapMatrix[x, y].G + 10);
                        getMap.mapMatrix[x + 1, y].updateF();
                        getMap.mapMatrix[x + 1, y].parent = getMap.mapMatrix[x, y];
                        //删除原先旧的，把新的数据补回去
                        getMap.mapMatrix[x - 1, y].removeNodeFromOpen();
                    }
                }
                else
                {
                    getMap.mapMatrix[x + 1, y].updateG(getMap.mapMatrix[x, y].G + 10);
                    getMap.mapMatrix[x + 1, y].updateF();
                    getMap.mapMatrix[x + 1, y].parent = getMap.mapMatrix[x, y];
                    getMap.mapMatrix[x + 1, y].inOpen = true;
                    getMap.mapMatrix[x + 1, y].insertNodeToOpen();
                }
            }
            //left
            if (y - 1 >= 0 && getMap.mapMatrix[x, y - 1].canWalk && !getMap.mapMatrix[x, y - 1].inClose) 
            {
                if (getMap.mapMatrix[x, y - 1].inOpen)
                {
                    if (getMap.mapMatrix[x, y - 1].G > getMap.mapMatrix[x, y].G + 10)
                    {
                        getMap.mapMatrix[x, y - 1].updateG(getMap.mapMatrix[x, y].G + 10);
                        getMap.mapMatrix[x, y - 1].updateF();
                        getMap.mapMatrix[x, y - 1].parent = getMap.mapMatrix[x, y];
                        //删除原先旧的，把新的数据补回去
                        getMap.mapMatrix[x, y - 1].removeNodeFromOpen();
                    }
                }
                else
                {
                    getMap.mapMatrix[x, y - 1].updateG(getMap.mapMatrix[x, y].G + 10);
                    getMap.mapMatrix[x, y - 1].updateF();
                    getMap.mapMatrix[x, y - 1].parent = getMap.mapMatrix[x, y];
                    getMap.mapMatrix[x, y - 1].inOpen = true;
                    getMap.mapMatrix[x, y - 1].insertNodeToOpen();
                }
            }
            //right
            if (y + 1 < 72 && getMap.mapMatrix[x, y + 1].canWalk && !getMap.mapMatrix[x, y + 1].inClose) 
            {
                if (getMap.mapMatrix[x, y + 1].inOpen)
                {
                    if (getMap.mapMatrix[x, y + 1].G > getMap.mapMatrix[x, y].G + 10)
                    {
                        getMap.mapMatrix[x, y + 1].updateG(getMap.mapMatrix[x, y].G + 10);
                        getMap.mapMatrix[x, y + 1].updateF();
                        getMap.mapMatrix[x, y + 1].parent = getMap.mapMatrix[x, y];
                        //删除原先旧的，把新的数据补回去
                        getMap.mapMatrix[x, y - 1].removeNodeFromOpen();
                    }
                }
                else
                {
                    getMap.mapMatrix[x, y + 1].updateG(getMap.mapMatrix[x, y].G + 10);
                    getMap.mapMatrix[x, y + 1].updateF();
                    getMap.mapMatrix[x, y + 1].parent = getMap.mapMatrix[x, y];
                    getMap.mapMatrix[x, y + 1].inOpen = true;
                    getMap.mapMatrix[x, y + 1].insertNodeToOpen();
                }
            }
            //up right
            if (x - 1 >= 0 && y + 1 < 72 && getMap.mapMatrix[x, y + 1].canWalk && getMap.mapMatrix[x - 1, y].canWalk&& getMap.mapMatrix[x - 1, y+1].canWalk && !getMap.mapMatrix[x - 1, y + 1].inClose) 
            {
                if (getMap.mapMatrix[x - 1, y + 1].inOpen)
                {
                    if (getMap.mapMatrix[x-1, y + 1].G > getMap.mapMatrix[x, y].G + 14)
                    {
                        getMap.mapMatrix[x-1, y + 1].updateG(getMap.mapMatrix[x, y].G + 14);
                        getMap.mapMatrix[x-1, y + 1].updateF();
                        getMap.mapMatrix[x-1, y + 1].parent = getMap.mapMatrix[x, y];
                        //删除原先旧的，把新的数据补回去
                        getMap.mapMatrix[x - 1, y + 1].removeNodeFromOpen();
                    }
                }
                else
                {
                    getMap.mapMatrix[x-1, y + 1].updateG(getMap.mapMatrix[x, y].G + 14);
                    getMap.mapMatrix[x-1, y + 1].updateF();
                    getMap.mapMatrix[x-1, y + 1].parent = getMap.mapMatrix[x, y];
                    getMap.mapMatrix[x-1, y + 1].inOpen = true;
                    getMap.mapMatrix[x-1, y + 1].insertNodeToOpen();
                }
            }
            //down right
            if (x + 1 < 40 && y + 1 < 72 && getMap.mapMatrix[x, y + 1].canWalk && getMap.mapMatrix[x + 1, y].canWalk && getMap.mapMatrix[x + 1, y + 1].canWalk && !getMap.mapMatrix[x + 1, y + 1].inClose)
            {
                if (getMap.mapMatrix[x + 1, y + 1].inOpen)
                {
                    if (getMap.mapMatrix[x + 1, y + 1].G > getMap.mapMatrix[x, y].G + 14)
                    {
                        getMap.mapMatrix[x + 1, y + 1].updateG(getMap.mapMatrix[x, y].G + 14);
                        getMap.mapMatrix[x + 1, y + 1].updateF();
                        getMap.mapMatrix[x + 1, y + 1].parent = getMap.mapMatrix[x, y];
                        //删除原先旧的，把新的数据补回去
                        getMap.mapMatrix[x + 1, y + 1].removeNodeFromOpen();
                    }
                }
                else
                {
                    getMap.mapMatrix[x + 1, y + 1].updateG(getMap.mapMatrix[x, y].G + 14);
                    getMap.mapMatrix[x + 1, y + 1].updateF();
                    getMap.mapMatrix[x + 1, y + 1].parent = getMap.mapMatrix[x, y];
                    getMap.mapMatrix[x + 1, y + 1].inOpen = true;
                    getMap.mapMatrix[x + 1, y + 1].insertNodeToOpen();
                }
            }
            //up left
            if (x - 1 >= 0 && y - 1 >= 0 && getMap.mapMatrix[x, y - 1].canWalk && getMap.mapMatrix[x - 1, y].canWalk && getMap.mapMatrix[x - 1, y - 1].canWalk && !getMap.mapMatrix[x - 1, y - 1].inClose)
            {
                if (getMap.mapMatrix[x - 1, y - 1].inOpen)
                {
                    if (getMap.mapMatrix[x - 1, y - 1].G > getMap.mapMatrix[x, y].G + 14)
                    {
                        getMap.mapMatrix[x - 1, y - 1].updateG(getMap.mapMatrix[x, y].G + 14);
                        getMap.mapMatrix[x - 1, y - 1].updateF();
                        getMap.mapMatrix[x - 1, y - 1].parent = getMap.mapMatrix[x, y];
                        //删除原先旧的，把新的数据补回去
                        getMap.mapMatrix[x - 1, y - 1].removeNodeFromOpen();
                    }
                }
                else
                {
                    getMap.mapMatrix[x - 1, y - 1].updateG(getMap.mapMatrix[x, y].G + 14);
                    getMap.mapMatrix[x - 1, y - 1].updateF();
                    getMap.mapMatrix[x - 1, y - 1].parent = getMap.mapMatrix[x, y];
                    getMap.mapMatrix[x - 1, y - 1].inOpen = true;
                    getMap.mapMatrix[x - 1, y - 1].insertNodeToOpen();
                }
            }
            // down left
            if (x + 1 < 40 && y - 1 > 0 && getMap.mapMatrix[x, y - 1].canWalk && getMap.mapMatrix[x + 1, y].canWalk && getMap.mapMatrix[x + 1, y - 1].canWalk && !getMap.mapMatrix[x + 1, y - 1].inClose)
            {
                if (getMap.mapMatrix[x + 1, y - 1].inOpen)
                {
                    if (getMap.mapMatrix[x + 1, y - 1].G > getMap.mapMatrix[x, y].G + 14)
                    {
                        getMap.mapMatrix[x + 1, y - 1].updateG(getMap.mapMatrix[x, y].G + 14);
                        getMap.mapMatrix[x + 1, y - 1].updateF();
                        getMap.mapMatrix[x + 1, y - 1].parent = getMap.mapMatrix[x, y];
                        //删除原先旧的，把新的数据补回去
                        getMap.mapMatrix[x + 1, y - 1].removeNodeFromOpen();
                    }
                }
                else
                {
                    getMap.mapMatrix[x + 1, y - 1].updateG(getMap.mapMatrix[x, y].G + 14);
                    getMap.mapMatrix[x + 1, y - 1].updateF();
                    getMap.mapMatrix[x + 1, y - 1].parent = getMap.mapMatrix[x, y];
                    getMap.mapMatrix[x + 1, y - 1].inOpen = true;
                    getMap.mapMatrix[x + 1, y - 1].insertNodeToOpen();
                }
            }
            //center
            getMap.mapMatrix[x, y].insertToClose();
            bool found = false;
            for(int i = 0; i < close.Count; i++)
            {
                if(close[i] == getMap.mapMatrix[0, 71])
                {
                    found = true;
                    break;
                }
            }
            if(found)
            {
                break;
            }
        }
        //回溯路径
        Vector2 current = new Vector2(0, 71);
        while(current != new Vector2(39,0))
        {
            path.Add(getMap.mapMatrix[(int)current.x, (int)current.y]);
            current = getMap.mapMatrix[(int)current.x, (int)current.y].parent.selfPos;
        }
        
        for(int i = 0; i < path.Count; i++)
        {
            Vector2 pos = map.GetCellCenterWorld(new Vector3Int((int)path[i].selfPos.y - 36, -(int)path[i].selfPos.x+19, 0));
            GameObject cir = Instantiate(circle);
            cir.transform.position = pos;
        }
        Debug.Log(count);
    }
}