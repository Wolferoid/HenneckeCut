using S7.Net;
using StatusLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsLibrary;

namespace HenneckePortal
{
    public class PortalManage
    {
        #region Fields
        Plc plc;
        #endregion

        #region Properties

        #endregion

        #region Methods
        public string Connect()
        {
            string status = null;
            // Применить проверку типа try-catch ибо using не годиться
            // Connection to device
            plc = new Plc(ConnectionSettings.CpuType,
                          ConnectionSettings.IpAddress,
                          Convert.ToInt16(ConnectionSettings.Rack),
                          Convert.ToInt16(ConnectionSettings.Slot));
            if (!plc.IsConnected)
            {
                // Ensure IP is responding
                if (plc.IsAvailable)
                {
                    status = Status.Text(plc.Open());
                }
                else
                {
                    status = Status.Text(plc.Open());
                }
            }
            return status;
        }

        public string Disconnect()
        {
            string status = null;
            if (plc != null && plc.IsConnected)
            {
                plc.Close();
                status = Status.Text("СТАТУС: Соединение разорвано.");
            }
            else
            {
                plc.Dispose();
                status = Status.Text("СТАТУС: Ошибка разрыва соединения.");
            }
            return status;
        }

        public string CutMarkMetered()
        {
            string status = null;
            if (plc != null && plc.IsConnected)
            {
                plc.Write(Tags.CutMetered, 1);
                status = Status.Text(plc.LastErrorCode);
            }
            else
            {
                status = Status.Text("ОШИБКА: Соединение не установлено.");
            }
            return status;
        }

        public string CutMarkBegin()
        {
            string status = null;
            if (plc != null && plc.IsConnected)
            {
                plc.Write(Tags.CutBegin, 1);
                status = Status.Text(plc.LastErrorCode);
            }
            else
            {
                status = Status.Text("ОШИБКА: Соединение не установлено.");
            }
            return status;
        }

        public string CutMarkEnd()
        {
            string status = null;
            if (plc != null && plc.IsConnected)
            {
                plc.Write(Tags.CutEnd, 1);
                status = Status.Text(plc.LastErrorCode);
            }
            else
            {
                status = Status.Text("ОШИБКА: Соединение не установлено.");
            }
            return status;
        }

        public bool ConnectionStatus
        {
            get
            {
                bool status = false;

                if (plc != null && plc.IsConnected && plc.IsAvailable)
                    status = true;

                return status;
            }
        }

        #endregion

        #region Template
        public void WriteSettings()
        { }

        public void ReadSettings()
        { }



        #endregion
    }
}
