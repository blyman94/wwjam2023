using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLoader : MonoBehaviour
{
    public bool BoardLoaded = true;
    [SerializeField] private GameObject boardSpritePrefab;
    [SerializeField] private Sprite[] pureSprites;
    [SerializeField] private Sprite[] corruptSprites;
    [SerializeField] private Vector3 startPos;
    [SerializeField] int squareSize = 16;
    [SerializeField] float horizontalSpacing;
    [SerializeField] float verticalSpacing;

    private void Start()
    {
        if (BoardLoaded)
        {
            return;
        }
        
        for (int i = 0; i < squareSize; i++)
        {
            for (int j = 0; j < squareSize; j++)
            {
                Vector3 position = startPos + new Vector3(j * horizontalSpacing, -i * verticalSpacing, 0);
                GameObject boardObject = Instantiate(boardSpritePrefab, position, Quaternion.identity, transform);
                BoardSprite boardSprite = boardObject.GetComponent<BoardSprite>();
                boardSprite.PureSpriteRenderer.sprite = pureSprites[i * squareSize + j];
                boardSprite.CorruptSpriteRenderer.sprite = corruptSprites[i * squareSize + j];
                boardSprite.SwitchToCorrupt();
            }
        }
    }
}
