using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rodar : MonoBehaviour {

    private GameObject jogador;
    private float angulo = 20;
    private GameObject tiro;
	// Use this for initialization
	void Start () {
        jogador = GameObject.Find("jogador");
        tiro = Resources.Load("bala") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.RotateAround(jogador.transform.position, new Vector3(0, 0, 1), angulo * Time.deltaTime);
            transform.Rotate(new Vector3(0, 0, 1), angulo * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.RotateAround(jogador.transform.position, new Vector3(0, 0, 1), -angulo * Time.deltaTime);
            transform.Rotate(new Vector3(0, 0, 1), -angulo * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            atirar();
        }

    }

    public void atirar()
    {
        GameObject bala = Instantiate(tiro) as GameObject;
        bala.transform.position = transform.position;
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = transform.up * 15;
    }
}
