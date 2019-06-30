using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzController : MonoBehaviour
{
    public GameObject luz;

    /*
    * funcion para inicializar las variable
    */
    void Start()
    {
        StartCoroutine("EncenderApagaLuz");
    }

    /*
     * Activa o desactiva la luz despues de esperar una segundos
     */ 
    IEnumerator EncenderApagaLuz()
    {
        yield return new WaitForSeconds(2f);
        luz.GetComponent<Light>().enabled = !luz.GetComponent<Light>().isActiveAndEnabled;
    }

}