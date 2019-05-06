using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class destroibala : MonoBehaviour {

    private varGlobal scriptGlobal;
    private carregarAcertos scriptAutomatico;

	// Use this for initialization
	void Start () {
        //Destroy(gameObject, 5);
        scriptGlobal = GameObject.Find("GameManager").GetComponent<varGlobal>();
        scriptAutomatico = GameObject.Find("GameManager").GetComponent<carregarAcertos>();
    }
	
	// Update is called once per frame
	void Update () {

        GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x + scriptGlobal.vento, GetComponent<Rigidbody>().velocity.y, 0);
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (!scriptAutomatico.getCarregar())
        {
            if (collision.gameObject.name == "alvo")
            {
                Dado info = new Dado();
                info.setAnguloArma(GameObject.Find("arma").GetComponent<Transform>().eulerAngles.z);
                info.setDistanciaObstaculo(distanciaObstaculo());
                info.setPosicaoObstaculo(GameObject.Find("obstaculo").GetComponent<Transform>().position.x);
                info.setAlturaObstaculo(GameObject.Find("obstaculo").GetComponent<Transform>().lossyScale.y);
                info.setAlturaAlvo(GameObject.Find("objetivo").GetComponent<Transform>().position.y);
                info.setVento(scriptGlobal.vento);
                scriptGlobal.XML.Dados.Add(info);
                Debug.Log("COLIDIU");
                scriptGlobal.XML.Save("informaçõesJogo.xml");
            }
        }
        else
        {
            scriptAutomatico.proximoTiro();
        }
        Destroy(gameObject);

    }

    private float distanciaObstaculo()
    {
        float distancia;

        if(transform.position.x > GameObject.Find("obstaculo").GetComponent<Transform>().position.x)
        {
            distancia = transform.position.x - GameObject.Find("obstaculo").GetComponent<Transform>().position.x;
        }
        else
        {
            distancia = GameObject.Find("obstaculo").GetComponent<Transform>().position.x - transform.position.x;
        }

        return distancia;
    }

}
