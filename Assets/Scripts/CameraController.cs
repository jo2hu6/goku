using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    //private Transform _transform; YA ESTA DECLARADO EL TRANSFORM, YA EXISTE
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var x = player.transform.position.x + 5;
        var y = player.transform.position.y;
        transform.position = new Vector3(x,y,transform.position.z);
    }
}
