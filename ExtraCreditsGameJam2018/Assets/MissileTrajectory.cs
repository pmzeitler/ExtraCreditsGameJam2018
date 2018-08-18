﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTrajectory : MonoBehaviour {

    public Vector2 InitialPosition
    {
        get; set;
    }

    public float SpeedPerFrame = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position += new Vector3(SpeedPerFrame, 0, 0);
		
	}
}
