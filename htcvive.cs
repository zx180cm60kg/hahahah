using UnityEngine;
using System.Collections;

public class yzx_controller : MonoBehaviour
{
    SteamVR_TrackedObject Hand;
    SteamVR_Controller.Device device;

    bool IsShock = false;  //�����ͱ���IsShock

    // Use this for initialization
    void Start()
    {
        Hand = GetComponent();  //���SteamVR_ TrackedObject���  
    }

    // Update is called once per frame
    void Update()
    {

        //��ֹStart����û���سɹ�����֤SteamVR_ TrackedObject�����ȡ�ɹ���
        if (Hand.isValid)
        {
            Hand = GetComponent();
        }
        device = SteamVR_Controller.Input((int)Hand.index);    //����index������ֱ� 
                                                               //����ֱ���Trigger����������
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {

            IsShock = false;  //ÿ�ΰ��£�IsShockΪfalse,���ܱ�֤�ֱ���
            StartCoroutine("Shock", 0.5f); //����Э��Shock(),�ڶ�������0.5f ��ΪЭ��Shock()���β�
        }

    }

    //������һ��Э��

    IEnumerator Shock(float durationTime)

    {

        //Invoke��������ʾdurationTime���ִ��StopShock������
        Invoke("StopShock", durationTime);

        //Э��һֱʹ���ֱ������𶯣�ֱ�������ͱ���IsShockΪfalse;
        while (!IsShock)
        {
            device.TriggerHapticPulse(500);

            yield return new WaitForEndOfFrame();

        }


    }

    void StopShock()
    {
        IsShock = true; //�ر��ֱ�����
    }


}