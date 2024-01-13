using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGen : MonoBehaviour
{
    public GameObject plane;
    public GameObject tree;

    private float planeSize;
    private Vector3 spawnSpot;
    private Vector3 basePoint;

    private int amountOfTrees = 150;
    private float moveIncrement = 7.5f;

    private void Start()
    {
        plane = this.gameObject;
        basePoint = plane.transform.position;
        planeSize = plane.transform.localScale.x * 10;

        spawnTrees();
    }

    public void spawnTrees()
    {

        float x = basePoint.x - planeSize / 2;
        float z = basePoint.z - planeSize / 2;

        float localX = basePoint.x - planeSize / 2;
        float localZ = basePoint.z - planeSize / 2;

        spawnSpot = new Vector3(x, 5, z);

        Debug.Log("LX&LZ: " + localX + " " + localZ);

        for (int i = 0; i < amountOfTrees; i++)
        {

            //Debug.Log(i);
            //Debug.Log(spawnSpot);
            Debug.Log("X&Z:" + x + " " + z);

            Instantiate(tree, spawnSpot, Quaternion.Euler(-90, 0, Random.Range(0, 360)));

            x += moveIncrement;

            if (x > localX + planeSize)
            {
                x = localX;
                z += moveIncrement;
            }

            if (z > localZ + planeSize)
            {
                return;
            }

            spawnSpot = new Vector3(x + Random.Range(-3, 3), 5, z + Random.Range(-3, 3));

        }

    }
}

//BUG : PLANESIZE COMPARISON INCORRECT DUE TO DIFFERENT POSITIONS
