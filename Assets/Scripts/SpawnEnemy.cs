using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance.Enemy != null)
            Instantiate(GameManager.Instance.Enemy, gameObject.transform);
    }

}
