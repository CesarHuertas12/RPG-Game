using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Warp : MonoBehaviour
{
    //Almacena el punto de destino
    public GameObject target;

    //Almacena el mapa de destino
    public GameObject targetMap;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Actualiza la posicion del jugador.
        other.transform.position = target.transform.GetChild(0).transform.position;
        Camera.main.GetComponent<MainCamera>().SetBounds(targetMap);
    }

    private void Awake()
    {
        Assert.IsNotNull(target);
        Assert.IsNotNull(targetMap);

        //Funciona para esconder los warps.
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }
}
