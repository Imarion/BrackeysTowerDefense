using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Vector3 positionOffset;

	private GameObject turret;

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

	void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject ())
			return;

		if (buildManager.GetTurretToBuild () == null)
			return;

		if (turret != null) {
			Debug.Log ("Can't build there");
			return;
		}

		// Build a turret;
		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		turret = (GameObject) Instantiate (turretToBuild, transform.position + positionOffset, transform.rotation);
	}

	void OnMouseEnter() {
		if (EventSystem.current.IsPointerOverGameObject ())
			return;

		if (buildManager.GetTurretToBuild () == null)
			return;
		
		rend.material.color = hoverColor;
	}

	void OnMouseExit() {
		rend.material.color = startColor;
	}
}
