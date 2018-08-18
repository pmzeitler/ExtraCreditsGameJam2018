using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollisionHandler : MonoBehaviour {

    public float WallHP = 1000.0f;
    public int DamagePerStrike = 1;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Colliding with object " + collision.collider.gameObject.name + "...");

        if (collision.collider.gameObject.tag == "Missile")
        {
            //int damageSustained = Mathf.FloorToInt(collision.collider.gameObject.GetComponent<MissileTrajectory>().DamageValue);
            float damageSustained = collision.collider.gameObject.GetComponent<MissileTrajectory>().DamageValue;
            Destroy(collision.collider.gameObject);
            //Debug.Log("The wall is taking damage!");

            if (WallHP > 0)
            {
                WallHP -= damageSustained;
                if (WallHP <= 0)
                {

                    MissileSpawner spawner = FindObjectOfType<MissileSpawner>();
                    Debug.Log("The wall has been destroyed!");
                    int finalTime = spawner.GameTime;
                    spawner.MissilesEnabled = false;
                    Debug.Log("Final GameTime: " + finalTime);
                }
            }
        }
    }




}
