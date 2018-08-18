using System.Collections;
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

        gameObject.transform.position += new Vector3(SpeedPerFrame * Time.deltaTime, 0, 0);
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enteringObject = collision.GetComponent<Collider2D>().gameObject;
        //Debug.Log("Exiting object named " + exitingObject.name + "...");
        if (enteringObject.tag == "Bullet")
        {
            Debug.Log("Missile shot down");
            Destroy(enteringObject);
            Destroy(gameObject);
        }
    }
}
