using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelGenTest : MonoBehaviour
{
    public int size;
    private float increase = 50.24f; //50.24

    public int setSize;

    private int x_value;
    private int z_value;

    public GameObject[] lvl_components;
    public GameObject closedSquare;
    public GameObject objective;
    public GameObject open;

    public GameObject blendTest;

    private int[] rotations = { 0, 90, 180, 270 };

    public void levelGen()
    {
        setSize = size;

        x_value = size;
        z_value = size;

        float current_x = 0; 
        float current_z = 0;
        Vector3 v3 = Vector3.zero;
        Vector3 v3_rotation = Vector3.zero;

            var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones)
            {
                Destroy(clone);
            }

        //loops through the X axis
        for (int i = 0; i < x_value; i++)
        {
            //loops through the Z axis
            for (int f = 0; f < z_value; f++)
            {
                Instantiate(blendTest, v3, Quaternion.identity);

                //Debug.Log(compObj.name + " : X=" + i + " Y=" + f);
                current_x += increase;
                v3 = new Vector3(current_x, 0, current_z);
            }

            current_x = 0;
            current_z += increase;
            v3 = new Vector3(current_x, 0, current_z);
        }

    }

    private void Start()
    {
        setSize = size;

        levelGen();
    }

    private void FixedUpdate()
    {
        if (size != setSize)
        {
            levelGen();
        }
    }

    // for choosing the prefabs maybe loop through and create arrays to identify what to place?

}
