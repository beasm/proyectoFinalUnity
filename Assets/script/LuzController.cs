using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzController : MonoBehaviour
{
    public GameObject luz;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("EncenderApagaLuz");
    }

    IEnumerator EncenderApagaLuz()
    {
        yield return new WaitForSeconds(3f);
        luz.GetComponent<Light>().enabled = !luz.GetComponent<Light>().isActiveAndEnabled;
    }

}