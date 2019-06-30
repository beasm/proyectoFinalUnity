using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * 
 */
public class CanvasController : MonoBehaviour {
    public Text m_pasos;

    /**
     *  Se actualiza una vez por frame
     */
    void Update () {
        m_pasos.text = "Pasos: " + PointController.pasos;

    }

    /**
    * Volvemos a la panta de inicio
    */
    public void Salir()
    {
        SceneManager.LoadScene("Inicio");
        //Application.Quit();
    }

    /**
    * Salimos de la aplicacion
    */
    public void Close()
    {
        Application.Quit();
    }

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
}
