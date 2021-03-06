using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprites : MonoBehaviour
{
    public Sprite[] sprites;
    public int  current = -1;
    // Start is called before the first frame update
    void Start()
    {
        if (current == -1) {
            current = Random.Range(0, sprites.Length);
        }
        else if (current > sprites.Length)
        {
            current = sprites.Length - 1;
        }
        GetComponent<SpriteRenderer>().sprite = sprites[current];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
