using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MageAreaDamage : MonoBehaviour
{
    
    public float time;
    private void Start()
    {
        DOVirtual.DelayedCall(time, () => { transform.DOScaleY(0, 0.5f).OnComplete(() => { gameObject.SetActive(false); }); }, false);
    }
}
