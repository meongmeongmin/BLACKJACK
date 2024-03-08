using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuPopup : UI_Popup
{
    #region enum
    enum Buttons
    {
        SoundEffectButton,
        BackgroundSoundButton,
        HomeButton,
        MailButton,
        BackButton,
    }

    enum Texts
    {
        VersionValueText,
        PlayerIDNumberText,
    }
    #endregion

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        #region ���ε�
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));

        BindEvent(GetButton((int)Buttons.SoundEffectButton).gameObject, OnSoundEffectButtonClick);
        BindEvent(GetButton((int)Buttons.BackgroundSoundButton).gameObject, OnBackgroundSoundButtonClick);
        BindEvent(GetButton((int)Buttons.HomeButton).gameObject, OnHomeButtonClick);
        BindEvent(GetButton((int)Buttons.MailButton).gameObject, OnMailButtonClick);
        BindEvent(GetButton((int)Buttons.BackButton).gameObject, OnBackButtonClick);
        #endregion
    }

    private void OnSoundEffectButtonClick()
    {

    }

    private void OnBackgroundSoundButtonClick()
    {

    }

    private void OnHomeButtonClick()
    {
        Managers.Scene.LoadScene(Define.Scene.HomeScene);
    }

    private void OnMailButtonClick()
    {

    }

    private void OnBackButtonClick()
    {
        ClosePopupUI();
    }
}
