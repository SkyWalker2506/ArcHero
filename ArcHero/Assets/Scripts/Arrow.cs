using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    static float deathTimeLimit = 10;
    internal float arrowSpeed;

    private void Awake()
    {
        Invoke("DestroyArrow", deathTimeLimit);
    }

    private void Update()
    {
        MoveArrow();
    }

    void MoveArrow()
    {
        transform.position += transform.forward * arrowSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerShotBehaviour>()&&!other.GetComponent<Arrow>())
            DestroyArrow();
    }

    void DestroyArrow()
    {
        Destroy(gameObject);
    }
}