using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public bool PlayerIsNearTree { get; set; } = false;
    public BoolVariable _playerHasAcorn;
    public GameObject promptIcon;
    public SpriteRenderer treeRenderer;
    public GameEvent acornAcceptedEvent;
    public GameEvent damageTakenEvent;

    public Sprite[] UndamagedSprites;
    public Sprite[] SlightDamagedSprites;
    public Sprite[] VeryDamagedSprites;
    public Sprite[] DeadSprites;

    List<Sprite[]> TreeMatrix;

    private int numAcorns = 0;
    private int numHealth = 3;

    private void Start()
    {
        TreeMatrix = new List<Sprite[]>();
        TreeMatrix.Add(DeadSprites);
        TreeMatrix.Add(VeryDamagedSprites);
        TreeMatrix.Add(SlightDamagedSprites);
        TreeMatrix.Add(UndamagedSprites);
    }

    public void OnEnterResponse()
    {
        PlayerIsNearTree = true;
        if (_playerHasAcorn.Value)
        {
            promptIcon.gameObject.SetActive(true);
        }
    }

    public void OnExitResponse()
    {
        PlayerIsNearTree = false;
        promptIcon.gameObject.SetActive(false);
    }

    public void OnPlayerInteractResponse()
    {
        if (!PlayerIsNearTree)
        {
            return;
        }

        if (_playerHasAcorn)
        {
            _playerHasAcorn.Value = false;
            promptIcon.gameObject.SetActive(false);
            AcceptAcorn();
        }

        //_playerHasAcorn.Value = true;
        //Destroy(gameObject);
    }

    public void TakeDamage()
    {
        if (numHealth - 1 >= 0)
        {
            numHealth--;
            treeRenderer.sprite = TreeMatrix[numHealth][numAcorns];
            damageTakenEvent.Raise();
            if (numHealth == 0)
            {
                Debug.Log("Lose!");
            }
        }
    }

    public void AcceptAcorn()
    {
        if (numAcorns + 1 <= 3)
        {
            numAcorns++;
            treeRenderer.sprite = TreeMatrix[numHealth][numAcorns];
            acornAcceptedEvent.Raise();
            if (numAcorns == 3)
            {
                Debug.Log("Win!");
            }
        }
    }
}
