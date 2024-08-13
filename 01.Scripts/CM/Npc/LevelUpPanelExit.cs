using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanelExit : MonoBehaviour
{
    public Image panel;
    public void ExitPanel()
    {
        NpcTalk.isTalk = false;
        UIManager.Instance._difUION = false;
        GameManager.Instance.Player.PlayerInput.controls.Enable();
        panel.gameObject.SetActive(false);
    }
}
