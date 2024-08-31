using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{

    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;

    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Shoot();
        }
    }
 
    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        Debug.Log("shooting");
        projectile.transform.position = positionToShoot.position;
    }

}
