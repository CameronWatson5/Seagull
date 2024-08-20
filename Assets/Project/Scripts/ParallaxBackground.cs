using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxEffectMultiplier;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    private float textureUnitSizeY; 

    void Start()
    {
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier, deltaMovement.y * parallaxEffectMultiplier, 0);
        lastCameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }

        if (cameraTransform.position.y > transform.position.y + textureUnitSizeY / 2)
        {
            float offsetPositionY = cameraTransform.position.y - transform.position.y + textureUnitSizeY / 2;
            transform.position += new Vector3(0, offsetPositionY, 0);
        }
        else if (cameraTransform.position.y < transform.position.y - textureUnitSizeY / 2)
        {
            float offsetPositionY = cameraTransform.position.y - transform.position.y - textureUnitSizeY / 2;
            transform.position += new Vector3(0, offsetPositionY, 0);
        }

    }
}