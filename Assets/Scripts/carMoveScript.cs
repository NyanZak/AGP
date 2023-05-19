using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMoveScript : MonoBehaviour
{
    public Vector3 direction = new Vector3(1f, 0, 0);

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * (Time.deltaTime));
    }
}
