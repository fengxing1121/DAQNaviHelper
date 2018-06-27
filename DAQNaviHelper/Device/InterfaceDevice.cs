﻿using Automation.BDaq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAQNaviHelper.Device
{
    public interface InterfaceDevice
    {
        //初始化驱动
        bool InitDevice(DeviceInformation deviceInformation, out string message);

        #region 事件
        event DAQNaviHelper.DelegateErrorEvent EventError;
        event DAQNaviHelper.DelegateAiEvent EventAi;
        event DAQNaviHelper.DelegateDiChangeEvent EventDiChange;
        #endregion

        #region 模拟输入
        void StartAiMode(DAQNaviHelper.DelegateAiEvent e, double timers = 1, bool isAutoReset = false);
        void StopAiMode();
        #endregion

        #region 数字输入
        byte[] StartDiMode(DAQNaviHelper.DelegateDiChangeEvent e);
        void StopDiMode();
        bool GetDiMode(out byte[] arrPortData);
        bool GetDiModeBit(int bit, byte portData);
        #endregion

        #region 数字输出
        bool SetDoMode(byte byteData);
        bool SetDoModeBit(int bit, byte data);
        bool GetDoMode(out byte[] arrByteData);
        bool GetDoModeBit(int bit, out byte bitData);
        #endregion

        void Test(object e);

    }
}
