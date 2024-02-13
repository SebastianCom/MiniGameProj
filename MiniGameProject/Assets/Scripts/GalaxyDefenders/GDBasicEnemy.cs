using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection
{
    Left,
    Right,
    Down,
    Return,
}

public class GDBasicEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveDistance;
    public float StoppingDistance;
    public float DownStoppingDistance;
    public float Speed;
    public float LowerDistance;
    public int Health = 1;

    private Vector3 LeftPoint = Vector3.zero;
    private Vector3 RightPoint = Vector3.zero;
    private Vector3 DownPoint = Vector3.zero;
    private Vector3 MidPoint = Vector3.zero;


    public MoveDirection _moveDirection;


    void Start()
    {
        _moveDirection = MoveDirection.Left;
        LeftPoint = new Vector3(transform.position.x - MoveDistance, transform.position.y, transform.position.z);
        RightPoint = new Vector3(transform.position.x + MoveDistance, transform.position.y, transform.position.z);
        MidPoint = transform.position;
        DownPoint = new Vector3(transform.position.x, transform.position.y - LowerDistance, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindAnyObjectByType<GDLevelManager>().GameStarted == true)
        {
            HandleMovement();

        }

    }

    private void HandleMovement()
    {
        switch (_moveDirection)
        {
            case MoveDirection.Left:
                if (Vector3.Distance(transform.position, LeftPoint) > StoppingDistance)
                {
                    transform.Translate(-transform.right * Speed * Time.deltaTime);
                }
                else
                {
                    _moveDirection = MoveDirection.Right;
                }
                break;

            case MoveDirection.Right:
                if (Vector3.Distance(transform.position, RightPoint) > StoppingDistance)
                {
                    transform.Translate(transform.right * Speed * Time.deltaTime);
                }
                else
                {
                    _moveDirection = MoveDirection.Left;
                }
                break;

            case MoveDirection.Return:
                if (Vector3.Distance(transform.position, MidPoint) > StoppingDistance)
                {
                    transform.Translate((MidPoint - transform.position).normalized * Speed * Time.deltaTime);
                }
                else
                {
                    _moveDirection = MoveDirection.Down;

                }
                break;

            case MoveDirection.Down:
                MoveDown();
                break;
        }
    }

    public void TriggerMoveDown()
    {
        _moveDirection= MoveDirection.Return;
        
    }

    public void MoveDown()
    {
        if (Vector3.Distance(transform.position, DownPoint) > DownStoppingDistance)
        {
            transform.Translate(-transform.up * Speed * Time.deltaTime);
        }
        else
        {
            LeftPoint = new Vector3(transform.position.x - MoveDistance, transform.position.y, transform.position.z);
            RightPoint = new Vector3(transform.position.x + MoveDistance, transform.position.y, transform.position.z);
            DownPoint = new Vector3(transform.position.x, transform.position.y - LowerDistance, transform.position.z);
            MidPoint = transform.position;
            GameObject.FindAnyObjectByType<GDGameTimer>().bTimerRunning = true;
            _moveDirection = MoveDirection.Left;
        }


    }

    public void OnDestroy()
    {
        GDLevelManager LManager = GameObject.FindAnyObjectByType<GDLevelManager>();

        if(LManager != null)
        {
            LManager.CurrentEnemies.Remove(this.gameObject);
        }

       
    }
}
