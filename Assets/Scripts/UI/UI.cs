using System.Collections;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [Header("End screen")]
    [SerializeField] private UI_FadeScript fadeScreen;
    [SerializeField] private GameObject endText;
    [SerializeField] private GameObject restartButton;
    [Space]

    [SerializeField] private GameObject characterUI;
    [SerializeField] private GameObject skilTreeUI;
    [SerializeField] private GameObject craftUI;
    [SerializeField] private GameObject optionsUI;
    [SerializeField] private GameObject inGameUI;

    public UI_SkillToolTip skillToolTip;
    public UI_ItemToolTip itemToolTip;
    public UI_StatToolTip statToolTip;
    public UI_CraftWIndow craftWindow;

    private void Awake()
    {
        switchTo(skilTreeUI); //Need this to assign events on skilltreeslot on time
    }
    // Start is called before the first frame update
    void Start()
    {
        //switchTo(null); //No menu at beggining
        switchTo(inGameUI);

        itemToolTip.gameObject.SetActive(false);
        statToolTip.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            switchWithKeyTo(characterUI);

        if (Input.GetKeyDown(KeyCode.B))
            switchWithKeyTo(craftUI);

        if (Input.GetKeyDown(KeyCode.K))
            switchWithKeyTo(skilTreeUI);

        if (Input.GetKeyDown(KeyCode.O))
            switchWithKeyTo(optionsUI);
    }

    public void switchTo(GameObject _menu)
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            bool fadeScreen = transform.GetChild(i).GetComponent<UI_FadeScript>() != null;

            if(!fadeScreen)
                transform.GetChild(i).gameObject.SetActive(false);
        }

        if (_menu != null)
            _menu.SetActive(true);
    }

    public void switchWithKeyTo(GameObject _menu)
    {
        if (_menu != null && _menu.activeSelf)
        {
            _menu.SetActive(false);
            checkForInGameUI();
            return;
        }

        switchTo(_menu);
    }

    private void checkForInGameUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
                return;
        }

        switchTo(inGameUI);
    }

    public void switchOnEndScreen()
    {
        fadeScreen.fadeOut();
        StartCoroutine(endScreenCoRoutine());

    }

    IEnumerator endScreenCoRoutine()
    {
        yield return new WaitForSeconds(1);
        endText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        restartButton.SetActive(true);
    }

    public void restartGameButton() => GameManager.instance.restartScene();
}
