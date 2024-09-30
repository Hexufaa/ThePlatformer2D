using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{

    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float timeBetweenShoot = 0.3f;
    public Transform playerSideReference;
    private Coroutine _currentCoroutine;

    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }else if(Input.GetKeyUp(KeyCode.C)){
            if(_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator StartShoot(){
        while(true){
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }
 
    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }

}
