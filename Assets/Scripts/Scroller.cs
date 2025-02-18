using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    public float speed;
    [SerializeField] private Renderer bgRenderer;    
    
   
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
