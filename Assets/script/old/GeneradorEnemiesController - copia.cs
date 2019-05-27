using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemiesController : MonoBehaviour {
    public GameObject enemy;
    public float initialWait = 2f;
    public int min = 1;
    public int max = 3;
    // Use this for initialization
    void Start () {
        StartCoroutine("CrearEnemigos");
	}
	
	// Update is called once per frame
	IEnumerator CrearEnemigos () {
        yield return new WaitForSeconds(initialWait);
        while (true)
        {
            Instantiate(enemy, transform.position, enemy.transform.rotation);
            yield return new WaitForSeconds(Random.Range(min,max));
        }
	}

    public void CancelarEnemigos()
    {
        StopCoroutine("CrearEnemigos");
    }
}
