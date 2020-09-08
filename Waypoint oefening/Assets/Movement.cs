﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject[] waypoints; 
    public int num = 0;
    public float minDist;
    public float speed; 
    public bool rand = false; 
    public bool go = true; 
    private float arrivalthreshold = 0.1f;




    // Update is called once per frame
    private void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);

        if (go)
        {
            if (dist > minDist)
            {
                Move();
            }
            else
            {
                if (!rand) {
                    if (num + 1 == waypoints.Length)
                    {
                        num = 0;
                    }
                    else 
                    {
                        num++; 
                    }
                } 
                else 
                {
                 num = Random.Range(0, waypoints.Length);
                }
            }
        }

     if (dist <= arrivalthreshold)
        {
            print("Ik ben er!");
        }

    }
      

    public void Move()
    {
        gameObject.transform.LookAt(waypoints[num].transform.position);
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime; 
    }

}

