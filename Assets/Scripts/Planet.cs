using UnityEngine;

public class Planet : MonoBehaviour
{
    public float speed;
    public bool isMoving;

    private Vector2 min;
    private Vector2 max;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Vector2 viewportBottomLeft = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector2 viewportTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);

        float spriteHeight = spriteRenderer.bounds.extents.y;
        min = new Vector2(viewportBottomLeft.x, viewportBottomLeft.y - spriteHeight);
        max = new Vector2(viewportTopRight.x, viewportTopRight.y + spriteHeight);

        isMoving = false;
    }

    private void Update()
    {
        if (isMoving)
        {
            MovePlanet();
            CheckBounds();
        }
    }

    private void MovePlanet()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void CheckBounds()
    {
        if (transform.position.y < min.y)
        {
            isMoving = false;
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }
}
