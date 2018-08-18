using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletTrajectory : MonoBehaviour {
    public float SpeedPerFrame = 3.0f;

    public GameObject firingTurret;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position += new Vector3(0, SpeedPerFrame * Time.deltaTime, 0);
		
	}
}
