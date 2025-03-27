using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(transform.position.x +speed * Time.deltaTime, transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
    }
}
