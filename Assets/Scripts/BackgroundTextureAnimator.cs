using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTextureAnimator : MonoBehaviour
{
  // Start is called before the first frame update
  private Material mat;
  private Vector2 offset;

  public float factor = 40f;

  public bool stopped;

  public GameConfiguration config;
  void Start()
  {
    mat = gameObject.GetComponent<Renderer>().material;
    offset = mat.GetTextureOffset("_MainTex");
  }

  // Update is called once per frame
  void Update()
  {
    if (stopped)
    {
      offset.x = offset.x + (0 * Time.deltaTime);
    }
    else
    {
      offset.x = offset.x + ((config.speed / factor) * Time.deltaTime);
    }
    mat.SetTextureOffset("_MainTex", offset);
  }
}
