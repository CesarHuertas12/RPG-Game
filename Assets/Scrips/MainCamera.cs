using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    Transform target; // variable para referirnos al objetivo que la camara seguira.
    private float tLX, tLY, bRX, bRY;


    // Start is called before the first frame update
    public void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // Busca un objeto con ese tag y busca su componente transform.
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x,tLX, bRX), Mathf.Clamp(target.position.y, bRY, tLY), transform.position.z);
       
    }

    public void SetBounds(GameObject map)
    {
        Tiled2Unity.TiledMap config = map.GetComponent<Tiled2Unity.TiledMap>();
        float cameraSize = Camera.main.orthographicSize;

        tLX = map.transform.position.x + cameraSize;
        tLY = map.transform.position.y - cameraSize;
        bRX = map.transform.position.x +  config.NumTilesWide - cameraSize;
        bRY = map.transform.position.y -  config.NumTilesHigh + cameraSize;
    }
}
