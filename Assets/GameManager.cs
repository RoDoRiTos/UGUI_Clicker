using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text currentPointsText = null;

    private int currentPoints;

    [SerializeField]
    private Text pointsPerSecondText = null;

    [SerializeField]
    private GameObject upgradeCounterPrefab = null;

    [SerializeField]
    private GameObject upgradeShowAreaContentObj = null;

    [SerializeField]
    private GameObject firstUpgradeObj = null;
    private bool showFirstUpgrade = false;
    private int firstUpgradeCount = 0;
    private GameObject firstUpgradeCounterObj = null;

    [SerializeField]
    private GameObject secondUpgradeObj = null;
    private bool showSecondUpgrade = false;
    private int secondUpgradeCount = 0;
    private GameObject secondUpgradeCounterObj = null;

    [SerializeField]
    private GameObject thirdUpgradeObj = null;
    private bool showThirdUpgrade = false;
    private int thirdUpgradeCount = 0;
    private GameObject thirdUpgradeCounterObj = null;

    [SerializeField]
    private GameObject fourthUpgradeObj = null;
    private bool showFourthUpgrade = false;
    private int fourthUpgradeCount = 0;
    private GameObject fourthUpgradeCounterObj = null;

    [SerializeField]
    private GameObject fifthUpgradeObj = null;
    private bool showFifthUpgrade = false;
    private int fifthUpgradeCount = 0;
    private GameObject fifthUpgradeCounterObj = null;

    [SerializeField]
    private GameObject sixthUpgradeObj = null;
    private bool showSixthUpgrade = false;
    private int sixthUpgradeCount = 0;
    private GameObject sixthUpgradeCounterObj = null;


    void Start()
    {
        currentPointsText.text = "Current Points : 0";
        pointsPerSecondText.text = "0 Points/sec";

        firstUpgradeObj.SetActive(false);
        secondUpgradeObj.SetActive(false);
        thirdUpgradeObj.SetActive(false);
        fourthUpgradeObj.SetActive(false);
        fifthUpgradeObj.SetActive(false);
        sixthUpgradeObj.SetActive(false);

        StartCoroutine(AutoAdd());
    }

    private IEnumerator AutoAdd()
    {
        var counter = 0.0f;

        while (true)
        {
            counter += Time.deltaTime;
            if (counter > 1.0f)
            {
                counter = 0.0f;
                AddPoints(true);
            }

            yield return null;
        }
    }

    public void AddPoints(bool isAuto = false)
    {
        currentPoints += CalcUpgrades(isAuto);
        UpgradeCheck();
        UpdatePointCount();
    }

    private void UpdatePointCount()
    {
        currentPointsText.text = $"Current Points : {currentPoints}";
    }

    private void UpdateAutoPoints()
    {
        pointsPerSecondText.text = $"{CalcUpgrades(true)} Points/sec";
    }

    public int CalcUpgrades(bool isAuto = false)
    {
        var pointsToAdd = 1;
        if (isAuto) pointsToAdd -= 1;
        pointsToAdd += firstUpgradeCount;
        pointsToAdd += secondUpgradeCount * 3;
        pointsToAdd += thirdUpgradeCount * 5;
        pointsToAdd += fourthUpgradeCount * 10;
        pointsToAdd += fifthUpgradeCount * 25;
        pointsToAdd += sixthUpgradeCount * 50;
        return pointsToAdd;
    }

    public void UpgradeCheck()
    {
        if (!showFirstUpgrade)
        {
            if (currentPoints >= 10)
            {
                showFirstUpgrade = true;
                firstUpgradeObj.SetActive(true);
            }
        }

        if (!showSecondUpgrade)
        {
            if (currentPoints >= 30)
            {
                showSecondUpgrade = true;
                secondUpgradeObj.SetActive(true);
            }
        }

        if (!showThirdUpgrade)
        {
            if (currentPoints >= 50)
            {
                showThirdUpgrade = true;
                thirdUpgradeObj.SetActive(true);
            }
        }

        if (!showFourthUpgrade)
        {
            if (currentPoints >= 100)
            {
                showFourthUpgrade = true;
                fourthUpgradeObj.SetActive(true);
            }
        }

        if (!showFifthUpgrade)
        {
            if (currentPoints >= 250)
            {
                showFifthUpgrade = true;
                fifthUpgradeObj.SetActive(true);
            }
        }

        if (!showSixthUpgrade)
        {
            if (currentPoints >= 500)
            {
                showSixthUpgrade = true;
                sixthUpgradeObj.SetActive(true);
            }
        }
    }

    public void BuyFirstUpgrade()
    {
        if (currentPoints < 10) return;

        currentPoints -= 10;
        firstUpgradeCount += 1;

        if (firstUpgradeCount == 1)
        {
            InstantiateFirstUpgradeCounter();
        }
        else
        {
            UpdateFirstUpgradeCounter();
        }

        UpdateAutoPoints();
        UpdatePointCount();
    }

    private void InstantiateFirstUpgradeCounter()
    {
        firstUpgradeCounterObj = GameObject.Instantiate(upgradeCounterPrefab);
        firstUpgradeCounterObj.transform.SetParent(upgradeShowAreaContentObj.transform);
        firstUpgradeCounterObj.transform.localScale = Vector3.one;
        firstUpgradeCounterObj.GetComponentInChildren<Text>().text = "First Upgrade Count : 1";

    }

    private void UpdateFirstUpgradeCounter()
    {
        firstUpgradeCounterObj.GetComponentInChildren<Text>().text = $"First Upgrade Count : {firstUpgradeCount}";
    }

    public void BuySecondUpgrade()
    {
        if (currentPoints < 30) return;

        currentPoints -= 30;
        secondUpgradeCount += 1;

        if (secondUpgradeCount == 1)
        {
            InstantiateSecondUpgradeCounter();
        }
        else
        {
            UpdateSecondUpgradeCounter();
        }

        UpdateAutoPoints();
        UpdatePointCount();
    }

    private void InstantiateSecondUpgradeCounter()
    {
        secondUpgradeCounterObj = GameObject.Instantiate(upgradeCounterPrefab);
        secondUpgradeCounterObj.transform.SetParent(upgradeShowAreaContentObj.transform);
        secondUpgradeCounterObj.transform.localScale = Vector3.one;
        secondUpgradeCounterObj.GetComponentInChildren<Text>().text = "Second Upgrade Count : 1";
    }

    private void UpdateSecondUpgradeCounter()
    {
        secondUpgradeCounterObj.GetComponentInChildren<Text>().text = $"Second Upgrade Count : {secondUpgradeCount}";
    }

    public void BuyThirdUpgrade()
    {
        if (currentPoints < 50) return;

        currentPoints -= 50;
        thirdUpgradeCount += 1;

        if (thirdUpgradeCount == 1)
        {
            InstantiateThirdUpgradeCounter();
        }
        else
        {
            UpdateThirdUpgradeCounter();
        }

        UpdateAutoPoints();
        UpdatePointCount();
    }

    private void InstantiateThirdUpgradeCounter()
    {
        thirdUpgradeCounterObj = GameObject.Instantiate(upgradeCounterPrefab);
        thirdUpgradeCounterObj.transform.SetParent(upgradeShowAreaContentObj.transform);
        thirdUpgradeCounterObj.transform.localScale = Vector3.one;
        thirdUpgradeCounterObj.GetComponentInChildren<Text>().text = "Third Upgrade Count : 1";
    }

    private void UpdateThirdUpgradeCounter()
    {
        thirdUpgradeCounterObj.GetComponentInChildren<Text>().text = $"Third Upgrade Count : {thirdUpgradeCount}";
    }

    public void BuyFourthUpgrade()
    {
        if (currentPoints < 100) return;

        currentPoints -= 100;
        fourthUpgradeCount += 1;

        if (fourthUpgradeCount == 1)
        {
            InstantiateFourthUpgradeCounter();
        }
        else
        {
            UpdateFourthUpgradeCounter();
        }

        UpdateAutoPoints();
        UpdatePointCount();
    }

    private void InstantiateFourthUpgradeCounter()
    {
        fourthUpgradeCounterObj = GameObject.Instantiate(upgradeCounterPrefab);
        fourthUpgradeCounterObj.transform.SetParent(upgradeShowAreaContentObj.transform);
        fourthUpgradeCounterObj.transform.localScale = Vector3.one;
        fourthUpgradeCounterObj.GetComponentInChildren<Text>().text = "Fourth Upgrade Count : 1";
    }

    private void UpdateFourthUpgradeCounter()
    {
        fourthUpgradeCounterObj.GetComponentInChildren<Text>().text = $"Fourth Upgrade Count : {fourthUpgradeCount}";
    }

    public void BuyFifthUpgrade()
    {
        if (currentPoints < 250) return;

        currentPoints -= 250;
        fifthUpgradeCount += 1;

        if (fifthUpgradeCount == 1)
        {
            InstantiateFifthUpgradeCounter();
        }
        else
        {
            UpdateFifthUpgradeCounter();
        }

        UpdateAutoPoints();
        UpdatePointCount();
    }

    private void InstantiateFifthUpgradeCounter()
    {
        fifthUpgradeCounterObj = GameObject.Instantiate(upgradeCounterPrefab);
        fifthUpgradeCounterObj.transform.SetParent(upgradeShowAreaContentObj.transform);
        fifthUpgradeCounterObj.transform.localScale = Vector3.one;
        fifthUpgradeCounterObj.GetComponentInChildren<Text>().text = "Fifth Upgrade Count : 1";
    }

    private void UpdateFifthUpgradeCounter()
    {
        fifthUpgradeCounterObj.GetComponentInChildren<Text>().text = $"Fifth Upgrade Count : {fifthUpgradeCount}";
    }

    public void BuySixthUpgrade()
    {
        if (currentPoints < 500) return;

        currentPoints -= 500;
        sixthUpgradeCount += 1;

        if (sixthUpgradeCount == 1)
        {
            InstantiateSixthUpgradeCounter();
        }
        else
        {
            UpdateSixthUpgradeCounter();
        }

        UpdateAutoPoints();
        UpdatePointCount();
    }

    private void InstantiateSixthUpgradeCounter()
    {
        sixthUpgradeCounterObj = GameObject.Instantiate(upgradeCounterPrefab);
        sixthUpgradeCounterObj.transform.SetParent(upgradeShowAreaContentObj.transform);
        sixthUpgradeCounterObj.transform.localScale = Vector3.one;
        sixthUpgradeCounterObj.GetComponentInChildren<Text>().text = "Sixth Upgrade Count : 1";
    }

    private void UpdateSixthUpgradeCounter()
    {
        sixthUpgradeCounterObj.GetComponentInChildren<Text>().text = $"Sixth Upgrade Count : {sixthUpgradeCount}";
    }
}
