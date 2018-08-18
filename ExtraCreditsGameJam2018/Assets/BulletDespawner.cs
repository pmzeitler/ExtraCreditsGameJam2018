using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawner : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject exitingObject = collision.GetComponent<Collider2D>().gameObject;
        //Debug.Log("Exiting object named " + exitingObject.name + "...");
        if (exitingObject.tag == "Bullet")
        {
            //Debug.Log("Destroying ze bullet");
            Destroy(exitingObject);
        }
    }
}
