using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public TurretBlueprint standardTurret;
	public TurretBlueprint missileLauncher;

	BuildManager buildManager;

	// Use this for initialization
	void Start () {
		buildManager = BuildManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectStandardTurret() {
		Debug.Log ("Standard turret selected");
		buildManager.SelectTurretToBuild (standardTurret);
	}

	public void SelectMissileLauncher() {
		Debug.Log ("MissileLauncher selected");
		buildManager.SelectTurretToBuild (missileLauncher);
	}

}
