using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    public PlayerStaff staff;
    public Transform image1, image2, image3;
    public List<GameObject> stack = new List<GameObject>();
    public GameObject buyBtn, playBtn;
    public Text costText;

    public void Next()
    {
        staff.Next();
        Draw();
    }
    public void Back()
    {
        staff.Back();

        Draw();
    }

    void ClearStack()
    {
        foreach (var item in stack)
        {
            Destroy(item);
        }
        stack.Clear();
    }
    public void Buy()
    {
        staff.Buy();
        Draw();
    }
    void Draw()
    {
        ClearStack();
        stack.Add(Instantiate(staff.GetBackSprite().skinObject, image1.position, new Quaternion(), image1));
        stack.Add(Instantiate(staff.GetSelectSprite().skinObject, image2.position, new Quaternion(), image2));
        stack.Add(Instantiate(staff.GetNextSprite().skinObject, image3.position, new Quaternion(), image3));
        costText.text = $"{staff.GetSelectSprite().cost}$";
        if (staff.selected.byed)
        {
            buyBtn.SetActive(false);
            playBtn.SetActive(true);
            costText.gameObject.SetActive(false);
        }
        else
        {
            buyBtn.SetActive(true);
            playBtn.SetActive(false);
            costText.gameObject.SetActive(true);
        }
    }
    // Use this for initialization
    void Start()
    {
        Draw();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
