using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDelete : MonoBehaviour
{
    public float deathTime;

    private void Awake()
    {
        StartCoroutine(DeathTimer());
    }

    public IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
}
