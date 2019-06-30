using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasControllerInicio : MonoBehaviour {
    /**
    * vamos a la pantalla de niveles basicos
    */
    public void NivelesAleatorios()
    {
        SceneManager.LoadScene("NivelesAleatorios");
    }

    /**
    * vamos a la pantalla de niveles oscuros
    */
    public void NivelesAleatoriosOscuros()
    {
        SceneManager.LoadScene("NivelesAleatoriosOscuros");
    }

    /**
    * Salimos de la aplicacion o minimizamos la pantalla
    */
    public void Close()
    {
        Application.Quit();
        Screen.fullScreen = false;
    }


}
