using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureAnimation : MonoBehaviour
{
    public Texture2D[] textures;
    public float delay = 0.07f;
    private IEnumerator Start()
    {
        var mat = GetComponent<Renderer>().material;
        int i = 0;
        while(true)
        {
            mat.mainTexture = textures[i];
            yield return new WaitForSeconds(delay);
            i++;
            if (textures.Length - 1 == i)
                i = 0;
        }
    }
}
