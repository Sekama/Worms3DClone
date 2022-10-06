using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    public GameObject impactVFX;

    private bool collided;

    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag != "Projectile" && collision.gameObject.tag != "CurrentPlayer" && !collided)
        {
            collided = true;
            
            var impact = Instantiate (impactVFX, collision.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy (impact, 2);
            Destroy (gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            this.transform.GetComponent<Rigidbody>().AddForce(collision.contacts[0].point, ForceMode.Impulse);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(25);
        }
    }

    private void Update()
    {
        Destroy(gameObject, 5);
    }
        //changed to manual turn switch
    private void OnDestroy() {
      
           // GameManager.Instance.UpdateGameState(GameState.NextTurn);
        
        
    }
}
