using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollisionHandler : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Colliding with object " + collision.collider.gameObject.name + "...");

        if (collision.collider.gameObject.tag == "Missile")
        {
            Debug.Log("Destroying ze missile");
            Destroy(collision.collider.gameObject);
        }
    }




}
