using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour
{
    public GameObject PrefabCube;
    GameObject[] SampleCubes = new GameObject[512];
    public float maxScale;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 512; i++)
        {
            GameObject InstanceCube = (GameObject)Instantiate (PrefabCube);
            InstanceCube.transform.position = this.transform.position;
            InstanceCube.transform.parent = this.transform;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            InstanceCube.transform.position = Vector3.forward * 1000;
            SampleCubes[i] = InstanceCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if(SampleCubes != null)
            {
                SampleCubes[i].transform.localScale = new Vector3(10, AudioVisualitionTest.samples[i] * maxScale + 2, 10);
            }
        }
    }
}
