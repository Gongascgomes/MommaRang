using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    [SerializeField] FlipFlopBoom ffboom;

    private int _health = 3;

    private bool _ableToTakeDamage = true;
    
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform targetPosition; 
    [SerializeField] private float _detectWallRay; 
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _wallLayer;
    private bool _canJump = true;


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move forward
        transform.position = Vector2.Lerp(transform.position, new Vector2(targetPosition.transform.position.x, transform.position.y), Time.deltaTime * speed);

        // Detect wall
        if (!_canJump) { return; }

        if (Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.7f), Vector2.right, _detectWallRay, _wallLayer))
        {
            StartCoroutine(Jump());
        }
    }

    private IEnumerator Jump()
    {
        _canJump = false;
        _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.5f);
        _canJump = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.7f), Vector2.right * _detectWallRay);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        FlipFlopBoom ffbomerang = collision.gameObject.GetComponent<FlipFlopBoom>();

        if (ffbomerang != null && _ableToTakeDamage == true)
 
        {
            TakeDamage();
        
            StartCoroutine(WhenCanTakeDamage());
        }          

    }
    




    public void TakeDamage()
    {
    
            _health--;
            print("aiaiai");
            //take damage sound
        
        
        
        if (_health <= 0)
        {
            //final damage sound ooof
            
            //victory
        }
    
        
    }


    IEnumerator WhenCanTakeDamage() 
    {
        _ableToTakeDamage = false;   
    
    
        yield return new WaitForSeconds(0.5f);

        _ableToTakeDamage = true;
    }






}
