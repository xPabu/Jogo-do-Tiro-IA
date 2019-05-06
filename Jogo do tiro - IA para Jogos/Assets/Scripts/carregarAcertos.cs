using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carregarAcertos : MonoBehaviour {

    private bool carregar = false;
    private varGlobal scriptGlobal;
    private int f;
    private GameObject objetivo;
    private GameObject obstaculo;
    private GameObject particulas1;
    private GameObject particulas2;
    private GameObject arma;

    // Use this for initialization
    void Start () {
        scriptGlobal = GameObject.Find("GameManager").GetComponent<varGlobal>();
        objetivo = GameObject.Find("objetivo");
        obstaculo = GameObject.Find("obstaculo");
        particulas1 = GameObject.Find("ParticleSystem");
        particulas2 = GameObject.Find("ParticleSystemPositivo");
        arma = GameObject.Find("arma");
        f = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void inicializar()
    {
        if(carregar == false)
        {
            carregar = true;
            proximoTiro();
        }
        else
        {
            carregar = false;
        }
    }

    public bool getCarregar()
    {
        return carregar;
    }

    public void proximoTiro()
    {
        if (f != scriptGlobal.listsize)
        {
            objetivo.transform.position = new Vector3(objetivo.transform.position.x, scriptGlobal.XML.Dados[f].getAlturaAlvo(), objetivo.transform.position.z);
            obstaculo.transform.position = new Vector3(scriptGlobal.XML.Dados[f].getPosicaoObstaculo(), obstaculo.transform.position.y, obstaculo.transform.position.z);
            obstaculo.transform.localScale = new Vector3(obstaculo.transform.localScale.x, scriptGlobal.XML.Dados[f].getAlturaObstaculo(), obstaculo.transform.localScale.z);
            scriptGlobal.vento = scriptGlobal.XML.Dados[f].getVento();
            particulas1.GetComponent<controladorParticulas>().atualizaVento();
            particulas2.GetComponent<controladorParticulas>().atualizaVento();
            arma.GetComponent<Transform>().rotation = Quaternion.Euler(arma.GetComponent<Transform>().rotation.x, arma.GetComponent<Transform>().rotation.y, scriptGlobal.XML.Dados[f].getAnguloArma());
            f++;
            arma.GetComponent<rodar>().atirar();

        }
        else
        {
            carregar = false;
        }

    }
}
