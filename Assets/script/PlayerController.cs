using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float sizeStep = 1.5f;
    public float correctionStep = 0.75f;
    private bool alcanzadoFin;
    private bool movingPiece;
    private ArrayList pasos = new ArrayList();

    //public PolygonCollider2D polygonCollider2D;

    // Use this for initialization
    void Start()
    {
        int xMax = 0;
        int xMin = -4;
        int yMax = 3;
        int yMin = -3;

        float positionX = UnityEngine.Random.Range(xMin, xMax);
        float positionY = UnityEngine.Random.Range(yMin, yMax);
        transform.position = new Vector3((positionX * sizeStep) + correctionStep, (positionY * sizeStep) + correctionStep, 0);
        PointController.pasos = 0;
        movingPiece = false;
        alcanzadoFin = false;


    }

    // Update is called once per frame
    void Update () {
        if (!movingPiece)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                PasoDerecha();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                PasoIzquierda();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                PasoArriba();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                PasoAbajo();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine("EmpezarMoviemientos"); 
            }
        }

    }

    public void PasoDerecha()
    {
        if (!movingPiece)
        {
            pasos.Add("derecha");
            PointController.pasos++;
        }
    }

    public void PasoIzquierda()
    {
        if (!movingPiece)
        {
            pasos.Add("izquierda");
            PointController.pasos++;
        }
    }

    public void PasoArriba()
    {
        if (!movingPiece)
        {
            pasos.Add("arriba");
            PointController.pasos++;
        }
    }

    public void PasoAbajo()
    {
        if (!movingPiece)
        {
            pasos.Add("abajo");
            PointController.pasos++;
        }
    }

    public void PlayMovimientos()
    {
        if (!movingPiece)
        {
            StartCoroutine("EmpezarMoviemientos");
        }
    }

    IEnumerator EmpezarMoviemientos()
    {
        movingPiece = true;
        float pasito = sizeStep / 10;
        foreach (string paso in pasos)
        {
            if (!alcanzadoFin)
            {
                switch (paso)
                {
                case "derecha":
                    for (int i = 0; i < 10; i++)
                    {
                        transform.position += new Vector3(pasito, 0, 0);
                        yield return new WaitForSeconds(0.01f);
                    }
                    break;

                case "izquierda":
                    for (int i = 0; i < 10; i++)
                    {
                        transform.position += new Vector3(-pasito, 0, 0);
                    yield return new WaitForSeconds(0.01f);
                    }
                    break;

                case "abajo":
                    for (int i = 0; i < 10; i++)
                    {
                        transform.position += new Vector3(0, -pasito, 0);
                        yield return new WaitForSeconds(0.01f);
                    }
                    break;

                case "arriba":
                    for (int i = 0; i < 10; i++)
                    {
                        transform.position += new Vector3(0, pasito, 0);
                        yield return new WaitForSeconds(0.01f);
                    }
                    break;
                }
                PointController.pasos--;
                yield return new WaitForSeconds(0.5f);
            }
        }

        if (alcanzadoFin)
        {
            PointController.pasos = 0;
            SetNivelesSuperados(GetNivelesSuperados() + 1);
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("NivelesAleatorios");
        } else
        {
            //TODO: O volver al origen
            pasos = new ArrayList();
            movingPiece = false;
        }
    }

    private int GetNivelesSuperados()
    {
        return PlayerPrefs.GetInt("nivel1", 0);
    }

    private void SetNivelesSuperados(int bonus)
    {
        PlayerPrefs.SetInt("nivel1", bonus);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish" && !alcanzadoFin)
        {
            alcanzadoFin = true;
        }

    }

}
