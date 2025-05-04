using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FlipFlopBoom : MonoBehaviour
{

    [SerializeField] private int _speed;
    [SerializeField] private int _rotateSpeed;
    [SerializeField] private float _time;
    [SerializeField] Player _player;

    [SerializeField] private Rigidbody2D rigidBody;




    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = Vector2.right * _speed;
       

    }
    public void SetDirection(Vector2 direction)
    {
        rigidBody.velocity = direction * _speed;
    }
    
    private void Update()
    {
       
        transform.Rotate(_rotateSpeed * Time.deltaTime * Vector3.forward);
        
        
        _time += Time.deltaTime;
        if (_time >= 2)
        {
            Vector2 direction = (_player.transform.position - transform.position).normalized;

           
            rigidBody.velocity = direction * _speed;
        }
    

    }





    private void OnCollisionEnter2D (Collision2D collision)
    {
        Player _player = collision.gameObject.GetComponent<Player>();

        if (_player != null)
        {
            Destroy(gameObject);
        }
    }

   
}
   











