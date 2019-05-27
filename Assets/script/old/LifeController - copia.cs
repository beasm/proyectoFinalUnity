using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour {

	void Update () {
        transform.Rotate(Vector3.down * 20 * Time.deltaTime);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            Destroy(gameObject);
            PointController.vida += 1;
        }
    }

}
