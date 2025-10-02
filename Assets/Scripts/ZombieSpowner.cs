using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpowner : MonoBehaviour
{
    public GameObject ZombiePrefab0;
    public GameObject ZombiePrefab1;
    public GameObject ZombiePrefab2;

    public float FirstSpownTime = 4;
    public float RepeatTime = 6;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spown", FirstSpownTime, RepeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spown()
    {
        int zn = Random.Range(0, 3);
        //if (zn == 0)
        //{
        //    float Xpos = Random.Range(1030, 1040);
        //    Instantiate(ZombiePrefab0, new Vector3(1031.56995f, -118.750999f, 887.106995f), Quaternion.identity);
        //}
        //else {
        //    float Xpos = Random.Range(1030, 1040);
        //    Instantiate(ZombiePrefab1, new Vector3(1031.56995f, -118.750999f, 887.106995f), Quaternion.identity);
        //}
        switch (zn)
        {
            case 0:
                {
                    Instantiate(ZombiePrefab0, new Vector3(1031.56995f, -118.750999f, 887.106995f), Quaternion.identity);
                    Instantiate(ZombiePrefab1, new Vector3(1062.37305f, -118.750999f, 898.072998f), Quaternion.identity);


                }
                break;
            case 2:
                {
                    Instantiate(ZombiePrefab1, new Vector3(1031.56995f, -118.750999f, 887.106995f), Quaternion.identity);
                    Instantiate(ZombiePrefab2, new Vector3(1044.56995f, -118.750999f, 911.679993f), Quaternion.identity);


                }
                break;
            default: {
                    Instantiate(ZombiePrefab1, new Vector3(1031.56995f, -118.750999f, 887.106995f), Quaternion.identity);
                    Instantiate(ZombiePrefab0, new Vector3(1062.37305f, -118.750999f, 898.072998f), Quaternion.identity);
                } break;
        }

    }
}
