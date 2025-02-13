using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float speedX;
    [SerializeField] float speedY;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speedX, speedY, 0);
    }
}
