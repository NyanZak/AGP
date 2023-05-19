using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeDestroy : MonoBehaviour
{
    public float lifeTime;
    void Start()
    {
        Invoke("cleanUp", lifeTime);
    }

   void cleanUp()
    {
        Destroy(gameObject);
    }    
}
