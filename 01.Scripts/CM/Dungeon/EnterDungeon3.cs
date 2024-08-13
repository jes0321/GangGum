using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterDungeon3 : MonoBehaviour
{
    private float _dis;
    [SerializeField] private float _min;
    public GameObject player;
    public GameObject f;
    public Image panel;

    private void Update()
    {
        _dis = Vector2.Distance(player.transform.position, transform.position);
        if (_dis <= _min)
        {
            if (SaveManager.Instance.saveData.canSpin)
            {
                f.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    StartCoroutine(ChangeScene());
                }
            }
        }
        else
        {
            f.SetActive(false);
        }
    }
    private IEnumerator ChangeScene()
    {
        GameManager.Instance.Player.PlayerInput.controls.Disable();
        panel.DOFade(1f, 2f);
        yield return new WaitForSeconds(2.5f);
        SaveManager.Instance.SavingData();
        GameManager.Instance.Player.PlayerInput.controls.Enable();
        SceneManager.LoadScene(SceneName.Dungeon3);
    }
}
