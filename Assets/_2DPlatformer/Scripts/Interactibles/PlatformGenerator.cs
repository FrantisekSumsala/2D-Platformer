using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField]
    private Sprite leftSprite;

    [SerializeField]
    private Sprite centerSprite;

    [SerializeField]
    private Sprite rightSprite;

    [SerializeField]
    private int numberOfCenterSprites;

    [SerializeField]
    private int spriteLayerNumber;

    [SerializeField]
    private BoxCollider2D coll;

    [SerializeField]
    private bool vertical = false;

    private void OnEnable()
    {
        int numTiles = numberOfCenterSprites + 2;
        float offset = numTiles % 2 == 0 ? 0.5f : 0f;

        if (vertical)
        {
            // left tile
            GenerateTileObject("TopTile", new Vector3(0, 0 - (float)(numTiles / 2) + offset, 0), leftSprite, spriteLayerNumber);

            //middle tiles
            for (int i = 1; i < numTiles - 1; i++)
                GenerateTileObject($"CentreTile{i}", new Vector3(0, 0f - (float)(numTiles / 2) + i + offset, 0), centerSprite, spriteLayerNumber);

            // right tile
            GenerateTileObject("RightTile", new Vector3(0, 0 + (float)(numTiles - 1) / 2, 0), rightSprite, spriteLayerNumber);

            // adjust collider size
            Vector2 oldSize = coll.size;
            coll.size = new Vector2(1, numTiles);
        }
        else
        {
            // left tile
            GenerateTileObject("LeftTile", new Vector3(0 - (float)(numTiles / 2) + offset, 0, 0), leftSprite, spriteLayerNumber);

            //middle tiles
            for (int i = 1; i < numTiles - 1; i++)
                GenerateTileObject($"CentreTile{i}", new Vector3(0f - (float)(numTiles / 2) + i + offset, 0, 0), centerSprite, spriteLayerNumber);

            // right tile
            GenerateTileObject("RightTile", new Vector3(0 + (float)(numTiles - 1) / 2, 0, 0), rightSprite, spriteLayerNumber);

            // adjust collider size
            Vector2 oldSize = coll.size;
            coll.size = new Vector2(numTiles, 1);
        }
    }

    private void OnDisable()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void GenerateTileObject(string name, Vector3 position, Sprite sprite, int spriteLayer)
    {
        GameObject tileObject = new GameObject(name);
        
        // add sprite renderer
        SpriteRenderer sr = tileObject.AddComponent<SpriteRenderer>();
        sr.sprite = sprite;
        sr.sortingOrder = spriteLayer;

        tileObject.transform.parent = gameObject.transform;
        tileObject.transform.localPosition = position;
    }
}
