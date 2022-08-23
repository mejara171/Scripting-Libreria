using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float BulletSpeed = 8f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var fireballInst = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector2(0, 0)));
            fireballInst.velocity = new Vector2(BulletSpeed, 0);
        }
    }
}
