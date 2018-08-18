using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFireControl : MonoBehaviour {

    public GameObject BulletPrefab;
    public int FiringDelay = 15;

    private int _countdown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _countdown--;
        if (_countdown <= 0)
        {
            Instantiate(BulletPrefab, gameObject.transform.position, Quaternion.identity);
            _countdown = FiringDelay;
        }
	}
}
