using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManeager : MonoBehaviour
{
    public static DialogManeager instance { get; private set; }

    [Header("Dialog References")]
    [SerializeField] private DialogChoiceSO dialogDatabase;

    [Header("UI References")]
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Button NextButton;

    private DialogSO currentDialog;

    private void Awake()
    {
        if (instance == null)                  //�̱۷� ���� ����
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        if (dialogDatabase != null)
        {
            dialogDatabase.Initialize();                 //�ʱ�ȭ
        }
        else
        {
            Debug.LogError("Dialog Database is not assinged to Dialog Manager");
        }
        if (NextButton != null)
        {
            //NextButton.onClick.AddListener(NextDialog);                      //��ư ������ ���
        }
        else
        {
            Debug.LogError("Next Button is not assignes!");
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        //UI�ʱ�ȭ �� ��ȭ ���� (ID 1)
        CloseDialog();
        StartDialog(1);                      //�ڵ����� ù ���� ��ȭ ����
    }
    //ID �� ��ȭ ����
    public void StartDialog(int dialogId)
    {
        DialogSO dialog = dialogDatabase.GetDialogByld(dialogId);
    }

    //DiglogSO�� ��ȭ ����
    public void StartDialog(DialogSO dialog)
    {
        if (dialog == null) return;

        currentDialog = dialog;
        ShowDialog();
        dialogPanel.SetActive(true);
        
    }

    public void ShowDialog()
    {
        if (currentDialog == null) return ;
        characterNameText.text = currentDialog.characterName;   //ĳ���� �̸� ����
        dialogText.text = currentDialog.text;                   //��ȭ �ؽ�Ʈ ����
    }

    public void NextDialog()
    {
        if(currentDialog != null && currentDialog.nextiId > 0)
        {
            DialogSO nextDialog = dialogDatabase.GetDialogByld(currentDialog.nextiId);
            if (nextDialog != null)
            {
                currentDialog = nextDialog;
                ShowDialog();
            }
            else
            {
                CloseDialog();
            }
        }
        else
        {
            CloseDialog();
        }
    }
    public void CloseDialog()                                   //��ȭ ����
    {
        dialogPanel.SetActive(false);
        currentDialog = null;
    }
} 
    

