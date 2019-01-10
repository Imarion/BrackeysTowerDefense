using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	public GameObject standardTurretPrefab;
	public GameObject anotherTurretPrefab;

	private GameObject turretToBuild;

	void Awake() {
		if (instance != null) {
			Debug.LogError ("More than 1 build manager in the scene");
			return;
		}
		instance = this;
	}
		

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject GetTurretToBuild() {
		return turretToBuild;
	}

	public void SetTurretToBuild(GameObject turret) {
		turretToBuild = turret;
	}
}
