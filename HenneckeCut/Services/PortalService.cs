using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenneckeCut
{
    using HenneckePortal;
    using Services.Interfaces;
    public class PortalService : IPortalService
    {
        #region Fields
        string statusText;
        PortalManage portal;
        #endregion

        #region Constructor
        public PortalService()
        {
            portal = new PortalManage();
        }
        #endregion

        #region Properties
        public string LastStatusText
        {
            get
            {
                return statusText;
            }
        }

        public bool ConnectionStatus
        {
            get
            {
                return portal.ConnectionStatus;
            }
        }
        #endregion

        #region Methods

        public void Connect()
        {
            statusText = portal.Connect();
        }
        public void Disconnect()
        {
            statusText = portal.Disconnect();
        }

        public void CutMarkMetered()
        {
            statusText = portal.CutMarkMetered();
        }

        public void CutMarkBegin()
        {
            statusText = portal.CutMarkBegin();
        }

        public void CutMarkEnd()
        {
            statusText = portal.CutMarkEnd();
        }
        #endregion

    }
}