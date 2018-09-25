using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
        PlayerHealth health = col.gameObject.GetComponent<PlayerHealth>();
        if (health != null){
            health.change_hp(-1);
        }
    }
}
