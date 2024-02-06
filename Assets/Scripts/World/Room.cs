using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("DoorConsts")]
    public bool constLeft;
    public bool constFront;
    public bool constRight;
    public bool constBack;
    [Header("Doors")]
    [SerializeField] private GameObject doorLeft;
    [SerializeField] private GameObject doorFront;
    [SerializeField] private GameObject doorRight;
    [SerializeField] private GameObject doorBack;
    [Header("Tunnels")]
    [SerializeField] private GameObject tunnelLeft;
    [SerializeField] private GameObject tunnelFront;
    [SerializeField] private GameObject tunnelRight;
    [SerializeField] private GameObject tunnelBack;

    public void RandomConst()
    {
        constLeft = Random.Range(0, 2) != 1;
        constFront = Random.Range(0, 2) != 1;
        constRight = Random.Range(0, 2) != 1;
        constBack = Random.Range(0, 2) != 1;
        DisableConst();
    }
    public void DisableConst()
    {
        if (constLeft) tunnelLeft.SetActive(!tunnelLeft.activeSelf);
        if (constFront) tunnelFront.SetActive(!tunnelFront.activeSelf);
        if (constRight) tunnelRight.SetActive(!tunnelRight.activeSelf);
        if (constBack) tunnelBack.SetActive(!tunnelBack.activeSelf);
}
    public void LeftSwitcher()
    {
        if (!constLeft) doorLeft.SetActive(!doorLeft.activeSelf);
    }
    public void FrontSwitcher()
    {
        if (!constFront) doorFront.SetActive(!doorFront.activeSelf);
    }
    public void RightSwitcher()
    {
        if (!constRight) doorRight.SetActive(!doorRight.activeSelf);
    }
    public void BackSwitcher()
    {
        if (!constBack) doorBack.SetActive(!doorBack.activeSelf);
    }
}
