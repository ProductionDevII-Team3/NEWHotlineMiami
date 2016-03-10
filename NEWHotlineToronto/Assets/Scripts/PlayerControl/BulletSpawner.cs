using UnityEngine;
using System.Collections;

public class BulletSpawner: MonoBehaviour {
	
	[SerializeField] private GameObject projectilePrefab = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1)){
			//Spawn the projectile, setting its position and orientation to that of the spawner game object's transform.
			GameObject projectile = Instantiate(this.projectilePrefab) as GameObject;
			projectile.transform.position = this.gameObject.transform.position;
			projectile.transform.rotation = this.gameObject.transform.rotation;
		}
	}
}
