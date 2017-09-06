using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TilesController : MonoBehaviour
{
    public bool RoundPosEnabled;
    public bool RandomizeTilesEnabled;

    public List<Sprite> TileSprites;
    public List<Sprite> PlantSprites;

    public GameObject TilePrefab;
    public GameObject CoinPrefab;
    public GameObject PlantPrefab;

    public GameObject CoinParent;

    void Update()
    {
        if (Application.isPlaying) return;

        if (RoundPosEnabled)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform e = transform.GetChild(i);
                RoundPosition(e);
            }
        }

        if (RandomizeTilesEnabled)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform e = transform.GetChild(i);
                e.GetComponent<SpriteRenderer>().sprite = TileSprites[Random.Range(0, TileSprites.Count - 1)];
            }
            RandomizeTilesEnabled = false;
        }
    }

    public void ChangeSprite(int i, SpriteRenderer sr)
    {
        int index = TileSprites.FindIndex(s => s == sr.sprite);
        index = Mathf.Clamp(i + index, 0, TileSprites.Count - 1);
        sr.sprite = TileSprites[index];
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

    public void PlaceCoinPrefab(Vector3 pos)
    {
        GameObject g = Instantiate(CoinPrefab, pos, Quaternion.identity);
        g.transform.parent = CoinParent.transform;
        RoundPosition(g.transform);
    }

    public void RotateTile(Transform t)
    {
        t.Rotate(new Vector3(0, 0, 180));
    }
}