using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasControllerInicio : MonoBehaviour {
    private int nivelesSuperados;
    private GameObject[] generadorEnemigos;

    void Start()
    {

    }


    public void NivelesAleatorios()
    {
        SceneManager.LoadScene("NivelesAleatorios");
    }

    public void NivelesAleatoriosOscuros()
    {
        SceneManager.LoadScene("NivelesAleatoriosOscuros");
    }

    public void NivelesObtaculos()
    {
        SceneManager.LoadScene("NivelesObtaculos");
    }

    public void Close()
    {
        Application.Quit();
        Screen.fullScreen = false;
    }


}
