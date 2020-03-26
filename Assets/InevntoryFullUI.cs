using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InevntoryFullUI : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(CloseWindow());
    }

    private IEnumerator CloseWindow()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        gameObject.SetActive(false);
    }
}
