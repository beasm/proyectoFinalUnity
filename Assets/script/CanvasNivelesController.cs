using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasNivelesController : MonoBehaviour {
    private int nivelesSuperados;

    void Start()
    {
        nivelesSuperados = GetNivelesSuperados(); // obtenemos los niveles superados

        for (int i = 1; i < nivelesSuperados+1 && i < 19; i++) // bucle desde uno hasta los niveles superados
        {
            // activamos las estrellas para todos lo niveles activados
            GameObject.FindGameObjectWithTag("Nivel"+i).SetActiveRecursively(true);
        }
    }

    /*
     * Metodo para obtener los niveles
     */
    private int GetNivelesSuperados()
    {
        return PlayerPrefs.GetInt("nivel1", 0);
    }

    /**
     * vamos al escenario de inicio
     */
    public void Inicio()
    {
        SceneManager.LoadScene("Inicio");
    }

    /**
     * vamos al escenario del nivel basico
     */ 
    public void Aleatorio()
    {
        SceneManager.LoadScene("escenaBase");
    }

}
