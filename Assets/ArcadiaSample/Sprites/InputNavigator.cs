﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputNavigator : MonoBehaviour
{
    EventSystem system;
    public GameObject StarterObject;
    public GameObject[] StarterObjectList = new GameObject[10];
    void Start()
    {
        system = EventSystem.current;// EventSystemManager.currentSystem;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (system.currentSelectedGameObject != null)
            {
                Selectable next = null;
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
                    if (next == null)
                        next = system.lastSelectedGameObject.GetComponent<Selectable>();
                }
                else
                {
                    next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
                    if (next == null)
                        next = system.firstSelectedGameObject.GetComponent<Selectable>();
                }

                if (next != null)
                {

                    InputField inputfield = next.GetComponent<InputField>();
                    if (inputfield != null)
                        inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret

                    system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
                }
                //else Debug.Log("next nagivation element not found");
            }
            else
            {
                Selectable next = StarterObject.GetComponent<Selectable>();
                if (next != null)
                {

                    InputField inputfield = next.GetComponent<InputField>();
                    if (inputfield != null)
                        inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret

                    system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
                }

            }
        }
    }

    //EventSystem system = EventSystem.current;
    //  void Start()
    //  {

    //      system = EventSystem.current;

    //  }

    //  // Update is called once per frame
    //  public void Update()
    //  {

    //      if (Input.GetKeyDown(KeyCode.Tab))
    //      {
    //          if (system.currentSelectedGameObject != null)
    //          {
    //              Selectable next = null;
    //              if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
    //              {
    //                  next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();

    //                      next = system.lastSelectedGameObject.GetComponent<Selectable>();
    //              }
    //              else
    //              {
    //                  next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
    //                  if (next == null)
    //                      next = system.firstSelectedGameObject.GetComponent<Selectable>();
    //              }

    //              if (next != null)
    //              {

    //                  InputField inputfield = next.GetComponent<InputField>();
    //                  if (inputfield != null) inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret

    //                  system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
    //              }
    //              //else Debug.Log("next nagivation element not found");
    //          }
    //      }
    //  }




}
