using UnityEngine;
using System.Collections;

public class AttackTriggerE : MonoBehaviour {

    public int dmg = 1;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Player"))
        {
            col.SendMessageUpwards("takingHITS", dmg);
        }
    }
 
}
