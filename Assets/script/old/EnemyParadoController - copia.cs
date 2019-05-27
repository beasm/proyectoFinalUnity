using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParadoController : MonoBehaviour
{
    private Transform targetPlayer;
    public float velocidadEnemy = 1f;
    private bool colision = false;
    private GameObject padre;

    // Use this for initialization
    void Start()
    {
        padre = transform.root.gameObject;
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPlayer != null && colision)
        {
            padre.transform.position = Vector3.MoveTowards(padre.transform.position, targetPlayer.position, velocidadEnemy * Time.deltaTime);
            if (transform.position.x > targetPlayer.position.x)
            {
                padre.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                padre.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            colision = true;
        }
    }
}
