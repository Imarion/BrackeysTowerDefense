﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	public GameObject buildEffectPrefab;
	public GameObject sellEffectPrefab;
	public NodeUI nodeUI;

	private TurretBlueprint turretToBuild;
	private Node selectedNode;

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

	public bool CanBuild { get {return turretToBuild != null; } }
	public bool HasMoney { get {return PlayerStats.Money >= turretToBuild.cost; } }

	public void SelectTurretToBuild(TurretBlueprint turret) {
		turretToBuild = turret;
		DeselectNode ();
	}

	public void SelectNode(Node node) {

		if (selectedNode == node) {
			DeselectNode ();
			return;
		}

		selectedNode = node;
		turretToBuild = null;

		nodeUI.SetTarget (node);
	}

	public void DeselectNode() {
		selectedNode = null;
		nodeUI.Hide();
	}

	public TurretBlueprint GetTurretToBuild() {
		return turretToBuild;
	}

}