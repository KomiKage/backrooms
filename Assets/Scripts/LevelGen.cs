using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelGen : MonoBehaviour
{
    public int size;
    private int increase = 50;

    public int setSize;

    private int x_value;
    private int z_value;

    public GameObject[] lvl_components;
    public GameObject closedSquare;
    public GameObject objective;
    public GameObject open;

    private int[] rotations = { 0, 90, 180, 270 };

    public void levelGen()
    {
        setSize = size;

        x_value = size;
        z_value = size;

        int current_x = 0; 
        int current_z = 0;
        Vector3 v3 = Vector3.zero;
        Vector3 v3_rotation = Vector3.zero;

            var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones)
            {
                Destroy(clone);
            }

        float division = size / 7;
        int goalx = Random.Range((int)division, size-(int)division);
        int goalz = Random.Range((int)division, size - (int)division);

        int[] surroundingGoalX = new int[2];
        int[] surroundingGoalZ = new int[2];

        List<int> surX = new List<int>();
        List<int> surZ = new List<int>();

        //int lastClosedX = -100;
        //int lastClosedZ = 100;

        //reform into for loop
        surroundingGoalX[0] = goalx - 1;
        surroundingGoalX[1] = goalx + 1;
        surroundingGoalZ[0] = goalz - 1;
        surroundingGoalZ[1] = goalz + 1;
        //AUTOMATE SURROUNDING SO IT CAN BE USED ON ANY TILES SO REALLY COOL STUFF CAN BE DONE!!!!!!!! (:(:(:

        //loops through the X axis
        for (int i = 0; i < x_value; i++)
        {
            //loops through the Z axis
            for (int f = 0; f < z_value; f++)
            {
                int rot = Random.Range(0, rotations.Length);
                int comp = Random.Range(0, lvl_components.Length);
                GameObject compObj = lvl_components[comp];
                v3_rotation = new Vector3(0, rotations[rot], 0);

                //logs the location of the last closed space really inneficiently and incorrectly
                //if(compObj == lvl_components[9] && !surX.Contains(i) && !surZ.Contains(f) || compObj == lvl_components[9] && !surX.Contains(i) && f == lastClosedZ || compObj == lvl_components[9] && !surZ.Contains(f) && i == goalx)
                //{
                //    lastClosedX = i;
                //    lastClosedZ = f;
                //    surX.Add(i - 1);
                //    surX.Add(i + 1);
                //    surZ.Add(i - 1);
                //    surZ.Add(i + 1);
                //}

                //creates an outer border of closed squares
                if (i == 0 || i == size - 1 || f == 0 || f == size - 1)
                {
                    Instantiate(closedSquare, v3, Quaternion.identity);
                }
                //creates a border of open squares around the goal
                else
                {
                    if (surroundingGoalX.Contains(i) && surroundingGoalZ.Contains(f) || surroundingGoalX.Contains(i) && f == goalz || surroundingGoalZ.Contains(f) && i == goalx)
                    {
                        Instantiate(open, v3, Quaternion.Euler(v3_rotation));
                    }
                    //creates the goal
                    else if (i == goalx && f == goalz)
                    {
                        print("goalz = " + goalx);
                        print("goaly = " + goalz);
                        Instantiate(objective, v3, Quaternion.Euler(v3_rotation));
                    }
                    //assures there's always an open square on 1-1 (current player spawn)
                    else if (i == 1 && f == 1)
                    {
                        Instantiate(open, v3, Quaternion.Euler(v3_rotation));
                    }
                    //creates a random square
                    else
                    {
                        Instantiate(compObj, v3, Quaternion.Euler(v3_rotation));
                    }
                }
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
