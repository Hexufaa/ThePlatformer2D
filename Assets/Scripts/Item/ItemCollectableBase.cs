using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{

    public string compareTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            gameObject.SetActive(false);
            Collect();
        }
    }

    protected virtual void Collect()
    {
        Debug.Log("Collect");
    }

}
