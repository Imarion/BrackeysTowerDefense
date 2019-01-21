using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	//public Transform enemyPrefab;
	public Wave[] waves;
	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	public float timeBetweenEnemies = 0.5f;

	public static int EnemiesAlive = 0;

	public Text waveCountDownText;

	private float countDown = 2f;
	private int waveIndex = 0;

	void Start() {
	}

	void Update(){
		if (EnemiesAlive > 0) {
			return;
		}

		if (countDown <= 0) {
			StartCoroutine(SpawnWave());
			countDown = timeBetweenWaves;
			return;
		}

		countDown -= Time.deltaTime;
		countDown = Mathf.Clamp(countDown, 0, Mathf.Infinity);
		waveCountDownText.text = string.Format("{0:00.00}", countDown);
	}

	IEnumerator SpawnWave() {
		//Debug.Log ("Wave incoming");
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		for (int i = 0; i < wave.count; i++) {
			SpawnEnemy (wave.enemy);
			yield return new WaitForSeconds (1f / wave.rate);
		}

		waveIndex++;

		if (waveIndex == waves.Length) {
			Debug.Log ("LEVEL WON !");
			this.enabled = false;
		}
	}

	void SpawnEnemy(GameObject enemy) {
		Instantiate (enemy, spawnPoint.position, spawnPoint.rotation);
		EnemiesAlive++;
	}

}
