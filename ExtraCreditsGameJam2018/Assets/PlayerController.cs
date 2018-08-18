using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speedPerFrame = 0.1f;
    public int MaxTurrets = 5;
    public GameObject TurretPrefab;

    public bool CanPlaceTurrets = true;

    private int _turretsPlaced = 0;
    private bool _turretKeyDown = false;

	// Use this for initialization
	void Start () {
        _turretsPlaced = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //check movement
        Vector3 movement = new Vector3(0, 0, 0);
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = (-1 * speedPerFrame);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            movement.x = (speedPerFrame);
        }
        gameObject.transform.position += movement;

        //check for a turret to be placed
        if (Input.GetKey(KeyCode.Space))
        {
            if (_turretsPlaced < MaxTurrets)
            {
                if(!_turretKeyDown)
                {
                    _turretKeyDown = true;
                    Instantiate(TurretPrefab, gameObject.transform.position, Quaternion.identity);
                    _turretsPlaced++;
                }
            }
        }
        else
        {
            _turretKeyDown = false;
        }
    }
}
