using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TilesController : MonoBehaviour
{
    [HideInInspector]
    public int Index;

    public bool RoundPosEnabled;

    public List<Sprite> TileSprites;
    public List<Sprite> PlantSprites;

    public GameObject TilePrefab;
    public GameObject PlantPrefab;

    void Update()
    {
        if (Application.isPlaying) return;

        if (RoundPosEnabled)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var e = transform.GetChild(i);
                RoundPosition(e);
            }
        }
    }

    public void ChangeSprite(int i, SpriteRenderer sr)
    {
        var index = TileSprites.FindIndex(s => s == sr.sprite);
        Index = index;
        Index = Mathf.Clamp(i + Index, 0, TileSprites.Count);
        sr.sprite = TileSprites[Index];
    }

    public void RoundPosition(Transform t)
    {
        t.position = new Vector3(Mathf.RoundToInt(t.position.x), Mathf.RoundToInt(t.position.y), Mathf.RoundToInt(t.position.z));
    }

    public void PlaceTilePrefab(Vector3 pos, int i)
    {
        GameObject g = Instantiate(TilePrefab, pos, Quaternion.identity);
        g.GetComponent<SpriteRenderer>().sprite = TileSprites[i];
        g.transform.parent = transform;
    }

    public void PlacePlantPrefab(Vector3 pos, int i)
    {
        GameObject g = Instantiate(PlantPrefab, pos, Quaternion.identity);
        g.GetComponent<SpriteRenderer>().sprite = PlantSprites[i];
        g.transform.parent = transform;
    }

    public void RotateTile(Transform t)
    {
        t.Rotate(new Vector3(0, 0, 180));
    }
}