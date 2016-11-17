using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenneckeCut.Services.Interfaces
{
    public interface IPortalService
    {
        string LastStatusText { get; }
        bool ConnectionStatus { get; }
        void Connect();
        void Disconnect();
        void CutMarkMetered();
        void CutMarkBegin();
        void CutMarkEnd();
    }
}
