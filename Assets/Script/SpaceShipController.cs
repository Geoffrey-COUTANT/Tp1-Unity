using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private Rigidbody2D Rigidbody;
    void Update()
    {
        Vector2 mouvement = new(0, 0);
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W)) mouvement += (Vector2)transform.up;
        if (Input.GetKey(KeyCode.S)) mouvement -= (Vector2)transform.up;
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A)) mouvement -= (Vector2)transform.right;
        if (Input.GetKey(KeyCode.D)) mouvement += (Vector2)transform.right;
        
        Rigidbody.AddForce(mouvement * speed);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Meteorite"))
        {
            ChangeScene();
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
