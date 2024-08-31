using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
  
    public Vector3 direction;
    public float timeToDestroy = 2f;

    private void Awake(){
        Destroy(gameObject, timeToDestroy);
    }

    private void Update()
    {

        transform.Translate(direction * Time.deltaTime);

    }


}