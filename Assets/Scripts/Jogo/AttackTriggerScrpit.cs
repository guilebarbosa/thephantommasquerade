using UnityEngine;
using System.Collections;

public class AttackTriggerScrpit : MonoBehaviour {

    public int dmg = 1;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("takingHITS", dmg);
        }
    }
}
