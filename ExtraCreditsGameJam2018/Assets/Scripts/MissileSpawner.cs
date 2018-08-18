using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour {

    public int StartingDelaySeconds;
    public int MissilesPerSecond = 3;
    public float MissileAcceleration = 0.15f;
    public float DamageAcceleration = 0.2f;
    public GameObject MissileObject;

    public int GameTime
    {
        get; set;
    }

    public float TrueDamageValue
    {
        get
        {
            return _trueDamageValue;
        }
    }

    public bool MissilesEnabled { get; set; }

    public int StartTimeRemaining
    {
        get {
            int retval = -1;

            if (InStartingDelay)
            {
                retval = StartingDelaySeconds - Mathf.FloorToInt(_elapsedTime);
            }

            return retval;
        }
    }

    private float _elapsedTime = 0.0f;
    private float _secondCounter = 0.0f;
    private bool InStartingDelay = true;
    private int _lastCountdownNumber = 11;
    private float _trueMissilesPerSecond;
    private float _trueDamageValue;



	// Use this for initialization
	void Awake () {
        _trueMissilesPerSecond = (float)MissilesPerSecond;
        _trueDamageValue = 1.0f;
        MissilesEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (MissilesEnabled)
        {
            _elapsedTime += Time.deltaTime;
            if (InStartingDelay)
            {
                if (Mathf.FloorToInt(_elapsedTime) >= StartingDelaySeconds)
                {
                    _elapsedTime = 0.0f;
                    InStartingDelay = false;
                    GameTime = 0;
                }
                else
                {
                    if (StartTimeRemaining != _lastCountdownNumber)
                    {
                        _lastCountdownNumber = StartTimeRemaining;
                        Debug.Log("Missiles fly in " + _lastCountdownNumber);
                    }
                }
            }
            else
            {
                _secondCounter += Time.deltaTime;
                if (_secondCounter >= 1.0f)
                {
                    GameTime++;
                    _secondCounter = 0.0f;
                    _trueMissilesPerSecond += MissileAcceleration;
                    _trueDamageValue += DamageAcceleration;
                }
                if (_elapsedTime >= (1.0f / _trueMissilesPerSecond))
                {
                    _elapsedTime = 0.0f;
                    Vector3 missilePosition = new Vector3(-12, Random.Range(-3.25f, 4), 0);
                    GameObject newMissile = Instantiate(MissileObject, missilePosition, MissileObject.transform.rotation);
                    newMissile.GetComponent<MissileTrajectory>().DamageValue = _trueDamageValue;
                }
            }
        }
	}
}
