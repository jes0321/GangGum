using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public GameObject BtnGameObject;
    public Image image;
    public Image panel;
    public TMP_Text txt;
    public string max = "�ִ� �����Դϴ�.";
    public void LevelUp()
    {
        if (ChangeWeapon.count >= 9)
        {
            StartCoroutine(FullLevel());
        }
        else
        {
            BtnGameObject.SetActive(false);
            image.gameObject.SetActive(false);
            panel.gameObject.SetActive(true);
        }
    }

    public void StayLevel()
    {
        BtnGameObject.SetActive(false);
        image.gameObject.SetActive(false);
        UIManager.Instance._difUION = false;
        GameManager.Instance.Player.PlayerInput.controls.Enable();
        NpcTalk.isTalk = false;
    }

    private IEnumerator FullLevel()
    {
        txt.text = null;
        txt.text = max;
        txt.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        txt.gameObject.SetActive(false);
    }
}
