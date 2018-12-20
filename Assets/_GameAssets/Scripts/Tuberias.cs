using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuberias : MonoBehaviour {

    [SerializeField] private int speed = 5;
    [SerializeField] float limiteInferior = -1;
    [SerializeField] float limiteSuperior = 1;
    [SerializeField] float distanciaDestruccion = -4;

    // Use this for initialization
    void Start () {
        //Debug.Log("Tuberias");
        //Debug.Log("ESTOY INICIALIZANDO");

        // PARA QUE CAMBIE LA Y HACIA ARRIBA Ó ABAJO DE POSICION
        float factorPosicion = Random.Range(limiteInferior, limiteSuperior); 

        // SE POSICIONA CON ESE FACTORPOSICION Y EL RESTO DE X, Z LO DEJAMOS EN LA MISMA POSICION
        transform.position = new Vector3(transform.position.x, transform.position.y + factorPosicion, transform.position.z);

    }
	

	// Update is called once per frame
	void Update () {

        // SI ESTOY JUGANDO LAS COLUMNAS SE SIGUEN MOVIENDO
        if (GameConfig.IsPlaying())
        {
            //Debug.Log("Tuberias");
            //Debug.Log("ESTOY ACTUALIZANDO");
            //Debug.Log(""+ Time.deltaTime);

            // PARA QUE VAYA HACIA LA IZQUIERDA CON UNA VELOCIDAD Y EL TIME PARA QUE VAYA 
            // SIEMPRE A LA MISMA VELOCIDAD EN CUALQUIER PROCESADOR
            transform.Translate(Vector3.left * Time.deltaTime * speed); 
            // SI LA POSICION X ES MENOR -4 SE DESTRUYE LA TUBERIA
            if (transform.position.x < distanciaDestruccion)
            {
                Destroy(gameObject);
            }
        }
    }
    
    // Update is called once per frame
    /*void FixedUpdate()
    {
        // 
        //Debug.Log("Tuberias");
        //Debug.Log("ESTOY ACTUALIZANDO");
        Debug.Log("" + Time.deltaTime);
    }*/
}
