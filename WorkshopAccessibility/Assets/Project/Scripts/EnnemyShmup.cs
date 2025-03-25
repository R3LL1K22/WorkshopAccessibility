using System;
using UnityEngine;

public class EnnemyShmup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerShmup>(out PlayerShmup player))
        {
            player.takeDamage();
        }
        else if (other.GetComponent<Missile>())
        {
            Debug.Log("Ennemy touched by Missile");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
