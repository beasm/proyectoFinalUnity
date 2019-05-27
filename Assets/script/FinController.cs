using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinController : MonoBehaviour {
    public GameObject panelFin;

    void Start()
    {
        float sizeStep = 1.5f;
        float correctionStep = 0.75f;
        transform.position = new Vector3((RamdomX() * sizeStep) + correctionStep, (RamdomY() * sizeStep) + correctionStep, 0);
    }

    static int RamdomX()
    {
        int xMax = 4;
        int xMin = 0;
        return Random.Range(xMin, xMax);
    }

    static float RamdomY()
    {
        int yMax = 3;
        int yMin = -3;
        return Random.Range(yMin, yMax);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //panelFin.SetActive(true);
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetTrigger("Fin");
            //player.SendMessage("Fin");
            //gameController.SendMessage("Victoria");
        }
    }

}
