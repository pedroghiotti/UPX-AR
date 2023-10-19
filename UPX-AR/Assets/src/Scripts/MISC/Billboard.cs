using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform camera;

    private void Awake()
    {
        camera = Camera.main.transform;
    }

    private void Update()
    {
        this.transform.forward = this.transform.position - camera.position;
    }
}
