using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    
    public int force = -25;

	void OnCollisionEnter2D(Collision2D col){
        PlayerHealth health = col.gameObject.GetComponent<PlayerHealth>();
        if (health != null){
            health.change_hp(-1);
            Vector2 dir = col.gameObject.GetComponent<PlayerInput>().dir;
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(dir*force, ForceMode2D.Impulse);
        }
    }
}
