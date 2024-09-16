using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject miniAsteroidPrefab;  // Prefab de los mini-asteroides

    public void Divide(Vector3 bulletDirection)
    {
        GameObject miniAsteroid = Instantiate(miniAsteroidPrefab, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Llamamos al método Divide cuando colisiona con una bala
            Vector3 bulletDirection = collision.gameObject.GetComponent<Bullet>().targetVector;
            Divide(bulletDirection);

            // Destruir el asteroide original
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
