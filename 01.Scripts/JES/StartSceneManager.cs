using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject continueBtnLock;

    [SerializeField] private Button continueBtn;
    private void Start()
    {
        continueBtnLock.SetActive(SaveManager.Instance.saveData.isFirst);
        continueBtn.interactable = !SaveManager.Instance.saveData.isFirst;
    }

    private void Update()
    {
        Camera.main.transform.position += Vector3.right*Time.deltaTime;
    }

    public void NewStartBtn()
    {
        SaveManager.Instance.saveData = new SaveData();
        SaveManager.Instance.saveData.isFirst = false;
        SaveManager.Instance.SaveDataToJson();
        ContinueBtn();
    }

    public void ContinueBtn()
    {
        SceneManager.LoadScene(SceneName.Base);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
