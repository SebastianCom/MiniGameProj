using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDBasicEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveDistance;
    public float StoppingDistance;
    public float DownStoppingDistance;
    public float Speed;
    public float LowerDistance;

    private Vector3 LeftPoint = Vector3.zero;
    private Vector3 RightPoint = Vector3.zero;
    private Vector3 DownPoint = Vector3.zero;

    bool bMovingLeft = true;
    bool bMovingDown = false;
    void Start()
    {
        LeftPoint = new Vector3(transform.position.x - MoveDistance, transform.position.y, transform.position.z);
        RightPoint = new Vector3(transform.position.x + MoveDistance, transform.position.y, transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!bMovingDown) 
        {
            if (bMovingLeft)
            {
                if (Vector3.Distance(transform.position, LeftPoint) > StoppingDistance)
                {
                    transform.Translate(-transform.right * Speed * Time.deltaTime);
                }
                else
                {
                    bMovingLeft = !bMovingLeft;
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, RightPoint) > StoppingDistance)
                {
                    transform.Translate(transform.right * Speed * Time.deltaTime);
                }
                else
                {
                    bMovingLeft = !bMovingLeft;
                }
            }
        }
        else
        {
            MoveDown();

        }

    }

    public void TriggerMoveDown()
    {
        bMovingDown = true;
        DownPoint = new Vector3(transform.position.x, transform.position.y - LowerDistance, transform.position.z);
    }

    public void MoveDown()
    {
        if (Vector3.Distance(transform.position, DownPoint) > DownStoppingDistance)
        {
            transform.Translate(-transform.up * Speed * Time.deltaTime);
        }
        else
        {
            bMovingDown = false;
            LeftPoint = new Vector3(transform.position.x - MoveDistance, transform.position.y, transform.position.z);
            RightPoint = new Vector3(transform.position.x + MoveDistance, transform.position.y, transform.position.z);
            DownPoint = new Vector3(transform.position.x, transform.position.y - LowerDistance, transform.position.z);
        }


    }
}
