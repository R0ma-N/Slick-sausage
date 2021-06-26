using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsCount;
    [SerializeField] GameObject dotsParent, dotPrefab;
    [SerializeField] [Range(0.01f, 0.3f)] float dotSpacing;
    [SerializeField] [Range(0f, 1f)] float dotMinScale;
    [SerializeField] [Range(0f, 1f)] float dotMaxScale;

    Transform[] dotsList;

    //dot position
    Vector2 pos;

    float timeStap;

    private void Start()
    {
        Hide();
        PrepareDots();
    }

    void PrepareDots()
    {
        dotsList = new Transform[dotsCount];
        dotPrefab.transform.localScale = Vector3.one * dotMaxScale;

        float scale = dotMaxScale;
        float scaleFactor = scale / dotsCount;

        for (int i = 0; i < dotsList.Length; i++)
        {
            dotsList[i] = Instantiate(dotPrefab, null).transform;
            dotsList[i].parent = dotsParent.transform;

            dotsList[i].localScale = Vector3.one * scale;
            if (scale > dotMinScale)
            {
                scale -= scaleFactor;
            }
        }
    }

    public void UpdateDots(Vector3 sausagePos, Vector2 forceApplied)
    {
        timeStap = dotSpacing;
        for (int i = 0; i < dotsCount; i++)
        {
            pos.x = (sausagePos.x + forceApplied.x * timeStap);
            pos.y = (sausagePos.y + forceApplied.y * timeStap) - (Physics2D.gravity.magnitude * timeStap * timeStap) / 2f;

            dotsList[i].position = pos;
            timeStap += dotSpacing;
        }
    }

    public void Show()
    {
        dotsParent.SetActive(true);    
    }

    public void Hide()
    {
        dotsParent.SetActive(false);
    }
}
