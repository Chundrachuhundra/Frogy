using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollected : MonoBehaviour
{
    [SerializeField] private float healthValvue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hero")
        {
            collision.GetComponent<Health>().AddHealth(healthValvue);
            gameObject.SetActive(false);
        }
    }
}
