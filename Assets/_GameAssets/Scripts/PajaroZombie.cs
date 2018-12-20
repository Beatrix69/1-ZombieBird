using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PajaroZombie : MonoBehaviour {
    
    [SerializeField] float fuerza = 8f;
    Rigidbody rb;
    // INICIALIZAMOS A 0
    private int puntos = 0;

    // PARA RECOGER LA REFERENCIA DEL TEXTO DEL CANVAS
    [SerializeField] Text marcadorPuntos;

    // Al declararla Serialize se queda como private pero se ve en el Editor como si fuese publica
    // PARA RECOGER EL SITEMA DE PARTICULAS Y LO ARASTRAMOS EN EL EDITOR 
    [SerializeField] ParticleSystem prefabExplosion;

    // AÑADIMOS EL SONIDO EXPLOSION
    [SerializeField] AudioSource sonidoExplosion;

    // AÑADIMOS EL SONIDO PUNTUACION
    private AudioSource sonidoPuntuacion;

    private void Start()
    {
        // ARRANCA EL JUEGO
        GameConfig.ArrancaJuego();

        // COGEMOS LA REFERENCIA PARA EL SONIDO DE LA PUNTUACION
        sonidoPuntuacion = GetComponent<AudioSource>();
 
        // RECOGEMOS SU RIGIDBODY PORQUE ES LA FORMA DE PODER
        // HACER UNA FUERZA PARA QUE SUBA EL PAJARO AL DAR AL 
        // ESPACIO
        rb = GetComponent<Rigidbody>();

        // ASIGNACION DE LOS PUNTOS
        // LO HEMOS REFACTORIZADO SELECCIONANDO LAS LINEAS DE CODIO QUE QUIERO QUE 
        // ME META EN UN METODO Y LE DAMOS A UNA IMAGEN QUE APARECE A LA IZQUIERDA 
        // Y EL SOLO ME HARA UN METODO CON SUS LLAVES, YO SOLO TENDRE QUE HACER LA 
        // LLAMADA DONDE CORRESPONDA
        ActualizarMarcador();
    }

   

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space"))
        {
            //Debug.Log("Se ha pulsado espacio");
            // NO SE PONE EL DELTA.TIME PORQUE ES UNA FUERZA PUNTUAL.
            rb.AddForce(transform.up * fuerza);
        }
	}

    
    private void OnCollisionEnter(Collision collision)
    {
        // SONIDO CUANDO CHOCA
        //audioSource.Play(); // NO SUENA YA QUE ABAJO LO DESTUYO
        // AL LLAMAR O OTRO OBJETO DISTINTO NO DEJA DE SONARSE AUNQUE SE DESTRUYA EL GO PAJARO
        sonidoExplosion.Play();

        // DETENER EL JUEGO
        GameConfig.ParaJuego();

        // cuando colisione va a aparecer el prefabs de la colision
        // CREAR EL SISTEMA DE PARTICULAS
        Instantiate(prefabExplosion, transform.position, Quaternion.identity);
 

        // DESACTIVAR EL GO PARA QUE NO APAREZCA EL PAJARO
        gameObject.SetActive(false);

        // LLAMA A FINALIZAR PARTIDA DESPUES DE 3,5 SEGUNDOS
        Invoke("FinalizarPartida", 3.5f);

        //StartCoroutine(ContadorTiempo());

        // CUANDO EL PAJARO COLISIONA CON LA TUBERIA SE DESTRUYE
        // Y HACEMOS QUE SE RECARGUE LA ESCENA 0
        //FinalizarPartida();

        // NO PODRIA HACER DARIA ERROR
        //prefabExplosion.Play();
        // TENDRIA QUE HACER ESTO

    }

    // prueba de gitHub
   /* IEnumerator ContadorTiempo()
    {
        yield return new WaitForSeconds(3);
        FinalizarPartida(); 
    }*/

    private void FinalizarPartida()
    {
        //Destroy(this.gameObject); LO HEMOS DESACTIVADO ANTES
        SceneManager.LoadScene(0);
    }

    // SE VA A DISPARAR CUANDO ENTRE EN UN COLLIDER AL ENTRAR
    private void OnTriggerEnter(Collider other)
    {
        // RECOJO EL AUDIOSOURCE PARA QUE SUENE CUANDO PUNTUE
        sonidoPuntuacion.Play();


        // SUMAMOS PUNTOS Y MOSTRAMOS POR PANTALLA
        // HEMOS QUITADO TODOS LOS COLISIONADORES AL PAJARO Y HEMOS
        // HECHO UNO QUE COGE HASTA EL PICO PARA QUE SOLO SUME UNO
        // YA QUE SI EL PAJARO TIENE MUCHOS COLISIONADORES ENTRARIA A ESTE TRIGGER
        // Y SUMARIO MAS DE 1 PUNTO
        puntos++;
        // ASIGNACION DE LOS PUNTOS
        ActualizarMarcador();
        Debug.Log("HA PASADO ENTRE LAS TUBERIAS PUNTOS: "+puntos);
    }

    private void ActualizarMarcador()
    {
        // FUNCIONA BIEN
        //marcadorPuntos.text = "Score: "+puntos.ToString();
        // PROTESTARIA PORQUE ESTAMOS ASIGNADO UN NUMERO A UN TEXTO
        //marcadorPuntos.text = puntos;
        // SI PONEMOS UN TEXTO TRANSFORMA LOS PUNTOS A TEXTO
        marcadorPuntos.text = "Score: " + puntos;
    }

}
