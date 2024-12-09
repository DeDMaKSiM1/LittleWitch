using UnityEngine;

public class PerspectiveChecking : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;

    public void check()
    {
        var Is = sprite.bounds.Contains(transform.position);

        if (!Is)
        {
            sprite.color = new Color(1f, 1f, 1f, 1f);
            return;
        }
        sprite.color = new Color(1f, 1f, 1f, 0.6f);
    }
    private void Update()
    {
        check();
    }
}
