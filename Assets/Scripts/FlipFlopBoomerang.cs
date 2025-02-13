using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFlopBoom : MonoBehaviour
{
    [SerializeField] GameObject ffBoomerang;
    
    [SerializeField] Transform ffLocation;
    [SerializeField] Transform ffRotation;

    [SerializeField] float ffDistance; 
    [SerializeField] float throwSpeed; 
    
    [SerializeField] LayerMask layerMask;

    [SerializeField] bool isThrown;
    [SerializeField] bool isReturning;

    [SerializeField] Vector3 throwPosition;
    [SerializeField] Rotator rotator;
    
    [SerializeField] ColorChangeOncollision colorChangeOnCollision;
    
    [SerializeField] float damage;
    
    //[SerializeField] Health healthObjectHit;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isThrown || isReturning) return;
            CheckDistance();
        }

        if (isThrown)
        {

            Vector3 newPos = Vector3.MoveTowards(ffBoomerang.transform.position, throwPosition, throwSpeed * Time.deltaTime);
            
            ffBoomerang.transform.position = newPos;

            ffBoomerang.GetComponent<MeshCollider>().enabled = true;

            if (ffBoomerang.transform.position == throwPosition)
            {
                if(colorChangeOnCollision != null)
                {
                    colorChangeOnCollision.ChangeColor();
                    colorChangeOnCollision = null;
                }
                //if(healthObjectHit != null)
                //{
                //    healthObjectHit.TakeDamage(damage);
                //    healthObjectHit = null;
                //}
            
                isThrown = false;
                isReturning = true;
            
            }
                          
        }

        if (isReturning)
        {
            Vector3 newPos = Vector3.MoveTowards(ffBoomerang.transform.position, ffLocation.position, throwSpeed * Time.deltaTime);

            if(ffBoomerang.transform.position == ffLocation.position)
            {
                isReturning = false;
                rotator.enabled = false;
                ffBoomerang.transform.parent = ffLocation;
                ffBoomerang.transform.rotation = ffRotation.rotation;
            }
        }     
    }

    void CheckDistance()
    {
        RaycastHit hit;

        if(Physics.Raycast(ffLocation.transform.position,ffLocation.transform.forward,out hit, ffDistance,layerMask))
        {
            if(hit.transform.GetComponentInParent<ColorChangeOncollision>() != null)
            {
                colorChangeOnCollision = hit.transform.GetComponentInParent<ColorChangeOncollision>();
            }
            //if(hit.transform.GetComponentInParent<Health>() != null)
            //{
            //    healthObjectHit = hit.transform.GetComponentInParent<Health>();
            //}

            throwPosition = hit.point;
            ffBoomerang.transform.parent = null;
            rotator.enabled= true;
            isThrown = true;
        
        
        }
        else
        {
            throwPosition = ffLocation.forward * ffDistance;
            ffBoomerang.transform.parent = null;
            rotator.enabled = true;
            isThrown = true;
        }
    }















}
