using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovilController : MonoBehaviour {
    public Transform target;
    public float velocidad = 0.75f;
    public Vector3 start, end;
	// Use this for initialization
	void Start () {
        start = transform.position;
        end = target.position;
        GameObject.FindGameObjectWithTag("PlataformaMovil").transform.parent = null;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.position, velocidad * Time.deltaTime);
        if (transform.position == target.position)
        {
            if (target.position == start)
            {
                target.position = end;
            } else
            {
                target.position = start;
            }
        }
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.parent = transform;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }

}
