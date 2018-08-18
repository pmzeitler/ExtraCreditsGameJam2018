using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFireControl : MonoBehaviour {

    public GameObject BulletPrefab;
    public float BulletsPerSecond = 0.5f;
    public float BulletDamageAcceleration = 0.2f;

    private float _elapsedTime;
    private float _trueBulletDamage;

    private MissileSpawner spawner;

    // Use this for initialization
    void Awake () {
        spawner = FindObjectOfType<MissileSpawner>();
        _trueBulletDamage = 1.0f;
    }
	
	// Update is called once per frame
	void Update () { 
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= (1.0f / BulletsPerSecond))
        {
            _elapsedTime = 0.0f;
            if (spawner.StartTimeRemaining < 0)
            {
                GameObject newBullet = Instantiate(BulletPrefab, gameObject.transform.position, Quaternion.identity);
                newBullet.GetComponent<BulletDamage>().Value = _trueBulletDamage;
                newBullet.GetComponent<TurretBulletTrajectory>().firingTurret = gameObject;
                
            }
        }
	}

    public void RewardTurret()
    {
        _trueBulletDamage += BulletDamageAcceleration;
    }
}
