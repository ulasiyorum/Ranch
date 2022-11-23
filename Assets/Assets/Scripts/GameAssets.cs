using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    [SerializeField] Sprite[] cropSprites;
    [SerializeField] GameObject[] animalPrefabs;
    [SerializeField] GameObject[] textPrefabs;
    [SerializeField] GameObject[] animationPrefabs;
    public Sprite[] CropSprites { get => cropSprites; }
    public GameObject[] AnimalPrefabs { get => animalPrefabs; }
    public GameObject[] TextPrefabs { get => textPrefabs; }
    public GameObject[] AnimationPrefabs { get => animationPrefabs; }
}
