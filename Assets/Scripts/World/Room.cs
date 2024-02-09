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

    public void DisableConst()
    {
        if (constLeft) tunnelLeft.SetActive(false);
        if (constFront) tunnelFront.SetActive(false);
        if (constRight) tunnelRight.SetActive(false);
        if (constBack) tunnelBack.SetActive(false);
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
