using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorParticulas : MonoBehaviour
{

    varGlobal scriptGlobal;

    // Use this for initialization
    void Start()
    {
        scriptGlobal = GameObject.Find("GameManager").GetComponent<varGlobal>();
        atualizaVento();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void atualizaVento()
    {
        var ps = GetComponent<ParticleSystem>();
        enableParticles();
        if (scriptGlobal.vento < 0)
        {
            if (this.name == "ParticleSystemPositivo")
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (this.name != "ParticleSystemPositivo")
            {
                gameObject.SetActive(false);
            }
        }

        var psMain = ps.main;
        var psEmission = ps.emission;

        psEmission.rateOverTime = Mathf.Abs(scriptGlobal.vento) * 200;
        psMain.startSpeed = Mathf.Abs(scriptGlobal.vento) * 100;
    }

    public void enableParticles()
    {

        if (this.name == "ParticleSystemPositivo")
        {
            gameObject.SetActive(true);
        }

        if (this.name != "ParticleSystemPositivo")
        {
            gameObject.SetActive(true);
        }

    }
}
