using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Color notEnoughMoneyColor;
	public Vector3 positionOffset;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	private Renderer rend;
	private Color startColor;

	BuildManager buildManager;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 GetBuildPosition() {
		return transform.position + positionOffset;
	}

	void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject ())
			return;

		if (turret != null) {
			buildManager.SelectNode (this);
			return;
		}

		if (!buildManager.CanBuild)
			return;

		//buildManager.BuildTurretOn (this);
		BuildTurret(buildManager.GetTurretToBuild());
	}

	void BuildTurret(TurretBlueprint blueprint) {
		if (PlayerStats.Money < blueprint.cost) {
			Debug.Log ("Not enough money");
			return;
		}

		PlayerStats.Money -= blueprint.cost;

		GameObject _turret = (GameObject) Instantiate (blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		turretBlueprint = blueprint;

		GameObject buildeffect = (GameObject) Instantiate (buildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
		Destroy (buildeffect, 5f);

		Debug.Log ("Turret built; Money left: " + PlayerStats.Money);
	}

	public void UpgradeTurret() {
		if (PlayerStats.Money < turretBlueprint.upgradeCost) {
			Debug.Log ("Not enough money to upgrade");
			return;
		}

		PlayerStats.Money -= turretBlueprint.upgradeCost;

		// Get rid of the old turret
		Destroy (turret);

		// Build a new turret
		GameObject _turret = (GameObject) Instantiate (turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		GameObject buildeffect = (GameObject) Instantiate (buildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
		Destroy (buildeffect, 5f);

		isUpgraded = true;

		Debug.Log ("Turret built; Money left: " + PlayerStats.Money);
	}

	void OnMouseEnter() {
		if (EventSystem.current.IsPointerOverGameObject ())
			return;

		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney) {
			rend.material.color = hoverColor;
		} else {
			rend.material.color = notEnoughMoneyColor;
		}
	}

	void OnMouseExit() {
		rend.material.color = startColor;
	}
}
