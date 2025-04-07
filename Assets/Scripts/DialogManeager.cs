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
        if (instance == null)                  //싱글론 패턴 구현
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
            dialogDatabase Initialize();                 //초기화
        }
        else
        {
            Debug.LogError("Dialog Database is not assinged to Dialog Manager");
        }
        if (NextButton != null)
        {
            //NextButton.onClick.AddListener(NextDialog);                      //버튼 리스너 등록
        }
        else
        {
            Debug.LogError("Next Button is not assignes!");
        }


    }
    //ID 로 대화 시작
    public void StartDialog(int dialogId)
    {
        DialogSO dialog = dialogDatabase.GetDialogByld(dialogld);
    }

    //DiglogSO로 대화 시작
    public void StartDialog(DialogSO dialog)
    {
        if (dialog == null) return;

        currentDialog = dialog;
        
    }

    public void ShowDialog()
    {
        if (currentDialog == null) return ;
        characterNameText.text = currentDialog.characterName;   //캐릭터 이름 설정
        dialogText.text = currentDialog.text;                   //대화 텍스트 설정
    }
    public void CloseDialog()                                   //대화 종료
    {
        dialogPanel.SetActive(false);
        currentDialog = null;
    }
} 
    

