using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        Player player = GetComponent<Player>();

        if (player.Lifes >= 1 && player.Lifes < 3)
        {
            player.Lifes++;
        }
    }
}
