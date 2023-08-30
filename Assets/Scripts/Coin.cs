using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Coin : MonoBehaviour
{
    GameManager gm;
    public float range;
    Transform target;
    public bool taken;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if(gm.activeCharacter != null)
        {
            target = gm.activeCharacter.transform;
            if (Vector3.Distance(target.position, transform.position) < range && !taken)
            {
                taken = true;
                transform.DOMove(target.position, 0.1f).OnComplete(() => {
                    gm.ChangeMoney(100);
                    gameObject.SetActive(false);
                });
            }
        }
        
    }
}
