using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrapnelBulletTrajectory : MonoBehaviour {
    public float SpeedPerFrame = 3.0f;

    public Vector2 Direction { get; set; }
    public float Lifespan = 1.5f;

    private float _ageInSeconds = 0.0f;

	// Use this for initialization
	void Start () {
        Direction = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        _ageInSeconds += Time.deltaTime;
        if (_ageInSeconds >= Lifespan)
        {
            Destroy(gameObject);
        }
        else
        {
            Vector3 shiftPosition = new Vector3((Direction.x * SpeedPerFrame * Time.deltaTime), (Direction.y * SpeedPerFrame * Time.deltaTime), 0);
            gameObject.transform.position += shiftPosition;
        }
		
	}


}
