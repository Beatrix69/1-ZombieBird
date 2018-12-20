using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour {

    // Tipo transform
    // Al declararla Serialize se queda como private pero se ve en el Editor como si fuese publica
    [SerializeField] Transform prefabTuberia;

    [Header("COSAS DE GENERACION")]
    // VAMOS A ARREGLAR EL CODIGO
    [SerializeField] float ratioGeneracionTuberias = 2f;

	// Use this for initialization
	void Start () {
        // para llamar de forma repetitiva a u metodo
        InvokeRepeating("GeneratePipe",0,ratioGeneracionTuberias);
	}

    // Para generar las tuberias
    void GeneratePipe()
    {
        if (GameConfig.IsPlaying())
        {
            // Hay que instanciar el objeto Pipe en la posicion del GO Vacio
            // y que cada cierto tiempo se genere el Pipe

            Debug.Log("Generando Tuberia");
            Instantiate(prefabTuberia, transform.position, Quaternion.identity);

        }
    }
}
