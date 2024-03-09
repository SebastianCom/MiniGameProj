using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Frogger_Lanes : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ground;
    public int NumberOfLanes = 5;
    public List<GameObject> Lanes;
    public float SectionHeight;
    float DefaultPlaneSize = 5f;
    public float SpawnerBuffer = 1.0f;

    public GameObject Test;
    public GameObject LanePrefab;
    public List<int> DangerousLanes = new List<int>();
    void Start()
    {
        //CreateLanes();

    }

    [ContextMenu("Generate Lanes")]
    private void CreateLanes()
    {
        int height = Mathf.RoundToInt(Ground.GetComponent<Renderer>().bounds.size.z);
        int width = Mathf.RoundToInt(Ground.GetComponent<Renderer>().bounds.size.x);
        Debug.Log("Height = " + height + ". Width = " + width);

        SectionHeight = (height / NumberOfLanes);

        for (int i = 0; i < NumberOfLanes; i++)
        {

            GameObject laneObj = Instantiate(LanePrefab);
            Frogger_LaneInfo lane = laneObj.GetComponent<Frogger_LaneInfo>();
            lane.name = "Lane" + i.ToString();
            float LanePositionY = SectionHeight + (SectionHeight * i);
            LanePositionY -= DefaultPlaneSize * Ground.transform.localScale.z;
            //LanePositionY -= SectionHeight / 2;


            lane.transform.position = new Vector3(-DefaultPlaneSize * Ground.transform.localScale.x, 0, LanePositionY);

            Vector3 laneTop = new Vector3(lane.transform.position.x, lane.transform.position.y, lane.transform.position.z + SectionHeight / 2);
            Vector3 laneBottom = new Vector3(lane.transform.position.x, lane.transform.position.y, lane.transform.position.z - SectionHeight / 2);
            Debug.DrawRay(laneTop, lane.transform.right * 400, Color.red, 10000000);
            Debug.DrawRay(laneBottom, lane.transform.right * 400, Color.red, 10000000);
            Debug.DrawRay(lane.transform.position, lane.transform.right * 400, Color.green, 10000000);

            lane.LeftSpawner = new Vector3(lane.transform.position.x - SpawnerBuffer, lane.transform.position.y, lane.transform.position.z);
            lane.RightSpawner= new Vector3((lane.transform.position.x + width) + SpawnerBuffer, lane.   transform.position.y, lane.transform.position.z);

            GameObject left = Instantiate(Test, lane.LeftSpawner, lane.transform.rotation);
            left.transform.SetParent(lane.transform);
            GameObject right = Instantiate(Test, lane.RightSpawner, lane.transform.rotation);
            right.transform.SetParent(lane.transform);


            Lanes.Add(lane.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
