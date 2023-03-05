using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text cheriesText;

    private int cherries = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Cherry cherry))
        {
            Destroy(collision.gameObject);
            cherries++;
            cheriesText.text = "Cherries: " + cherries;
            Debug.Log(cherries);
        }
    }
}
