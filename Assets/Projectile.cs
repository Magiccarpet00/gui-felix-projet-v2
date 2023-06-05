using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 dir;
    public float speed;
    public float lifeTime;
    
    public void SetUpProjectile(Vector3 _dir, float _speed, float _lifeTime)
    {
        dir = _dir;
        speed = _speed;
        lifeTime = _lifeTime;

        rb = GetComponent<Rigidbody>();
        dir = dir.normalized * speed;
        rb.AddForce(dir, ForceMode.Impulse);
        StartCoroutine(Life());
    }
    
    public IEnumerator Life()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }

}
