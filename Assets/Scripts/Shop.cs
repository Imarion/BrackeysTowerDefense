using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	BuildManager buildManager;

	// Use this for initialization
	void Start () {
		buildManager = BuildManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PurchaseStandardTurret() {
		Debug.Log ("Standard turret selected");
		buildManager.SetTurretToBuild (buildManager.standardTurretPrefab);
	}

	public void PurchaseAnotherTurret() {
		Debug.Log ("Another turret selected");
		buildManager.SetTurretToBuild (buildManager.anotherTurretPrefab);
	}

}
