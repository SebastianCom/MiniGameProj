using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Frogger_CarHandler : MonoBehaviour
{
    public float Speed = 10;
    public Vector3 Direciton;

    public bool Started =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Started)
        {
            transform.position += Direciton * Speed * Time.deltaTime;
        }
    }
}
