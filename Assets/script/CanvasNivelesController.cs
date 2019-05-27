using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasNivelesController : MonoBehaviour {
    private int nivelesSuperados;
    private GameObject[] generadorEnemigos;

    void Start()
    {
        nivelesSuperados = GetNivelesSuperados();

        for (int i = 1; i < nivelesSuperados+1 && i < 19; i++)
        {
            GameObject.FindGameObjectWithTag("Nivel"+i).SetActiveRecursively(true);
        }
    }

    private int GetNivelesSuperados()
    {
        return PlayerPrefs.GetInt("nivel1", 0);
    }


    public void Niveles()
    {
        SceneManager.LoadScene("niveles");
    }

    public void Close()
    {
        Application.Quit();
    }

    public void Inicio()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void Aleatorio()
    {
        SceneManager.LoadScene("escenaBase");
    }

    public void Salir()
    {
        SceneManager.LoadScene("Inicio");
        //Application.Quit();
    }

}
