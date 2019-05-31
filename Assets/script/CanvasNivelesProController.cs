using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasNivelesProController : MonoBehaviour {
    private int[] nivelesSuperados;
    private GameObject[] generadorEnemigos;

    void Start()
    {
        nivelesSuperados = GetNivelesSuperados();

        for (int i = 1; i < nivelesSuperados.Length; i++)
        {
            if (nivelesSuperados[i-1] != 0) {
                GameObject.FindGameObjectWithTag("Nivel" + i).SetActiveRecursively(true);
            }
        }
    }

    private int[] GetNivelesSuperados()
    {
        var listtaNiveles = new List<int>();
        for (int i = 1; i < 19; i++)
        {
            listtaNiveles.Add(PlayerPrefs.GetInt("nivelPros"+i, 0));
        }
        return listtaNiveles.ToArray();
    }


    public void Nivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Inicio()
    {
        SceneManager.LoadScene("Inicio");
    }


}
