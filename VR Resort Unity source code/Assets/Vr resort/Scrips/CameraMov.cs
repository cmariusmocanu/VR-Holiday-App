using UnityEngine;
using System.Collections;

public class CameraMov : MonoBehaviour
{

    public float speed;
    private Rigidbody poz;

    void Start()
    {
    }

    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);
    }
}