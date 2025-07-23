using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Material material;
    [SerializeField] private float palxSpeed = 0.5f;
    private float offset;
    public float gameSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        ParallaxScroll();
    }

    private void ParallaxScroll()
    {
        float speed = gameSpeed * palxSpeed;
        offset += Time.deltaTime * speed;
        material.SetTextureOffset("_MainTex", Vector2.right * offset);
    }
}
