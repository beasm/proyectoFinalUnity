using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinController : MonoBehaviour {
    public GameObject panelFin;

    /*
     * funcion para inicializar las variable
     */ 
    void Start()
    {
        float sizeStep = 1.5f; // valor de los pasos
        float correctionStep = 0.75f; // valor de correccion de los pasos
        transform.position = new Vector3((RamdomX() * sizeStep) + correctionStep, (RamdomY() * sizeStep) + correctionStep, 0); // posicion inicial aleatoria
    }

    /*
     * metodo para calcula un numero aleatorio X entre 0 y 4 los posibles valores
     */ 
    static int RamdomX()
    {
        int xMax = 4; // valor maximo de posicion
        int xMin = 0; // valor minimo para que salga solo a la derecha de la pantalla
        return Random.Range(xMin, xMax);
    }

    /*
     * metodo para calcula un numero aleatorio Y entre -3 y 3 los posibles valores
     */
    static float RamdomY()
    {
        int yMax = 3; // valor maximo hacia arriba
        int yMin = -3; // valor minimo por debajo
        return Random.Range(yMin, yMax);
    }

    /*
     * Evento de colision con el jugador
     */ 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play(); // sonido
            GetComponent<Animator>().SetTrigger("Fin"); // animacion
        }
    }

}
