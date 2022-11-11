using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class car : MonoBehaviour
{
    public List<Vector2> path;
    public Tilemap map;
    private Rigidbody2D playerRigidbody;
    public float speed = 10f;
    public Vector2 nextPoint;
    public float range = 0.2f;
    private bool isEnd = false;
    private bool havePath = false;
    private bool isEscape = false;
    private Vector2 escapeDirection;

    public GameObject Bfs;
    public GameObject astar;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isEscape && havePath)
        {
            if(!isEnd)
            {
                Move(nextPoint);
                float dis = (nextPoint.x - transform.position.x) * (nextPoint.x - transform.position.x) + (nextPoint.y - transform.position.y) * (nextPoint.y - transform.position.y);
                if (dis < range)
                {
                    if(path.Count > 0)
                    {   
                        nextPoint = path[path.Count - 1];
                        path.RemoveAt(path.Count - 1);
                    }
                    else
                    {
                        isEnd = true;
                    }
                }
            }
        }
        else if(isEscape && havePath)
        {
            if(!isEnd)
            {
                Escape();
            }
        }
        
        
    }

    public void Move(Vector2 nextPoint)
    {
        Vector2 direction = (nextPoint - new Vector2(transform.position.x, transform.position.y)).normalized;
        playerRigidbody.MovePosition(new Vector2(transform.position.x, transform.position.y) + Time.deltaTime * speed * direction);
    }

    public void Escape()
    {
        playerRigidbody.MovePosition(new Vector2(transform.position.x, transform.position.y) + Time.deltaTime * speed * escapeDirection);
    }

    public void getPathByAStar()
    {
        astar.GetComponent<Astart>().AStartSearch();
        for (int i = 0; i < Astart.path.Count; i++)
        {
            path.Add(map.GetCellCenterWorld(new Vector3Int((int)Astart.path[i].selfPos.y - 36, -(int)Astart.path[i].selfPos.x + 19, 0)));
        }
        transform.position = path[path.Count - 1];
        nextPoint = path[path.Count - 2];
        path.RemoveAt(path.Count - 1);
        path.RemoveAt(path.Count - 1);
        havePath = true;
    }

    public void getPathByBFS()
    {
        Bfs.GetComponent<bfs>().bfsSearch();
        for (int i = 0; i < bfs.path.Count; i++)
        {
            path.Add(map.GetCellCenterWorld(new Vector3Int((int)bfs.path[i].selfPos.y - 36, -(int)bfs.path[i].selfPos.x + 19, 0)));
        }
        transform.position = path[path.Count - 1];
        nextPoint = path[path.Count - 2];
        path.RemoveAt(path.Count - 1);
        path.RemoveAt(path.Count - 1);
        havePath = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        escapeDirection = (transform.position - collision.transform.position).normalized;
        isEscape = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isEscape = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        escapeDirection = (transform.position - collision.transform.position).normalized;
    }
}
