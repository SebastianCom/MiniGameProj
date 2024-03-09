using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frogger_Player : MonoBehaviour
{

    public float MoveSpeed = 75f;
    public float gridSize = 15f; // Size of each grid square
    GameObject targetPosition; // The position the frog is moving towards

    public Vector3 StartingPos;

    public Sprite[] frames;
    public float framesPerSecond = 10f;

    private Image spriteRenderer;
    bool isMoving = false;
    int RowIndex = 0;
    bool OnRaft = false;

    public Frogger_Lanes Lanes;

    void Start()
    {
        targetPosition = new GameObject();
        StartingPos = transform.position;
        targetPosition.transform.position = transform.position; // Start at current position
        spriteRenderer = GetComponent<Image>();
    }


    void Update()
    {
        if(RowIndex== 9)
        {
            //Win level 
            Debug.Log("You beat the level");
            ResetPlayer();
        }



        if (Input.GetKeyDown(KeyCode.W))
        {
            targetPosition.transform.position += Vector3.forward * gridSize;
            RowIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            targetPosition.transform.position -= Vector3.forward * gridSize;
            RowIndex--;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            targetPosition.transform.position -= Vector3.right * gridSize;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            targetPosition.transform.position += Vector3.right * gridSize;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition.transform.position, Time.deltaTime * MoveSpeed);

        if (Vector3.Distance(transform.position, targetPosition.transform.position) > 0.001f)
        {
            isMoving = true;
        }
        else
        {
            //if (Lanes.Lanes[RowIndex].GetComponent<Frogger_LaneInfo>().Water == true)
            //{
            //    if (OnRaft == false)
            //    {
            //        ResetPlayer();
            //    }
            //}
            isMoving = false;
        }

        if(isMoving == true)
        {
            NextFrame();
        }
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(transform.position, targetPosition.transform.position) <= 0.001f)
        {
            if (Lanes.Lanes[RowIndex].GetComponent<Frogger_LaneInfo>().Water == true && isMoving == false)
            {
                if (OnRaft == false)
                {
                    ResetPlayer();
                }
            }
        }
    }

    private void NextFrame()
    {
        int index = (int)(Time.time * framesPerSecond) % frames.Length;
        spriteRenderer.sprite = frames[index];
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
            ResetPlayer();

        if(other.gameObject.tag == "Raft")
        {
            OnRaft = true;
            other.gameObject.GetComponent<Frogger_CarHandler>().StartCarry(targetPosition);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Raft")
        {
            OnRaft= false;
            other.gameObject.GetComponent<Frogger_CarHandler>().StopCarry();

        }
    }

    public void ResetPlayer()
    {

        //Death anim
        targetPosition.transform.position = StartingPos;
        transform.position = StartingPos;
        RowIndex= 0;
    }



}
