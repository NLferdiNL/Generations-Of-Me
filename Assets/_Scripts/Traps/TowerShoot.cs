using UnityEngine;
using System.Collections;

[RequireComponent (typeof(TowerTarget))]
public class TowerShoot : MonoBehaviour {
	
	[SerializeField]private GameObject bullet;
	private Quaternion rotation;
	private Transform target;
	[SerializeField]private float turnSpeed = 1f;
	[SerializeField]private float reloadTime;
	private float nextFireTime;
	[SerializeField]private Transform turret;

	
	TowerTarget _towerTarget;
	
	void Awake()
	{
		_towerTarget = GetComponent<TowerTarget> ();
		nextFireTime = reloadTime;
	}

	// Update is called once per frame
	void Update () {
			target = _towerTarget._target;
		if (target) {
			turret.rotation = rotation;
			RotateTurret ();
			Shoot ();
		}
	}

	void ResetTurretRotation(){
		transform.rotation = Quaternion.identity;
	}

	void RotateTurret(){
		Vector3 direction = this.transform.position - target.position;
		float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		rotation = Quaternion.Lerp (this.transform.rotation, Quaternion.Euler(0, 0, angle + 90), Time.time * turnSpeed);
	}

	void Shoot(){
		nextFireTime += Time.deltaTime;
		if (nextFireTime >= reloadTime) {
			Instantiate (bullet, transform.position, rotation);
			nextFireTime = 0;
		}
	}
}