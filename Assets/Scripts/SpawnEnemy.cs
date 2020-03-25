using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var go = Instantiate(GameManager.Instance.Enemy, gameObject.transform);
       // go.transform.localScale *= 30;
        //go.transform.rotation = new Quaternion(transform.rotation.x, -10, transform.rotation.z, transform.rotation.w);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
