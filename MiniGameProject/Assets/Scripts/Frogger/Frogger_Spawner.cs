using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftGenerator
{
    float Timer = 0.0f;
    bool RandomPicked = false;
    float TimeToSpawn = 0.0f;
    public float MinTimer = 0.0f;
    public float MaxTimer = 0.0f;
    public GameObject Raft;
    public Vector3 SpawnPos;
    Vector3 MoveDir = Vector3.zero;

    public RaftGenerator(float min, float max, GameObject raft, Vector3 spawnPos, Vector3 moveDir)
    {
        MinTimer = min;
        MaxTimer = max;
        Raft = raft;
        SpawnPos = spawnPos;
        MoveDir = moveDir; 
        
    }

    public void Update()
    {
        if(RandomPicked == false)
        {
            TimeToSpawn = Random.Range(MinTimer, MaxTimer);
            RandomPicked = true;
        }

        if(Timer >= TimeToSpawn)
        {
            GameObject spawnedRaft = GameObject.Instantiate<GameObject>(Raft, SpawnPos, Raft.transform.rotation);
            spawnedRaft.transform.position += new Vector3(0, 1.0f, 0);
            spawnedRaft.GetComponent<Frogger_CarHandler>().Direciton = MoveDir;
            spawnedRaft.GetComponent<Frogger_CarHandler>().Started = true;
            RandomPicked= false;
            Timer= 0.0f;
        }
        else
        {
            Timer += Time.deltaTime;
        }
        
    }

}

public class Frogger_Spawner : MonoBehaviour
{
    public Frogger_Lanes Lanes;
    public List<GameObject> Cars;
    public List<GameObject> Rafts;
    public List<RaftGenerator> RaftGenerators = new List<RaftGenerator>();

    bool Alternating = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject lane in Lanes.Lanes)
        {
            Frogger_LaneInfo currentLane = lane.GetComponent<Frogger_LaneInfo>();
            if (currentLane != null)
            {
                if(currentLane.SpawningLane == true)
                {
                    if(currentLane.SpawnLeft== true) 
                    {
                        //Instantiate Car at left point - moving right
                        GameObject spawnedCar = Instantiate<GameObject>(Cars[0], lane.GetComponent<Frogger_LaneInfo>().LeftSpawner, Cars[0].transform.rotation);
                        spawnedCar.transform.position += new Vector3(0, 1.0f, 0);
                        spawnedCar.GetComponent<Frogger_CarHandler>().Direciton = Vector3.right;
                        spawnedCar.GetComponent<Frogger_CarHandler>().Started= true;
                    }
                    else
                    {
                        //Instantiate Car at right point - moving left
                        GameObject spawnedCar = Instantiate<GameObject>(Cars[0], lane.GetComponent<Frogger_LaneInfo>().RightSpawner, Cars[0].transform.rotation);
                        spawnedCar.transform.position += new Vector3(0, 1.0f, 0);
                        spawnedCar.GetComponent<Frogger_CarHandler>().Direciton = Vector3.left;
                        spawnedCar.transform.rotation = Quaternion.Euler(spawnedCar.transform.rotation.eulerAngles.x, spawnedCar.transform.rotation.eulerAngles.y, 180);
                        spawnedCar.GetComponent<Frogger_CarHandler>().Started = true;
                    }
                }
                else if (currentLane.Water == true) 
                {
                    Vector3 SpawnLocation = Vector3.zero;
                    SpawnLocation = Alternating ? lane.GetComponent<Frogger_LaneInfo>().LeftSpawner : SpawnLocation = lane.GetComponent<Frogger_LaneInfo>().RightSpawner;

                    Vector3 MoveDir = Vector3.zero;
                    MoveDir = Alternating ? Vector3.right : Vector3.left;


                    RaftGenerator raftGen = new RaftGenerator(2f, 5f, Rafts[0], SpawnLocation, MoveDir);
                    RaftGenerators.Add(raftGen);
                    Alternating = !Alternating;
                }
                else if(currentLane.End == true) 
                {
                    //beat level
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        foreach(RaftGenerator raft in RaftGenerators)
        {
            raft.Update();
        }
    }
}
