using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    [SerializeField] Sprite[] cropSprites;
    [SerializeField] Sprite[] animalSprites;
    [SerializeField] GameObject[] textPrefabs;
    [SerializeField] GameObject[] animationPrefabs;
    public Sprite[] CropSprites { get => cropSprites; }
    public Sprite[] AnimalSprites { get => animalSprites; }
    public GameObject[] TextPrefabs { get => textPrefabs; }
    public GameObject[] AnimationPrefabs { get => animationPrefabs; }
}
