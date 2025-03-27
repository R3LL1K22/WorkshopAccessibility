using System;
using UnityEngine;

public class EnnemyShmup : MonoBehaviour
{
    private bool canDamage = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canDamage && other.TryGetComponent<PlayerShmup>(out PlayerShmup player))
        {
            canDamage = false;
            player.takeDamage();
            Destroy(gameObject);
        }
        else if (other.GetComponent<Missile>())
        {
            Debug.Log("Ennemy touched by Missile");
            canDamage = false;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
