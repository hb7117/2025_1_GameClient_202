using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    public CardData cardData;                  //ī�� ������

    //3D ī�� ���
    public MeshRenderer cardRenderer;          //ī�� ������ (icon or �Ϸ���Ʈ)
    public TextMeshPro nameText;               //�̸� �ؽ�Ʈ
    public TextMeshPro costText;               //��� �ؽ�Ʈ
    public TextMeshPro attackText;             //���ݷ�/ȿ�� �ؽ�Ʈ
    public TextMeshPro descriptionText;        //���� �ؽ�Ʈ

    //ī�� ������ ����
    public void SetupCard(CardData data)
    {
        cardData = data;

        //3D �ؽ�Ʈ ������Ʈ
        if (nameText != null) nameText.text = data.cardName;
        if (costText != null) costText.text = data.manaCost.ToString();
        if (attackText != null) attackText.text = data.effectAmount.ToString();
        if (descriptionText != null) descriptionText.text = data.description;

        //ī�� �ؽ��� ����
        if(cardRenderer != null && data.artwork != null)
        {
            Material cardMaterial = cardRenderer.material;
            cardMaterial.mainTexture = data.artwork.texture;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
