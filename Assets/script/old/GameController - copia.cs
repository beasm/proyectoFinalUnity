using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject panel;
    public GameObject player;
    private Animator anim;
    private AudioClip sonidoMoneda;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        PointController.puntos = 0;
        PointController.monedas = 0;
        PointController.vida = 0;
        anim = player.GetComponent<Animator>();
        sonidoMoneda = audioSource.clip;
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    public void ReproducirSonidoMoneda()
    {
        audioSource.clip = sonidoMoneda;
        audioSource.Play();
    }

    public void ReproducirSonidoMuerte()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    IEnumerator FinJuego()
    {
        player.GetComponentInChildren<Camera>().transform.parent = null;
        player.GetComponentInChildren<ParticleSystem>().Play();
        player.GetComponentInChildren<ParticleSystem>().transform.parent = null;
        anim.SetTrigger("Morrir");
        yield return new WaitForSeconds(1.5f);
        Destroy(player);
        yield return new WaitForSeconds(3f);
        panel.SetActive(true);
    }

    IEnumerator Victoria()
    {
        player.GetComponentInChildren<Camera>().transform.parent = null;
        player.GetComponentInChildren<ParticleSystem>().transform.parent = null;
        anim.SetTrigger("Victoria");
        yield return new WaitForSeconds(1.5f);
        Destroy(player);
    }

}
