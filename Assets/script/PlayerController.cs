using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public float sizeStep = 1.5f;
    public float correctionStep = 0.75f;
    private bool alcanzadoFin;
    private bool movingPiece;
    private ArrayList pasos = new ArrayList();

    /*
     * funcion para inicializar las variable
     */
    void Start()
    {
        transform.position = new Vector3((RamdomX() * sizeStep) + correctionStep, (RamdomY() * sizeStep) + correctionStep, 0);  // posicion inicial aleatoria
        PointController.pasos = 0; // reiniciamos el valor de los pasos
        movingPiece = false;
        alcanzadoFin = false;
    }

    /*
     * metodo para calcula un numero aleatorio X entre 0 y 4 los posibles valores
     */
    static int RamdomX()
    {
        int xMax = 0; // valor maximo de posicion
        int xMin = -4; // valor minimo para que salga solo a la derecha de la pantalla
        return Random.Range(xMin, xMax);
    }

    /*
     * metodo para calcula un numero aleatorio Y entre -3 y 3 los posibles valores
     */
    static float RamdomY()
    {
        int yMax = 3; // valor maximo hacia arriba
        int yMin = -3; // valor minimo por debajo
        return Random.Range(yMin, yMax);
    }

    /*
     * se actualiza por cada frame
     */
    void Update () {
        if (!movingPiece) // si la pieza no se esta moviendo
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)) // si se pulda la tecla de dirrecion derecha
            {
                PasoDerecha();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) // si se pulda la tecla de dirrecion izquierda
            {
                PasoIzquierda();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))  // si se pulda la tecla de dirrecion arriba 
            {
                PasoArriba();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow)) // si se pulda la tecla de dirrecion abajo
            {
                PasoAbajo();
            }
            if (Input.GetKeyDown(KeyCode.Space)) // si se pulda la tecla espaciadora
            {
                StartCoroutine("EmpezarMoviemientos"); 
            }
        }

    }

    /*
     * anadimos al contador de pasos uno y anadimos el String derecha
     */ 
    public void PasoDerecha()
    {
        if (!movingPiece)
        {
            pasos.Add("derecha");
            PointController.pasos++;
        }
    }

    /*
     * anadimos al contador de pasos uno y anadimos el String izquierda
     */
    public void PasoIzquierda()
    {
        if (!movingPiece)
        {
            pasos.Add("izquierda");
            PointController.pasos++;
        }
    }

    /*
     * anadimos al contador de pasos uno y anadimos el String arriba
     */
    public void PasoArriba()
    {
        if (!movingPiece)
        {
            pasos.Add("arriba");
            PointController.pasos++;
        }
    }

    /*
     * anadimos al contador de pasos uno y anadimos el String abajo
     */
    public void PasoAbajo()
    {
        if (!movingPiece)
        {
            pasos.Add("abajo");
            PointController.pasos++;
        }
    }

    /*
     * Empezamos el metodo para empezar los movimientos
     */
    public void PlayMovimientos()
    {
        if (!movingPiece)
        {
            StartCoroutine("EmpezarMoviemientos");
        }
    }

    /*
     * Metodo que recore la lista de pasos para realizar los movimientos
     */ 
    IEnumerator EmpezarMoviemientos()
    {
        movingPiece = true; // activamos la variable
        float pasito = sizeStep / 10; // divido por 10 para que el movimiento sea mas real
        foreach (string paso in pasos) // recorremos la lista con todos los pasos
        {
            if (!alcanzadoFin) // si no se ha alcanzado el fin
            {
                switch (paso) // seletor de los pasos
                {
                case "derecha":
                    for (int i = 0; i < 10; i++) // recorremos los 10 pasitos
                    {
                        transform.position += new Vector3(pasito, 0, 0); // cambiamos la posicion
                        yield return new WaitForSeconds(0.01f); // esperamos 0.01f
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
                PointController.pasos--; // quitamos un paso
                yield return new WaitForSeconds(0.5f); // espemos 0.5f
            }
        }

        if (alcanzadoFin) // si se ha alzado el fin
        {
            PointController.pasos = 0; // reiniciamos el valor
            SetNivelesSuperados(GetNivelesSuperados() + 1); // anadimos un nivel mas
            yield return new WaitForSeconds(1f); // esperamos 1f
            SceneManager.LoadScene("NivelesAleatorios"); // Cargamos la pantalla anterior
        }
        else // si no hemos llegado al fin
        {
            pasos = new ArrayList(); // vaciamos la lista
            movingPiece = false; // desactivamos la variable
        }
    }

    /*
     * Metodo para obtener los niveles superados
     */
    private int GetNivelesSuperados()
    {
        return PlayerPrefs.GetInt("nivel1", 0);
    }

    /*
     * Metodo para cambiar los niveles superados
     */
    private void SetNivelesSuperados(int bonus)
    {
        PlayerPrefs.SetInt("nivel1", bonus);
    }


    /*
     * Evento de colision con el final
     */ 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish" && !alcanzadoFin)
        {
            alcanzadoFin = true; // activamos la variable
        }

    }

}
