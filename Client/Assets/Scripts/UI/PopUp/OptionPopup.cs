using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Client
{
    public class OptionPopup : UI_Popup
    {
        enum Buttons
        {
            ExitBtn,
        }
        enum Sliders
        {
            BGMSlider,
            SFXSlider,

        }
        enum Texts
        {

        }
        
        // Start is called before the first frame update
        void Start()
        {
            Init();
        }


        public override void Init()
        {
            base.Init();
            Bind<Button>(typeof(Buttons));
            Bind<Slider>(typeof(Sliders));
            BindEventBtn();

            //Get<Slider>((int)Sliders.BGMSlider).value = AudioManager.Instance.BGMVolume;
            //Get<Slider>((int)Sliders.SFXSlider).value = AudioManager.Instance.SFXVolume;

            Get<Slider>((int)Sliders.BGMSlider).onValueChanged.AddListener(delegate { VolumeChange(SystemEnum.eSounds.BGM); });
            Get<Slider>((int)Sliders.SFXSlider).onValueChanged.AddListener(delegate { VolumeChange(SystemEnum.eSounds.SFX); });

        }

        #region Btn 
        void BindEventBtn()
        {
            BindEvent(GetButton((int)Buttons.ExitBtn).gameObject, Btn_Exit);

        }

        void Btn_Exit(PointerEventData evt)
        {
            UIManager.Instance.ClosePopupUI();
        }
        #endregion Btn 

        #region Slider
        void VolumeChange(SystemEnum.eSounds Sound)
        {
            float volume;
            if (Sound == SystemEnum.eSounds.BGM)
            {
                volume = Get<Slider>((int)Sliders.BGMSlider).value;
                //AudioManager.Instance.BGMVolume = volume;

            }
            else
            {
                volume = Get<Slider>((int)Sliders.SFXSlider).value;
                //AudioManager.Instance.SFXVolume = volume;

            }

            AudioManager.Instance.SetVolume(Sound, volume);

        }

        

        #endregion Slider


    }
}