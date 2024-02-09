using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float MoveDistance = 1.0f;
    public float StoppingDistance = 0.01f;

    public GameObject LeftWall;
    public GameObject RightWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
    }

    private void Controls() 
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (Mathf.Abs(transform.position.x - LeftWall.transform.position.x) > StoppingDistance) // Stop the player from bouncing against the wall going left 
            {
                transform.position += (new Vector3(-MoveDistance, 0.0f, 0.0f) * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Mathf.Abs(transform.position.x - RightWall.transform.position.x) > StoppingDistance) // Stop the player from bouncing against the wall going left 
            {
                transform.position += (new Vector3(MoveDistance, 0.0f, 0.0f) * Time.deltaTime);
            }
        }
    }
}
