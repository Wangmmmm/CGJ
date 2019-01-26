using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shake : MonoBehaviour {

    private bool enable = true;

    public void OnShake()
    {
        if (enable)
        {
            transform.DOShakePosition(0.5f, 0.5f, 8).onComplete = delegate ()
              {
                  enable = true;
              };
            enable = false;
        }
    }

}
