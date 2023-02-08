using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) //Marcherais si il y avait un code pour la barre de vie
    {
        //if(Collider.GetComponent<health>() != null)
        //{
        //    Health health = Collider.GetComponent<Health>();
        //    health.Damage(damage);
        //}
    }
}
