using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpTextPrefab : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector2(transform.position.x,transform.position.y+1.25f * Time.deltaTime);
        Color c = GetComponent<Text>().color;
        GetComponent<Text>().color = new Color(c.r, c.g, c.b, c.a - 1 * Time.deltaTime);
    }
}
