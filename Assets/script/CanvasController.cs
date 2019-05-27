using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {
    public Text m_pasos;
    public Text m_points;
    public Text m_coins;
    public Text m_bonus;
    public Text m_best_bonus;
    public Text m_vida;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //int bonus = PointController.monedas * 5 + PointController.puntos;
        m_pasos.text = "Pasos: " + PointController.pasos;
        /*m_points.text = ("Points: " + PointController.puntos);
        m_coins.text = "Coins: " + PointController.monedas;
        m_bonus.text = "Bonus total: " + bonus;
        if (bonus > bestbonus)
        {
            m_best_bonus.text = ("Best bonus: " + bonus);
            SetBestBonus(bonus);
        } else
        {
            m_best_bonus.text = ("Best bonus: " + bestbonus);
        }
        if (m_vida != null)
        {
            if (PointController.vida > 0)
            {
                m_vida.text = ("Extra lifes: " + PointController.vida);
            } else
            {
                m_vida.text = ("");
            }
        }*/
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("juego2D");
    }

    public void Easy()
    {
        SceneManager.LoadScene("escenaBase");
    }

    public void Hard()
    {
        SceneManager.LoadScene("juego2DHard");
    }

    public void Salir()
    {
        SceneManager.LoadScene("Inicio");
        //Application.Quit();
    }

    public void Close()
    {
        Application.Quit();
    }

    public void NivelesAleatorios()
    {
        SceneManager.LoadScene("NivelesAleatorios");
    }

    public void NivelesAleatoriosOscuros()
    {
        SceneManager.LoadScene("NivelesAleatoriosOscuros");
    }
}
