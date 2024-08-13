using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private GameObject escPanel;
    [SerializeField] private GameObject inventoryPanel;
    private bool _isEsc;
    private bool _isInven;
    public bool _difUION;
    public bool _onUI => _isEsc||_isInven||_difUION;
    [SerializeField] private AudioMixer m_AudioMixer;
    [SerializeField] public Slider sfxSlider, bgmSlider;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isEsc&&!_onUI)
        {
            Time.timeScale = 0;
            GameManager.Instance.Player.PlayerInput.controls.Disable();
            _isEsc = true;
            escPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isEsc)
        {
            ESCOFF();
            escPanel.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && !_isInven&&!_onUI)
        { 
            _isInven = true;
            GameManager.Instance.Player.PlayerInput.controls.Disable();
            inventoryPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && _isInven)
        {
            _isInven = false;
            GameManager.Instance.Player.PlayerInput.controls.Enable();
            inventoryPanel.SetActive(false);
        }
        
    }

    private void Start()
    {
        sfxSlider.value = SaveManager.Instance.saveData.sfxVol;
        bgmSlider.value = SaveManager.Instance.saveData.bgmVol;
    }

    private void ESCOFF()
    {
        Time.timeScale = 1;
        GameManager.Instance.Player.PlayerInput.controls.Enable();
        _isEsc = false;
    }

    public void SetMusicVolume(float volume)
    {
        m_AudioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        m_AudioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public void ContinueBtn()
    {
        ESCOFF();
        escPanel.SetActive(false); 
    }

    public void LobbyBtn()
    {
        ESCOFF();
        SceneManager.LoadScene(SceneName.Base);
    }

    public void QuitBtn()
    {
        ESCOFF();
        SceneManager.LoadScene(SceneName.Start);
    }
}
