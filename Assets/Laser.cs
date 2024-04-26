using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float distance = 5f;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float cdMin = 2f;
    [SerializeField] private float cdMax = 5f;


    private bool canRay;
    void Start()
    {
        canRay = true;
        StartCoroutine(SecuenciaDisparo());
    }

    private void OnDrawGizmos()
    {
        if (canRay)
        {
            Debug.DrawLine(transform.position, transform.position + (transform.forward * distance), Color.cyan);
        }
    }
    
    void Update()
    {
        if (canRay)
        {
            bool isHit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance, playerMask);
            if (isHit)
            {
                hit.collider.GetComponent<SpyPlayer>().Death();
            }
        }
    }
    IEnumerator SecuenciaDisparo()
    {
        while (true)
        {
            canRay = true;
            yield return new WaitForSeconds(Random.Range(cdMin,cdMax));
            canRay = false;
            yield return new WaitForSeconds(Random.Range(cdMin, cdMax));
        }
    }
}
