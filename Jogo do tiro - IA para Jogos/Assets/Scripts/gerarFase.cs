using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerarFase : MonoBehaviour {

    private varGlobal scriptGlobal;
    private GameObject objetivo;
    private GameObject obstaculo;

	// Use this for initialization
	void Start () {
        scriptGlobal = GameObject.Find("GameManager").GetComponent<varGlobal>();
        scriptGlobal.vento = Random.Range(-0.16f, 0.17f);
        objetivo = GameObject.Find("objetivo");
        obstaculo = GameObject.Find("obstaculo");
        objetivo.transform.position = new Vector3(objetivo.transform.position.x, Random.Range(0.676f, 1.38f), objetivo.transform.position.z);
        obstaculo.transform.position = new Vector3(Random.Range(-3.04f, 3.28f), obstaculo.transform.position.y, obstaculo.transform.position.z);
        obstaculo.transform.localScale = new Vector3(obstaculo.transform.localScale.x,Random.Range(1f,2f) , obstaculo.transform.localScale.z);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
