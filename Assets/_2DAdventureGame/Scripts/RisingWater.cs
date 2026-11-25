using UnityEngine;

public class RisingWater : MonoBehaviour
{
    public float riseSpeed = 0.2f;
    public float maxHeight = 6.0f;
    public int damage = 1;
    public bool showOnHud = false;

    float startHeight;

    void Start()
    {
        startHeight = transform.position.y;
    }

    void Update()
    {
        if (transform.position.y < maxHeight)
        {
            transform.position += Vector3.up * riseSpeed * Time.deltaTime;
        }

        if (showOnHud)
        {
            float part = (transform.position.y - startHeight) / (maxHeight - startHeight);
            int percent = (int)(part * 100);
            if (percent > 100)
            {
                percent = 100;
            }
            UIHandler.instance.SetWaterValue(percent);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            controller.ChangeHealth(-damage);
        }
    }
}