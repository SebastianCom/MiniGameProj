using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frogger_Player : MonoBehaviour
{

    public float MoveSpeed = 75f;
    public float gridSize = 15f; // Size of each grid square
    Vector3 targetPosition; // The position the frog is moving towards

    public Vector3 StartingPos;

    public Sprite[] frames;
    public float framesPerSecond = 10f;

    private Image spriteRenderer;
    bool isMoving = false;

    void Start()
    {
        StartingPos = transform.position;
        targetPosition = transform.position; // Start at current position
        spriteRenderer = GetComponent<Image>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            targetPosition += Vector3.forward * gridSize;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            targetPosition -= Vector3.forward * gridSize;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            targetPosition -= Vector3.right * gridSize;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            targetPosition += Vector3.right * gridSize;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * MoveSpeed);

        if (Vector3.Distance(transform.position, targetPosition) > 0.001f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if(isMoving == true)
        {
            NextFrame();
        }
    }

    private void NextFrame()
    {
        int index = (int)(Time.time * framesPerSecond) % frames.Length;
        spriteRenderer.sprite = frames[index];
    }


    private void OnTriggerEnter(Collider other)
    {
        targetPosition = StartingPos;
        transform.position = StartingPos;
    }



}
