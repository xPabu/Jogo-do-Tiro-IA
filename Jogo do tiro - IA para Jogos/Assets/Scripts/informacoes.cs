using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class Dado{

    public float anguloArmaZ;
    public float distanciaObstaculo;
    public float posicaoObstaculo;
    public float alturaObstaculo;
    public float alturaAlvo;
    public float vento;

    public Dado()
    {
        
    }

    public float getDistanciaObstaculo()
    {
        return distanciaObstaculo;
    }

    public void setDistanciaObstaculo(float info)
    {
        distanciaObstaculo = info;
    }

    public float getAlturaObstaculo()
    {
        return alturaObstaculo;
    }

    public void setPosicaoObstaculo(float info)
    {
        posicaoObstaculo = info;
    }

    public float getPosicaoObstaculo()
    {
        return posicaoObstaculo;
    }

    public void setAlturaObstaculo(float info)
    {
        alturaObstaculo = info;
    }

    public float getAlturaAlvo()
    {
        return alturaAlvo;
    }

    public void setAlturaAlvo(float info)
    {
        alturaAlvo = info;
    }

    public float getAnguloArma()
    {
        return anguloArmaZ;
    }

    public void setAnguloArma(float info)
    {
        anguloArmaZ = info;
    }

    public float getVento()
    {
        return vento;
    }

    public void setVento(float info)
    {
        vento = info;
    }



}

[XmlRoot("ColecaoInformacoes")]
public class ConjuntoInformacoes
{

    [XmlArray("Dados"), XmlArrayItem("Dado")]
    public List<Dado> Dados = new List<Dado>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(ConjuntoInformacoes));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
            Debug.Log("Salvou");
        }
    }

    public ConjuntoInformacoes Load(string path)
    {
        var serializer = new XmlSerializer(typeof(ConjuntoInformacoes));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as ConjuntoInformacoes;
        }
    }

}
