using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TilesController : MonoBehaviour
{
    public bool RoundPosEnabled;
    [HideInInspector]
    public int Index;

    public List<Sprite> TileSprites;
    public GameObject TilePrefab;

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

            //RoundPosEnabled = false;
        }
    }

    public void ChangeSprite(int i, SpriteRenderer sr)
    {
        Index = Mathf.Clamp(i + Index, 0, TileSprites.Count);
        sr.sprite = TileSprites[Index];
    }

    public void RoundPosition(Transform t)
    {
        t.position = new Vector3(Mathf.RoundToInt(t.position.x), Mathf.RoundToInt(t.position.y), Mathf.RoundToInt(t.position.z));
    }

    public void PlacePrefab(Vector3 pos, int i)
    {
        GameObject g = Instantiate(TilePrefab, pos, Quaternion.identity);
        g.GetComponent<SpriteRenderer>().sprite = TileSprites[i];
        g.transform.parent = transform;
    }

    public void RotateTile(Transform t)
    {
        t.Rotate(new Vector3(0, 0, 180));
    }
}