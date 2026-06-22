using UnityEngine;

public class ValoresCartas : MonoBehaviour
{
    public static ValoresCartas Instance;

    private const bool ATIVADO = true;
    private const bool DESATIVADO = false;

    [Header("Dados da carta")]
    [SerializeField] private int id;
    [SerializeField] private int value;
    [SerializeField] private bool isAce;


    [Header("Verso")]
    [SerializeField] private GameObject verso;

    private void OnEnable()
    {
        //this.gameObject.GetComponentInChildren<Image>().sprite = 
    }


    public void SetId(int id)
    {
        this.id = id;
    }

    public void SetValue(int value)
    {
        this.value = value;
    }

    public void SetIsAce(bool isAce)
    {
        this.isAce = isAce;
    }

    public bool GetIsAce()
    {
        return isAce;
    }

    public int GetId()
    {
        return id;
    }

    public int GetValue()
    {
        return value;
    }

    public GameObject GetVerso()
    {
        return verso;
    }

    public void AtivarOuDesativarVerso()
    {
        if (verso.activeInHierarchy == ATIVADO)
        {
            verso.SetActive(DESATIVADO);
        }
        else
        {
            verso.SetActive(ATIVADO);
        }
    }
}
