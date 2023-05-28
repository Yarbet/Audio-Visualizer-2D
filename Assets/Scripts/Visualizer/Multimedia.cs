using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multimedia : MonoBehaviour
{
    public GUISkin TexturaParaLosTextos;
    AudioClip Sonido;
    void Update()
    {
        if (TexturaParaLosTextos == null)
        {
            Debug.LogError("A�ade una textura");
        }
        //Aqui se controla la rapidez y lentitud
        if (GetComponent<AudioSource>().pitch >= 2)
        {
            GetComponent<AudioSource>().pitch = 2.0f;
        }
        if (GetComponent<AudioSource>().pitch <= 0.1f)
        {
            GetComponent<AudioSource>().pitch = 0.1f;
        }
    }
    void OnGUI()
    {
        GUI.color = Color.white;//Aqui a�ades el color de tu texto
        GUI.skin = TexturaParaLosTextos;
        if (GUI.Button(new Rect(250, 660, 100, 50), "+"))
        {
            GetComponent<AudioSource>().volume += 0.1f;
        }
        if (GUI.Button(new Rect(400, 660, 100, 50), "-"))
        {
            GetComponent<AudioSource>().volume -= 0.1f;
        }
        if (GUI.Button(new Rect(540, 660, 150, 50), "Parar Musica"))
        {
            GetComponent<AudioSource>().mute = true;
        }
        if (GUI.Button(new Rect(720, 660, 150, 50), "Seguir Musica"))
        {
            GetComponent<AudioSource>().mute = false;
        }
        if (GUI.Button(new Rect(900, 660, 150, 50), ">>"))
        {
            GetComponent<AudioSource>().pitch += 0.1f;
        }
        if (GUI.Button(new Rect(1100, 660, 150, 50), "<<"))
        {
            GetComponent<AudioSource>().pitch -= 0.1f;
        }


    }


}
