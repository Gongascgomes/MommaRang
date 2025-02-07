using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFlopOnAir : MonoBehaviour
{
    [SerializeField] private GameObject _flipflop;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.GotHit();
        }
    }
}
