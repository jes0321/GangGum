using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    private void AnimationEndTrigger()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
