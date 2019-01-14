using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	public float timeBetweenEnemies = 0.5f;

	public Text waveCountDownText;

	private float countDown = 2f;
	private int waveIndex = 0;
	private WaitForSeconds wfEnemy;

	void Start() {
		wfEnemy = new WaitForSeconds (timeBetweenEnemies);
	}

	void Update(){
		if (countDown <= 0) {
			StartCoroutine(SpawnWave());
			countDown = timeBetweenWaves;
		}

		countDown -= Time.deltaTime;
		countDown = Mathf.Clamp(countDown, 0, Mathf.Infinity);
		waveCountDownText.text = string.Format("{0:00.00}", countDown);
	}

	IEnumerator SpawnWave() {
		//Debug.Log ("Wave incoming");
		waveIndex++;
		PlayerStats.Rounds++;

		for (int i = 0; i < waveIndex; i++) {
			SpawnEnemy ();
			yield return wfEnemy;
		}
	}

	void SpawnEnemy() {
		Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}

}
