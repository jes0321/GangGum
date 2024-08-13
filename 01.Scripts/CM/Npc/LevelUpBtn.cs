using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelUpBtn : MonoBehaviour
{
    public UnityEvent levelUp;
    public List<int> LevelUpCoin = new List<int>();
    public List<int> percentage = new List<int>();
    public List<string> percentageText = new List<string>();
    public Image panel;
    public TMP_Text text;
    public TMP_Text text2;
    public TMP_Text text4;
    public TMP_Text text5;
    public string money = "������ �����մϴ�";
    public string fail = "��ȭ ����";
    private bool check = false;
    [SerializeField] private SkillUI smashUI, spinUI;
    public void LevelUpCheck()
    {
        if ((ChangeWeapon.count != 2 && ChangeWeapon.count != 5 && ChangeWeapon.count != 8 && ChangeWeapon.count != 9) && ChangeWeapon.count < 10 && check == false)
        {

            if (GameManager.Instance.coin.count >= LevelUpCoin[ChangeWeapon.count])
            {
                int rand = Random.Range(0, 100);
                if (rand <= percentage[ChangeWeapon.count])
                {
                    StartCoroutine(SuccessLevel());
                    GameManager.Instance.coin.count -= LevelUpCoin[ChangeWeapon.count];
                    check = true;
                    ChangeWeapon.count++;
                    levelUp?.Invoke();
                }
                else
                {
                    GameManager.Instance.coin.count -= LevelUpCoin[ChangeWeapon.count];
                    StartCoroutine(FailLevel());
                }
                SaveManager.Instance.SavingData();
            }
            else
            {
                StartCoroutine(MoneyLevel());
            }
        }
    }
    private IEnumerator FailLevel()
    {
        text.text = null;
        text.text = fail;
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        text.gameObject.SetActive(false);
    }
    private IEnumerator MoneyLevel()
    {
        text.text = null;
        text.text = money;
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        text.gameObject.SetActive(false);
    }

    private IEnumerator SuccessLevel()
    {
        text2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        text2.gameObject.SetActive(false);
    }



    public List<int> print1 = new List<int>();
    public List<int> print2 = new List<int>();
    public List<int> print3 = new List<int>();
    public TMP_Text text3;
    [SerializeField] private string nonePrint = "���赵�� �����մϴ�";
    [SerializeField] private string evolution = "��ȭ ����!";

    public void EvolutionCheck()
    {
        if ((ChangeWeapon.count == 2 || ChangeWeapon.count == 5 || ChangeWeapon.count == 8 || ChangeWeapon.count == 9) && ChangeWeapon.count < 10 && check == false)
        {

            if (GameManager.Instance.bluePrint1.count >= print1[ChangeWeapon.count] && GameManager.Instance.bluePrint2.count >= print2[ChangeWeapon.count])
            {
                StartCoroutine(SuccessEvolution());
                GameManager.Instance.bluePrint1.count -= print1[ChangeWeapon.count];
                GameManager.Instance.bluePrint2.count -= print2[ChangeWeapon.count];
                GameManager.Instance.bluePrint3.count -= print3[ChangeWeapon.count];  
                PlayerManager.Instance.evoCnt++;
                if (PlayerManager.Instance.evoCnt == 1)
                {
                    SkillManager.Instance.GetSkill<SmashSkill>().skillEnabled = true;
                    PlayerManager.Instance.AnimatorTrade();
                    smashUI.LockOnOff();
                }
                else if (PlayerManager.Instance.evoCnt == 2)
                {
                    SkillManager.Instance.GetSkill<SpinSkill>().skillEnabled = true;
                    PlayerManager.Instance.AnimatorTrade();
                    spinUI.LockOnOff();
                }
                check = true;
                ChangeWeapon.count++;
                levelUp?.Invoke();
                SaveManager.Instance.SavingData();
            }
            else
            {
                StartCoroutine(PrintWant());
            }
        }
    }
    private IEnumerator PrintWant()
    {
        text3.text = null;
        text3.text = nonePrint;
        text3.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        text3.gameObject.SetActive(false);
    }

    private IEnumerator SuccessEvolution()
    {
        text.text = null;
        text.text = evolution;
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        text.gameObject.SetActive(false);
    }

    public void Percentage()
    {
        text5.text = null;
        text5.text = percentageText[ChangeWeapon.count];
    }

    private void Start()
    {
        text5.text= null;
        text5.text = text.text = percentageText[ChangeWeapon.count];
    }

    private void Update()
    {
        Debug.Log(ChangeWeapon.count);
    }

    public void CheckChange()
    {
        check = false;
    }
}
