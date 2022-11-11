using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class bfs : MonoBehaviour
{

    public static Queue<Node> que;
    public Tilemap map;
    public static List<Node> path;
    public GameObject circle;
    int count = 0;

    private void Start()
    {
        que = new Queue<Node>();
        path = new List<Node>();
    }

    public void bfsSearch()
    {
        
        que.Enqueue(getMap.mapMatrix[39, 0]);
        while(que.Count>0)
        {
            count++;
            Node topVal = que.Dequeue();
            int x = (int)topVal.selfPos.x;
            int y = (int)topVal.selfPos.y;
            if(getMap.mapMatrix[x,y] == getMap.mapMatrix[0,71])
            {
                break;
            }
            //up
            if (x - 1 >= 0 && getMap.mapMatrix[x - 1, y].canWalk && !getMap.mapMatrix[x - 1, y].inOpen) 
            {
                que.Enqueue(getMap.mapMatrix[x - 1, y]);
                getMap.mapMatrix[x - 1, y].inOpen = true;
                getMap.mapMatrix[x - 1, y].parent = getMap.mapMatrix[x, y];
            }
            //down
            if (x + 1 < 40 && getMap.mapMatrix[x + 1, y].canWalk && !getMap.mapMatrix[x + 1, y].inOpen)
            {
                que.Enqueue(getMap.mapMatrix[x + 1, y]);
                getMap.mapMatrix[x + 1, y].inOpen = true;
                getMap.mapMatrix[x + 1, y].parent = getMap.mapMatrix[x, y];
            }
            //left
            if (y - 1 >= 0  && getMap.mapMatrix[x, y-1].canWalk && !getMap.mapMatrix[x, y-1].inOpen)
            {
                que.Enqueue(getMap.mapMatrix[x, y-1]);
                getMap.mapMatrix[x, y - 1].inOpen = true;
                getMap.mapMatrix[x, y-1].parent = getMap.mapMatrix[x, y];
            }
            //right
            if (y + 1 < 72 && getMap.mapMatrix[x, y + 1].canWalk && !getMap.mapMatrix[x, y + 1].inOpen)
            {
                que.Enqueue(getMap.mapMatrix[x, y + 1]);
                getMap.mapMatrix[x, y + 1].inOpen = true;
                getMap.mapMatrix[x, y + 1].parent = getMap.mapMatrix[x, y];
            }
            //up right
            if (x - 1 >= 0 && y + 1 < 72 && getMap.mapMatrix[x, y + 1].canWalk && getMap.mapMatrix[x - 1, y].canWalk && getMap.mapMatrix[x - 1, y + 1].canWalk && !getMap.mapMatrix[x - 1, y + 1].inOpen)
            {
                que.Enqueue(getMap.mapMatrix[x-1, y + 1]);
                getMap.mapMatrix[x-1, y + 1].inOpen = true;
                getMap.mapMatrix[x-1, y + 1].parent = getMap.mapMatrix[x, y];
            }
            //down right
            if (x + 1 < 40 && y + 1 < 72 && getMap.mapMatrix[x, y + 1].canWalk && getMap.mapMatrix[x + 1, y].canWalk && getMap.mapMatrix[x + 1, y + 1].canWalk && !getMap.mapMatrix[x + 1, y + 1].inOpen)
            {
                que.Enqueue(getMap.mapMatrix[x+1, y + 1]);
                getMap.mapMatrix[x+1, y + 1].inOpen = true;
                getMap.mapMatrix[x+1, y + 1].parent = getMap.mapMatrix[x, y];
            }
            //up left
            if (x - 1 >= 0 && y - 1 >= 0 && getMap.mapMatrix[x, y - 1].canWalk && getMap.mapMatrix[x - 1, y].canWalk && getMap.mapMatrix[x - 1, y - 1].canWalk && !getMap.mapMatrix[x - 1, y - 1].inOpen)
            {
                que.Enqueue(getMap.mapMatrix[x-1, y - 1]);
                getMap.mapMatrix[x-1, y - 1].inOpen = true;
                getMap.mapMatrix[x-1, y - 1].parent = getMap.mapMatrix[x, y];
            }
            // down left
            if (x + 1 < 40 && y - 1 >= 0 && getMap.mapMatrix[x, y - 1].canWalk && getMap.mapMatrix[x + 1, y].canWalk && getMap.mapMatrix[x + 1, y - 1].canWalk && !getMap.mapMatrix[x + 1, y - 1].inOpen)
            {
                que.Enqueue(getMap.mapMatrix[x+1, y - 1]);
                getMap.mapMatrix[x+1, y - 1].inOpen = true;
                getMap.mapMatrix[x+1, y - 1].parent = getMap.mapMatrix[x, y];
            }
            
        }
        //»ØËÝÂ·¾¶
        Vector2 current = new Vector2(0, 71);
        while (current != new Vector2(39, 0))
        {
            path.Add(getMap.mapMatrix[(int)current.x, (int)current.y]);
            current = getMap.mapMatrix[(int)current.x, (int)current.y].parent.selfPos;
        }

        for (int i = 0; i < path.Count; i++)
        {
            Vector2 pos = map.GetCellCenterWorld(new Vector3Int((int)path[i].selfPos.y - 36, -(int)path[i].selfPos.x + 19, 0));
            GameObject cir = Instantiate(circle);
            cir.transform.position = pos;
        }
        Debug.Log(count);
        
    }
    
}
