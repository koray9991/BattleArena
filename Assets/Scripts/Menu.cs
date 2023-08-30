using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Menu : MonoBehaviour
{
    CharacterUpgrades cu;
    public Transform slotMiddleTransform, slotLeftTransform, slotRightTransform;
    public Transform slotMiddle, slotLeft, slotRight;
    public Transform tank,tankDefaultPos;
    public Transform archer, archerDefaultPos;
    public Transform mage, mageDefaultPos;
    public Transform ninja, ninjaDefaultPos;
    public Transform wizard, wizardDefaultPos;
    public Transform bomber, bomberDefaultPos;
    public Transform hammer, hammerDefaultPos;

    public List<GameObject> buttons;

    public GameObject tankUseButton, tankRemoveButton;
    public GameObject archerUseButton, archerRemoveButton;
    public GameObject mageUseButton, mageRemoveButton;
    public GameObject ninjaUseButton, ninjaRemoveButton;
    public GameObject wizardUseButton, wizardRemoveButton;
    public GameObject bomberUseButton, bomberRemoveButton;
    public GameObject hammerUseButton, hammerRemoveButton;

    int slotNum1, slotNum2, slotNum3;

    public Button battleButton, upgradeButton, chestButton;
    public GameObject battlePanel, upgradePanel, chestPanel;

    public List<Sprite> playButtonImages;
    public Image playMimage, playLimage, playRimage;

    public Button playButton;

    public GameObject tankInfoPanel,archerInfoPanel,mageInfoPanel,ninjaInfoPanel,wizardInfoPanel,bomberInfoPanel,hammerInfoPanel;

    public int warriorBought;
    public GameObject warriorGray;
    public GameObject warriorBuyButton;
    public float warriorPrice;
    public TextMeshProUGUI warriorPriceText;

    public int archerBought;
    public GameObject archerGray;
    public GameObject archerBuyButton;
    public float archerPrice;
    public TextMeshProUGUI archerPriceText;

    public int mageBought;
    public GameObject mageGray;
    public GameObject mageBuyButton;
    public float magePrice;
    public TextMeshProUGUI magePriceText;

    public int ninjaBought;
    public GameObject ninjaGray;
    public GameObject ninjaBuyButton;
    public float ninjaPrice;
    public TextMeshProUGUI ninjaPriceText;

    public int wizardBought;
    public GameObject wizardGray;
    public GameObject wizardBuyButton;
    public float wizardPrice;
    public TextMeshProUGUI wizardPriceText;

    public int bomberBought;
    public GameObject bomberGray;
    public GameObject bomberBuyButton;
    public float bomberPrice;
    public TextMeshProUGUI bomberPriceText;

    public int hammerBought;
    public GameObject hammerGray;
    public GameObject hammerBuyButton;
    public float hammerPrice;
    public TextMeshProUGUI hammerPriceText;

    private void Start()
    {
        cu = GetComponent<CharacterUpgrades>();
        slotNum1 = PlayerPrefs.GetInt("slotNum1");
        slotNum2 = PlayerPrefs.GetInt("slotNum2");
        slotNum3 = PlayerPrefs.GetInt("slotNum3");

        switch (slotNum1)
        {
            case 1:
                slotMiddle = tank;
                tank.transform.position = slotMiddleTransform.position;
                tankUseButton.SetActive(false);
                tankRemoveButton.SetActive(true);
                playMimage.sprite = playButtonImages[1];
                DisableUseButtons();
                break;
            case 2:
                slotMiddle = archer;
                archer.transform.position = slotMiddleTransform.position;
                archerUseButton.SetActive(false);
                archerRemoveButton.SetActive(true);
                playMimage.sprite = playButtonImages[2];
                DisableUseButtons();
                break;
            case 3:
                slotMiddle = mage;
                mage.transform.position = slotMiddleTransform.position;
                mageUseButton.SetActive(false);
                mageRemoveButton.SetActive(true);
                playMimage.sprite = playButtonImages[3];
                DisableUseButtons();
                break;
            case 4:
                slotMiddle = ninja;
                ninja.transform.position = slotMiddleTransform.position;
                ninjaUseButton.SetActive(false);
                ninjaRemoveButton.SetActive(true);
                playMimage.sprite = playButtonImages[4];
                DisableUseButtons();
                break;
            case 5:
                slotMiddle = wizard;
                wizard.transform.position = slotMiddleTransform.position;
                wizardUseButton.SetActive(false);
                wizardRemoveButton.SetActive(true);
                playMimage.sprite = playButtonImages[5];
                DisableUseButtons();
                break;
            case 6:
                slotMiddle = bomber;
                bomber.transform.position = slotMiddleTransform.position;
                bomberUseButton.SetActive(false);
                bomberRemoveButton.SetActive(true);
                playMimage.sprite = playButtonImages[6];
                DisableUseButtons();
                break;
            case 7:
                slotMiddle = hammer;
                hammer.transform.position = slotMiddleTransform.position;
                hammerUseButton.SetActive(false);
                hammerRemoveButton.SetActive(true);
                playMimage.sprite = playButtonImages[7];
                DisableUseButtons();
                break;
        }
        switch (slotNum2)
        {
            case 1:
                slotLeft = tank;
                tank.transform.position = slotLeftTransform.position;
                tankUseButton.SetActive(false);
                tankRemoveButton.SetActive(true);
                DisableUseButtons();
                playLimage.sprite = playButtonImages[1];
                break;
            case 2:
                slotLeft = archer;
                archer.transform.position = slotLeftTransform.position;
                archerUseButton.SetActive(false);
                archerRemoveButton.SetActive(true);
                playLimage.sprite = playButtonImages[2];
                DisableUseButtons();
                break;
            case 3:
                slotLeft = mage;
                mage.transform.position = slotLeftTransform.position;
                mageUseButton.SetActive(false);
                mageRemoveButton.SetActive(true);
                playLimage.sprite = playButtonImages[3];
                DisableUseButtons();
                break;
            case 4:
                slotLeft = ninja;
                ninja.transform.position = slotLeftTransform.position;
                ninjaUseButton.SetActive(false);
                ninjaRemoveButton.SetActive(true);
                playLimage.sprite = playButtonImages[4];
                DisableUseButtons();
                break;
            case 5:
                slotLeft = wizard;
                wizard.transform.position = slotLeftTransform.position;
                wizardUseButton.SetActive(false);
                wizardRemoveButton.SetActive(true);
                playLimage.sprite = playButtonImages[5];
                DisableUseButtons();
                break;
            case 6:
                slotLeft = bomber;
                bomber.transform.position = slotLeftTransform.position;
                bomberUseButton.SetActive(false);
                bomberRemoveButton.SetActive(true);
                playLimage.sprite = playButtonImages[6];
                DisableUseButtons();
                break;
            case 7:
                slotLeft = hammer;
                hammer.transform.position = slotLeftTransform.position;
                hammerUseButton.SetActive(false);
                hammerRemoveButton.SetActive(true);
                playLimage.sprite = playButtonImages[7];
                DisableUseButtons();
                break;
        }
        switch (slotNum3)
        {
            case 1:
                slotRight = tank;
                tank.transform.position = slotRightTransform.position;
                tankUseButton.SetActive(false);
                tankRemoveButton.SetActive(true);
                playRimage.sprite = playButtonImages[1];
                DisableUseButtons();
                break;
            case 2:
                slotRight = archer;
                archer.transform.position = slotRightTransform.position;
                archerUseButton.SetActive(false);
                archerRemoveButton.SetActive(true);
                playRimage.sprite = playButtonImages[2];
                DisableUseButtons();
                break;
            case 3:
                slotRight = mage;
                mage.transform.position = slotRightTransform.position;
                mageUseButton.SetActive(false);
                mageRemoveButton.SetActive(true);
                playRimage.sprite = playButtonImages[3];
                DisableUseButtons();
                break;
            case 4:
                slotRight = ninja;
                ninja.transform.position = slotRightTransform.position;
                ninjaUseButton.SetActive(false);
                ninjaRemoveButton.SetActive(true);
                playRimage.sprite = playButtonImages[4];
                DisableUseButtons();
                break;
            case 5:
                slotRight = wizard;
                wizard.transform.position = slotRightTransform.position;
                wizardUseButton.SetActive(false);
                wizardRemoveButton.SetActive(true);
                playRimage.sprite = playButtonImages[5];
                DisableUseButtons();
                break;
            case 6:
                slotRight = bomber;
                bomber.transform.position = slotRightTransform.position;
                bomberUseButton.SetActive(false);
                bomberRemoveButton.SetActive(true);
                playRimage.sprite = playButtonImages[6];
                DisableUseButtons();
                break;
            case 7:
                slotRight = hammer;
                hammer.transform.position = slotRightTransform.position;
                hammerUseButton.SetActive(false);
                hammerRemoveButton.SetActive(true);
                playRimage.sprite = playButtonImages[7];
                DisableUseButtons();
                break;
        }

        DisableButtons();

        SetBattlePanel();
        PlayButtonCheck();

        CloseTankInfoPanel(); CloseArcherInfoPanel(); CloseMageInfoPanel(); CloseNinjaInfoPanel(); CloseWizardInfoPanel(); CloseBomberInfoPanel(); CloseHammerInfoPanel();

        WarriorCheck(); ArcherCheck(); MageCheck(); NinjaCheck(); WizardCheck(); BomberCheck(); HammerCheck();
    }
    public void SetBattlePanel()
    {
        battleButton.interactable = false;
        upgradeButton.interactable = true;
        chestButton.interactable = true;
        battlePanel.SetActive(true);
        upgradePanel.SetActive(false);
        chestPanel.SetActive(false);
    }
    public void SetUpgradePanel()
    {
        battleButton.interactable = true;
        upgradeButton.interactable = false;
        chestButton.interactable = true;
        battlePanel.SetActive(false);
        upgradePanel.SetActive(true);
        chestPanel.SetActive(false);
    }
    public void SetChestPanel()
    {
        battleButton.interactable = true;
        upgradeButton.interactable = true;
        chestButton.interactable = false;
        battlePanel.SetActive(false);
        upgradePanel.SetActive(false);
        chestPanel.SetActive(true);
    }
    public void UseButton(int index)
    {
        if (index == 1)
        {
            if (slotMiddle == null)
            {
                slotMiddle = tank;
                tank.transform.position = slotMiddleTransform.position;
                tankUseButton.SetActive(false);
                tankRemoveButton.SetActive(true);
                playMimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum1 = 1;
                PlayerPrefs.SetInt("slotNum1", slotNum1);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
            if (slotLeft == null)
            {
                slotLeft = tank;
                tank.transform.position = slotLeftTransform.position;
                tankUseButton.SetActive(false);
                tankRemoveButton.SetActive(true);
                playLimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum2 = 1;
                PlayerPrefs.SetInt("slotNum2", slotNum2);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
            if (slotRight == null)
            {
                slotRight = tank;
                tank.transform.position = slotRightTransform.position;
                tankUseButton.SetActive(false);
                tankRemoveButton.SetActive(true);
                playRimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum3 = 1;
                PlayerPrefs.SetInt("slotNum3", slotNum3);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
        }
        if (index == 2)
        {
            if (slotMiddle == null)
            {
                slotMiddle = archer;
                archer.transform.position = slotMiddleTransform.position;
                archerUseButton.SetActive(false);
                archerRemoveButton.SetActive(true);
                playMimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum1 = 2;
                PlayerPrefs.SetInt("slotNum1", slotNum1);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
            if (slotLeft == null)
            {
                slotLeft = archer;
                archer.transform.position = slotLeftTransform.position;
                archerUseButton.SetActive(false);
                archerRemoveButton.SetActive(true);
                playLimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum2 = 2;
                PlayerPrefs.SetInt("slotNum2", slotNum2);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
            if (slotRight == null)
            {
                slotRight = archer;
                archer.transform.position = slotRightTransform.position;
                archerUseButton.SetActive(false);
                archerRemoveButton.SetActive(true);
                playRimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum3 = 2;
                PlayerPrefs.SetInt("slotNum3", slotNum3);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
        }
        if (index == 3)
        {
            if (slotMiddle == null)
            {
                slotMiddle = mage;
                mage.transform.position = slotMiddleTransform.position;
                mageUseButton.SetActive(false);
                mageRemoveButton.SetActive(true);
                playMimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum1 = 3;
                PlayerPrefs.SetInt("slotNum1", slotNum1);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
            if (slotLeft == null)
            {
                slotLeft = mage;
                mage.transform.position = slotLeftTransform.position;
                mageUseButton.SetActive(false);
                mageRemoveButton.SetActive(true);
                playLimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum2 = 3;
                PlayerPrefs.SetInt("slotNum2", slotNum2);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
            if (slotRight == null)
            {
                slotRight = mage;
                mage.transform.position = slotRightTransform.position;
                mageUseButton.SetActive(false);
                mageRemoveButton.SetActive(true);
                playRimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum3 = 3;
                PlayerPrefs.SetInt("slotNum3", slotNum3);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
        }
        if (index == 4)
        {
            if (slotMiddle == null)
            {
                slotMiddle = ninja;
                ninja.transform.position = slotMiddleTransform.position;
                ninjaUseButton.SetActive(false);
                ninjaRemoveButton.SetActive(true);
                playMimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum1 = 4;
                PlayerPrefs.SetInt("slotNum1", slotNum1);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
            if (slotLeft == null)
            {
                slotLeft = ninja;
                ninja.transform.position = slotLeftTransform.position;
                ninjaUseButton.SetActive(false);
                ninjaRemoveButton.SetActive(true);
                playLimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum2 = 4;
                PlayerPrefs.SetInt("slotNum2", slotNum2);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
            if (slotRight == null)
            {
                slotRight = ninja;
                ninja.transform.position = slotRightTransform.position;
                ninjaUseButton.SetActive(false);
                ninjaRemoveButton.SetActive(true);
                playRimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum3 = 4;
                PlayerPrefs.SetInt("slotNum3", slotNum3);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
        }
        if (index == 5)
        {
            if (slotMiddle == null)
            {
                slotMiddle = wizard;
                wizard.transform.position = slotMiddleTransform.position;
                wizardUseButton.SetActive(false);
                wizardRemoveButton.SetActive(true);
                playMimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum1 = 5;
                PlayerPrefs.SetInt("slotNum1", slotNum1);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
            if (slotLeft == null)
            {
                slotLeft = wizard;
                wizard.transform.position = slotLeftTransform.position;
                wizardUseButton.SetActive(false);
                wizardRemoveButton.SetActive(true);
                playLimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum2 = 5;
                PlayerPrefs.SetInt("slotNum2", slotNum2);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
            if (slotRight == null)
            {
                slotRight = wizard;
                wizard.transform.position = slotRightTransform.position;
                wizardUseButton.SetActive(false);
                wizardRemoveButton.SetActive(true);
                playRimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum3 = 5;
                PlayerPrefs.SetInt("slotNum3", slotNum3);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
        }
        if (index == 6)
        {
            if (slotMiddle == null)
            {
                slotMiddle = bomber;
                bomber.transform.position = slotMiddleTransform.position;
                bomberUseButton.SetActive(false);
                bomberRemoveButton.SetActive(true);
                playMimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum1 = 6;
                PlayerPrefs.SetInt("slotNum1", slotNum1);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
            if (slotLeft == null)
            {
                slotLeft = bomber;
                bomber.transform.position = slotLeftTransform.position;
                bomberUseButton.SetActive(false);
                bomberRemoveButton.SetActive(true);
                playLimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum2 = 6;
                PlayerPrefs.SetInt("slotNum2", slotNum2);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
            if (slotRight == null)
            {
                slotRight = bomber;
                bomber.transform.position = slotRightTransform.position;
                bomberUseButton.SetActive(false);
                bomberRemoveButton.SetActive(true);
                playRimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum3 = 6;
                PlayerPrefs.SetInt("slotNum3", slotNum3);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
        }
        if (index == 7)
        {
            if (slotMiddle == null)
            {
                slotMiddle = hammer;
                hammer.transform.position = slotMiddleTransform.position;
                hammerUseButton.SetActive(false);
                hammerRemoveButton.SetActive(true);
                playMimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum1 = 7;
                PlayerPrefs.SetInt("slotNum1", slotNum1);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
            if (slotLeft == null)
            {
                slotLeft = hammer;
                hammer.transform.position = slotLeftTransform.position;
                hammerUseButton.SetActive(false);
                hammerRemoveButton.SetActive(true);
                playLimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum2 = 7;
                PlayerPrefs.SetInt("slotNum2", slotNum2);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
            if (slotRight == null)
            {
                slotRight = hammer;
                hammer.transform.position = slotRightTransform.position;
                hammerUseButton.SetActive(false);
                hammerRemoveButton.SetActive(true);
                playRimage.sprite = playButtonImages[index];
                DisableUseButtons();
                slotNum3 = 7;
                PlayerPrefs.SetInt("slotNum3", slotNum3);
                DisableButtons();
                PlayButtonCheck();

                return;
            }
        }
    }
    public void RemoveButton(int index)
    {
        if (index == 1)
        {
            if (slotMiddle == tank)
            {
                slotMiddle = null;
                tank.transform.position = tankDefaultPos.position;
                tankUseButton.SetActive(true);
                tankRemoveButton.SetActive(false);
                playMimage.sprite = playButtonImages[0];
                slotNum1 = 0;
                PlayerPrefs.SetInt("slotNum1", slotNum1);
            }
            if (slotLeft == tank)
            {
                slotLeft = null;
                tank.transform.position = tankDefaultPos.position;
                tankUseButton.SetActive(true);
                tankRemoveButton.SetActive(false);
                playLimage.sprite = playButtonImages[0];
                slotNum2 = 0;
                PlayerPrefs.SetInt("slotNum2", slotNum2);
            }
            if (slotRight == tank)
            {
                slotRight = null;
                tank.transform.position = tankDefaultPos.position;
                tankUseButton.SetActive(true);
                tankRemoveButton.SetActive(false);
                playRimage.sprite = playButtonImages[0];
                slotNum3 = 0;
                PlayerPrefs.SetInt("slotNum3", slotNum3);
            }
        }
        if (index == 2)
        {
            if (slotMiddle == archer)
            {
                slotMiddle = null;
                archer.transform.position = archerDefaultPos.position;
                archerUseButton.SetActive(true);
                archerRemoveButton.SetActive(false);
                playMimage.sprite = playButtonImages[0];
                slotNum1 = 0;
                PlayerPrefs.SetInt("slotNum1", slotNum1);
            }
            if (slotLeft == archer)
            {
                slotLeft = null;
                archer.transform.position = archerDefaultPos.position;
                archerUseButton.SetActive(true);
                archerRemoveButton.SetActive(false);
                playLimage.sprite = playButtonImages[0];
                slotNum2 = 0;
                PlayerPrefs.SetInt("slotNum2", slotNum2);
            }
            if (slotRight == archer)
            {
                slotRight = null;
                archer.transform.position = archerDefaultPos.position;
                archerUseButton.SetActive(true);
                archerRemoveButton.SetActive(false);
                playRimage.sprite = playButtonImages[0];
                slotNum3 = 0;
                PlayerPrefs.SetInt("slotNum3", slotNum3);
            }
        }
        if (index == 3)
        {
            if (slotMiddle == mage)
            {
                slotMiddle = null;
                mage.transform.position = mageDefaultPos.position;
                mageUseButton.SetActive(true);
                mageRemoveButton.SetActive(false);
                playMimage.sprite = playButtonImages[0];
                slotNum1 = 0;
                PlayerPrefs.SetInt("slotNum1", slotNum1);
            }
            if (slotLeft == mage)
            {
                slotLeft = null;
                mage.transform.position = mageDefaultPos.position;
                mageUseButton.SetActive(true);
                mageRemoveButton.SetActive(false);
                playLimage.sprite = playButtonImages[0];
                slotNum2 = 0;
                PlayerPrefs.SetInt("slotNum2", slotNum2);
            }
            if (slotRight == mage)
            {
                slotRight = null;
                mage.transform.position = mageDefaultPos.position;
                mageUseButton.SetActive(true);
                mageRemoveButton.SetActive(false);
                playRimage.sprite = playButtonImages[0];
                slotNum3 = 0;
                PlayerPrefs.SetInt("slotNum3", slotNum3);
            }
        }
        if (index == 4)
        {
            if (slotMiddle == ninja)
            {
                slotMiddle = null;
                ninja.transform.position = ninjaDefaultPos.position;
                ninjaUseButton.SetActive(true);
                ninjaRemoveButton.SetActive(false);
                playMimage.sprite = playButtonImages[0];
                slotNum1 = 0;
                PlayerPrefs.SetInt("slotNum1", slotNum1);
            }
            if (slotLeft == ninja)
            {
                slotLeft = null;
                ninja.transform.position = ninjaDefaultPos.position;
                ninjaUseButton.SetActive(true);
                ninjaRemoveButton.SetActive(false);
                playLimage.sprite = playButtonImages[0];
                slotNum2 = 0;
                PlayerPrefs.SetInt("slotNum2", slotNum2);
            }
            if (slotRight == ninja)
            {
                slotRight = null;
                ninja.transform.position = ninjaDefaultPos.position;
                ninjaUseButton.SetActive(true);
                ninjaRemoveButton.SetActive(false);
                playRimage.sprite = playButtonImages[0];
                slotNum3 = 0;
                PlayerPrefs.SetInt("slotNum3", slotNum3);
            }
        }
        if (index == 5)
        {
            if (slotMiddle == wizard)
            {
                slotMiddle = null;
                wizard.transform.position = wizardDefaultPos.position;
                wizardUseButton.SetActive(true);
                wizardRemoveButton.SetActive(false);
                playMimage.sprite = playButtonImages[0];
                slotNum1 = 0;
                PlayerPrefs.SetInt("slotNum1", slotNum1);
            }
            if (slotLeft == wizard)
            {
                slotLeft = null;
                wizard.transform.position = wizardDefaultPos.position;
                wizardUseButton.SetActive(true);
                wizardRemoveButton.SetActive(false);
                playLimage.sprite = playButtonImages[0];
                slotNum2 = 0;
                PlayerPrefs.SetInt("slotNum2", slotNum2);
            }
            if (slotRight == wizard)
            {
                slotRight = null;
                wizard.transform.position = wizardDefaultPos.position;
                wizardUseButton.SetActive(true);
                wizardRemoveButton.SetActive(false);
                playRimage.sprite = playButtonImages[0];
                slotNum3 = 0;
                PlayerPrefs.SetInt("slotNum3", slotNum3);
            }
        }
        if (index == 6)
        {
            if (slotMiddle == bomber)
            {
                slotMiddle = null;
                bomber.transform.position = bomberDefaultPos.position;
                bomberUseButton.SetActive(true);
                bomberRemoveButton.SetActive(false);
                playMimage.sprite = playButtonImages[0];
                slotNum1 = 0;
                PlayerPrefs.SetInt("slotNum1", slotNum1);
            }
            if (slotLeft == bomber)
            {
                slotLeft = null;
                bomber.transform.position = bomberDefaultPos.position;
                bomberUseButton.SetActive(true);
                bomberRemoveButton.SetActive(false);
                playLimage.sprite = playButtonImages[0];
                slotNum2 = 0;
                PlayerPrefs.SetInt("slotNum2", slotNum2);
            }
            if (slotRight == bomber)
            {
                slotRight = null;
                bomber.transform.position = bomberDefaultPos.position;
                bomberUseButton.SetActive(true);
                bomberRemoveButton.SetActive(false);
                playRimage.sprite = playButtonImages[0];
                slotNum3 = 0;
                PlayerPrefs.SetInt("slotNum3", slotNum3);
            }
        }
        if (index == 7)
        {
            if (slotMiddle == hammer)
            {
                slotMiddle = null;
                hammer.transform.position = hammerDefaultPos.position;
                hammerUseButton.SetActive(true);
                hammerRemoveButton.SetActive(false);
                playMimage.sprite = playButtonImages[0];
                slotNum1 = 0;
                PlayerPrefs.SetInt("slotNum1", slotNum1);
            }
            if (slotLeft == hammer)
            {
                slotLeft = null;
                hammer.transform.position = hammerDefaultPos.position;
                hammerUseButton.SetActive(true);
                hammerRemoveButton.SetActive(false);
                playLimage.sprite = playButtonImages[0];
                slotNum2 = 0;
                PlayerPrefs.SetInt("slotNum2", slotNum2);
            }
            if (slotRight == hammer)
            {
                slotRight = null;
                hammer.transform.position = hammerDefaultPos.position;
                hammerUseButton.SetActive(true);
                hammerRemoveButton.SetActive(false);
                playRimage.sprite = playButtonImages[0];
                slotNum3 = 0;
                PlayerPrefs.SetInt("slotNum3", slotNum3);
            }
        }
        EnableUseButtons();
        DisableButtons();
        PlayButtonCheck();
    }
    public void DisableUseButtons()
    {
        if (slotMiddle != null && slotLeft != null && slotRight != null)
        {
            tankUseButton.SetActive(false);
            ninjaUseButton.SetActive(false);
            mageUseButton.SetActive(false);
            archerUseButton.SetActive(false);
            wizardUseButton.SetActive(false);
        }
    }
    public void EnableUseButtons()
    {
        if (warriorBought == 1)
        {
            tankUseButton.SetActive(true);
        }
        if (archerBought == 1)
        {
            archerUseButton.SetActive(true);
        }
        if (mageBought == 1)
        {
            mageUseButton.SetActive(true);
        }
        if (ninjaBought == 1)
        {
            ninjaUseButton.SetActive(true);
        }
        if (wizardBought == 1)
        {
            wizardUseButton.SetActive(true);
        }
        if (bomberBought == 1)
        {
            bomberUseButton.SetActive(true);
        }
        if (hammerBought == 1)
        {
            hammerUseButton.SetActive(true);
        }
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void DisableButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i] != null)
            {
                buttons[i].SetActive(false);
            }
          
        }
    }

    public void CharacterClick(int index)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i] != null)
            {
                if (i != index)
                {
                    buttons[i].SetActive(false);
                }
            }

        }
        if (buttons[index].activeInHierarchy)
        {
            buttons[index].SetActive(false);
        }
        else
        {
            buttons[index].SetActive(true);
        }
      
    }
    public void PlayButtonCheck()
    {
        if(slotNum1==0 && slotNum2 ==0 && slotNum3 == 0)
        {
            playButton.interactable = false;
        }
        else
        {
            playButton.interactable = true;
        }
    }

    public void OpenTankInfoPanel()
    {
        tankInfoPanel.SetActive(true);
    }
    public void CloseTankInfoPanel()
    {
        tankInfoPanel.SetActive(false);
    }
    public void OpenArcherInfoPanel()
    {
        archerInfoPanel.SetActive(true);
    }
    public void CloseArcherInfoPanel()
    {
        archerInfoPanel.SetActive(false);
    }
    public void OpenMageInfoPanel()
    {
        mageInfoPanel.SetActive(true);
    }
    public void CloseMageInfoPanel()
    {
        mageInfoPanel.SetActive(false);
    }
    public void OpenNinjaInfoPanel()
    {
        ninjaInfoPanel.SetActive(true);
    }
    public void CloseNinjaInfoPanel()
    {
        ninjaInfoPanel.SetActive(false);
    }
    public void OpenWizardInfoPanel()
    {
        wizardInfoPanel.SetActive(true);
    }
    public void CloseWizardInfoPanel()
    {
        wizardInfoPanel.SetActive(false);
    }
    public void OpenBomberInfoPanel()
    {
        bomberInfoPanel.SetActive(true);
    }
    public void CloseBomberInfoPanel()
    {
        bomberInfoPanel.SetActive(false);
    }
    public void OpenHammerInfoPanel()
    {
        hammerInfoPanel.SetActive(true);
    }
    public void CloseHammerInfoPanel()
    {
        hammerInfoPanel.SetActive(false);
    }

    public void BuyWarrior()
    {
        if (cu.gold >= warriorPrice)
        {
            cu.ChangeMoney(-warriorPrice);
            warriorBought = 1;
            PlayerPrefs.SetInt("warriorBought", warriorBought);
            WarriorCheck();
        }
    }
    public void BuyArcher()
    {
        if (cu.gold >= archerPrice)
        {
            cu.ChangeMoney(-archerPrice);
            archerBought = 1;
            PlayerPrefs.SetInt("archerBought", archerBought);
            ArcherCheck();
        }
    }
    public void BuyMage()
    {
        if (cu.gold >= magePrice)
        {
            cu.ChangeMoney(-magePrice);
            mageBought = 1;
            PlayerPrefs.SetInt("mageBought", mageBought);
            MageCheck();
        }
    }
    public void BuyNinja()
    {
        if (cu.gold >= ninjaPrice)
        {
            cu.ChangeMoney(-ninjaPrice);
            ninjaBought = 1;
            PlayerPrefs.SetInt("ninjaBought", ninjaBought);
            NinjaCheck();
        }
    }
    public void BuyWizard()
    {
        if (cu.gold >= wizardPrice)
        {
            cu.ChangeMoney(-wizardPrice);
            wizardBought = 1;
            PlayerPrefs.SetInt("wizardBought", wizardBought);
            WizardCheck();
        }
    }
    public void BuyBomber()
    {
        if (cu.gold >= bomberPrice)
        {
            cu.ChangeMoney(-bomberPrice);
            bomberBought = 1;
            PlayerPrefs.SetInt("bomberBought", bomberBought);
            BomberCheck();
        }
    }
    public void BuyHammer()
    {
        if (cu.gold >= hammerPrice)
        {
            cu.ChangeMoney(-hammerPrice);
            hammerBought = 1;
            PlayerPrefs.SetInt("hammerBought", hammerBought);
            HammerCheck();
        }
    }
    public void WarriorCheck()
    {

        warriorBought = 1;
        if (warriorBought == 0)
        {
            warriorGray.SetActive(true);
            warriorBuyButton.SetActive(true);
            warriorPriceText.text = warriorPrice.ToString();
            tankUseButton.SetActive(false);
        }
        if (warriorBought == 1)
        {
            warriorGray.SetActive(false);
            warriorBuyButton.SetActive(false);
            tankUseButton.SetActive(true);
        }
    }
    public void ArcherCheck()
    {
        archerBought = PlayerPrefs.GetInt("archerBought");
        if (archerBought == 0)
        {
            archerGray.SetActive(true);
            archerBuyButton.SetActive(true);
            archerPriceText.text = archerPrice.ToString();
            archerUseButton.SetActive(false);
        }
        if (archerBought == 1)
        {
            archerGray.SetActive(false);
            archerBuyButton.SetActive(false);
            archerUseButton.SetActive(true);
        }
    }
    public void MageCheck()
    {
        mageBought = PlayerPrefs.GetInt("mageBought");
        if (mageBought == 0)
        {
            mageGray.SetActive(true);
            mageBuyButton.SetActive(true);
            magePriceText.text = magePrice.ToString();
            mageUseButton.SetActive(false);
        }
        if (mageBought == 1)
        {
            mageGray.SetActive(false);
            mageBuyButton.SetActive(false);
            mageUseButton.SetActive(true);
        }
    }
    public void NinjaCheck()
    {
        ninjaBought = PlayerPrefs.GetInt("ninjaBought");
        if (ninjaBought == 0)
        {
            ninjaGray.SetActive(true);
            ninjaBuyButton.SetActive(true);
            ninjaPriceText.text = ninjaPrice.ToString();
            ninjaUseButton.SetActive(false);
        }
        if (ninjaBought == 1)
        {
            ninjaGray.SetActive(false);
            ninjaBuyButton.SetActive(false);
            ninjaUseButton.SetActive(true);
        }
    }

    public void WizardCheck()
    {
        wizardBought = PlayerPrefs.GetInt("wizardBought");
        if (wizardBought == 0)
        {
            wizardGray.SetActive(true);
            wizardBuyButton.SetActive(true);
            wizardPriceText.text = wizardPrice.ToString();
            wizardUseButton.SetActive(false);
        }
        if (wizardBought == 1)
        {
            wizardGray.SetActive(false);
            wizardBuyButton.SetActive(false);
            wizardUseButton.SetActive(true);
        }
    }
    public void BomberCheck()
    {
        bomberBought = PlayerPrefs.GetInt("bomberBought");
        if (bomberBought == 0)
        {
            bomberGray.SetActive(true);
            bomberBuyButton.SetActive(true);
            bomberPriceText.text = bomberPrice.ToString();
            bomberUseButton.SetActive(false);
        }
        if (bomberBought == 1)
        {
            bomberGray.SetActive(false);
            bomberBuyButton.SetActive(false);
            bomberUseButton.SetActive(true);
        }
    }
    public void HammerCheck()
    {
        hammerBought = PlayerPrefs.GetInt("hammerBought");
        if (hammerBought == 0)
        {
            hammerGray.SetActive(true);
            hammerBuyButton.SetActive(true);
            hammerPriceText.text = hammerPrice.ToString();
            hammerUseButton.SetActive(false);
        }
        if (hammerBought == 1)
        {
            hammerGray.SetActive(false);
            hammerBuyButton.SetActive(false);
            hammerUseButton.SetActive(true);
        }
    }
}

