using UnityEngine;


public class BossBullet : MonoBehaviour
{
    private float lifetime = 2f; 

    private void Start()
    {
        Destroy(gameObject, lifetime); 
    }
}

