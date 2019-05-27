using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    public float velocidad = 90f;
    public GameObject gameController;

    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.down * velocidad * Time.deltaTime);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            gameController.SendMessage("ReproducirSonidoMoneda");
            Destroy(gameObject);
            PointController.monedas += 1;
        }
    }

}
