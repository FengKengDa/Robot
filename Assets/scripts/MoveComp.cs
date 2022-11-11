using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComp : MonoBehaviour
{
    bool reverse = true;
    public bool isVertical = true;
    public float time = 3;
    public float count = 0;
    public float speed = 10;
    void Update()
    {
        if(isVertical)
        {
            if(reverse)
            {
                count += Time.deltaTime;
                if (count > time)
                {
                    count = 0;
                    reverse = !reverse;
                }
                gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x, transform.position.y) + new Vector2(0,1)*Time.deltaTime * speed);
            }
            else
            {
                count += Time.deltaTime;
                if (count > time)
                {
                    count = 0;
                    reverse = !reverse;
                }
                gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x, transform.position.y) + new Vector2(0, -1) * Time.deltaTime * speed);
            }
        }
        else
        {
            if (reverse)
            {
                count += Time.deltaTime;
                if (count > time)
                {
                    count = 0;
                    reverse = !reverse;
                }
                gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x, transform.position.y) + new Vector2(1, 0) * Time.deltaTime * speed);
            }
            else
            {
                count += Time.deltaTime;
                if (count > time)
                {
                    count = 0;
                    reverse = !reverse;
                }
                gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x, transform.position.y) + new Vector2(-1, 0) * Time.deltaTime * speed);
            }
        }
        
    }
}
