using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region ===== Declarations =====
    private GameObject _enemy;
    [SerializeField] private int _enemyLife = 1;

    [SerializeField] private int _enemySpeed;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    private Transform _currentPos;
    #endregion

    private void Start()
    {
        _currentPos = _pointA;
    }

    private void Update()
    {
        EnemyPatrol();
    }

    private void EnemyPatrol()
    {
        _enemy.transform.position = Vector2.MoveTowards(_enemy.transform.position, _currentPos.transform.position, _enemySpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, _enemy.transform.position) < 0.5f)
        {
            if (_currentPos == _pointA)
            {
                _currentPos = _pointB;
            }
            else
            {
                _currentPos = _pointA;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = GetComponent<Player>();

        if (player != null) 
        {
            //player.GotHit();
            //Anim Hit On Player
        }
    }

    public void GotHit()
    {
        _enemyLife--;

        if (_enemyLife < 0)
        {
            //Anim Enemy death (Sprite fainting)
            Destroy(_enemy);
        }

    }
}
