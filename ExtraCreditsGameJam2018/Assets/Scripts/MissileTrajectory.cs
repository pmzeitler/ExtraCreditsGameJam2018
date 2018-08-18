using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTrajectory : MonoBehaviour {

    public GameObject ShrapnelBullet;
    public int ShrapnelPerBurst = 6;

    public float DamageValue = 1.0f;

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
            float damageSustained = enteringObject.GetComponent<BulletDamage>().Value;
            DamageValue -= damageSustained;
            Destroy(enteringObject);
            if (DamageValue <= 0.0f)
            {
                //Debug.Log("Missile shot down");
                Destroy(gameObject);
                if (enteringObject.GetComponent<TurretBulletTrajectory>() != null)
                {
                    enteringObject.GetComponent<TurretBulletTrajectory>().firingTurret.GetComponent<TurretFireControl>().RewardTurret();
                }
                for (int i = 0; i < ShrapnelPerBurst; i++)
                {
                    GameObject shrapnel = Instantiate(ShrapnelBullet, gameObject.transform.position, Quaternion.identity);
                    shrapnel.GetComponent<BulletDamage>().Value = (FindObjectOfType<MissileSpawner>().TrueDamageValue / ((float)(ShrapnelPerBurst + 1)));
                }
            }
        }
    }
}
