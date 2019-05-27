using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InicioController : MonoBehaviour {


    public void Easy()
    {
        SceneManager.LoadScene("juego2DEasy");
    }

    public void Medium()
    {
        SceneManager.LoadScene("juego2D");
    }

    public void Hard()
    {
        SceneManager.LoadScene("juego2DHard");
    }

    public void Salir()
    {
        Application.Quit();
    }

    void Update()
    {
        
    }
}
