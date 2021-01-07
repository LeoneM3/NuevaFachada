using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class transciones : MonoBehaviour {

public void CambiarEscena(string nombre){

    print("Cambiando a la escena " + nombre);
    SceneManager.LoadScene(nombre);
}
   
   
}