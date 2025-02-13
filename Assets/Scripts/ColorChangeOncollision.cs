using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeOncollision : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    
    public void ChangeColor()
    {
        meshRenderer.material.color = Random.ColorHSV();
    }
}
