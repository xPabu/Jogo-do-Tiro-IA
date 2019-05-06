using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class varGlobal : MonoBehaviour {

    public ConjuntoInformacoes XML = new ConjuntoInformacoes();
    public float vento = -0.5f;
    public int listsize;

    // Use this for initialization
    void Start () {
        XML = XML.Load("informaçõesJogo.xml");
        listsize = XML.Dados.Count;
    }
	
	// Update is called once per frame
	void Update () {
    }
}
