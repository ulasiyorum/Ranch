using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static void PlayAnimation(GameObject prefab,Sprite sprite)
    {
        prefab.GetComponent<SpriteRenderer>().sprite = sprite;
        GameObject go = Instantiate(prefab);
        Destroy(go,go.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length-.25f);
    }
}
