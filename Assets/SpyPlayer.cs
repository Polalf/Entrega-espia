using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpyPlayer : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 10f;
    private Vector3 velocity;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

    }
    void Update()
    {
        velocity.x = Input.GetAxisRaw("Horizontal") * speed;
        velocity.z = Input.GetAxisRaw("Vertical") * speed;
        
    }
    public void Death()
    {
        Debug.Log("Muelto");
        //StartCoroutine(DeathAnim());
        LevelManager.Instance.ChargeScene(LevelManager.Instance.index);
    }


    //IEnumerator DeathAnim() // Esperar antes de la muerte para chantar una Game Over Screen
    //{
    //    Debug.Log("Muelto, Reseteo en 2s" );
    //    yield return new WaitForSeconds(2f);
    //    LevelManager.Instance.ChargeScene(LevelManager.Instance.index);
    //}
}
