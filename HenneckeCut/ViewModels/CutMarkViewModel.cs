namespace HenneckeCut.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using Services.Interfaces;
    using System.Threading.Tasks;
    using System.Timers;
    using System.Windows.Media;
    public class CutMarkViewModel : ViewModelBase
    {
        IPortalService portalService;
        Timer timer;
        public CutMarkViewModel()
        {
            portalService = new PortalService();

            MarkMetered = new Command(OnMarkMeteredExecute);
            MarkBegin = new Command(OnMarkBeginExecute);
            MarkEnd = new Command(OnMarkEndExecute);
        }

        public override string Title { get { return "Hennecke Cut Program"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets
        #region Properties
        public string StatusBarText
        {
            get { return GetValue<string>(StatusBarTextProperty); }
            set { SetValue(StatusBarTextProperty, value); }
        }
        public static readonly PropertyData StatusBarTextProperty = RegisterProperty("StatusBarText", typeof(string), "СТРОКА СОСТОЯНИЙ");

        public string LampConnectionStatus
        {
            get { return GetValue<string>(LampConnectionStatusProperty); }
            set { SetValue(LampConnectionStatusProperty, value); }
        }
        public static readonly PropertyData LampConnectionStatusProperty = RegisterProperty("LampConnectionStatus", typeof(string), Colors.DarkGray.ToString());
        #endregion

        #region Commands

        public Command MarkMetered { get; private set; }
        private void OnMarkMeteredExecute()
        {
            portalService.CutMarkMetered();
            StatusBarText = portalService.LastStatusText;
        }

        public Command MarkBegin { get; private set; }
        private void OnMarkBeginExecute()
        {
            portalService.CutMarkBegin();
            StatusBarText = portalService.LastStatusText;
        }

        public Command MarkEnd { get; private set; }
        private void OnMarkEndExecute()
        {
            portalService.CutMarkEnd();
            StatusBarText = portalService.LastStatusText;
        }
        #endregion

        #region Methods
        private void OnConnect()
        {
            if (timer == null)
            {
                timer = new Timer(500);
                timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            }
            timer.Enabled = true;
        }

        private void OnDisconnect()
        {
            timer.Enabled = false;
        }
        #endregion

        #region Events
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            LampConnectionStatus = portalService.ConnectionStatus ? Colors.LimeGreen.ToString() : Colors.Red.ToString();
        }
        #endregion

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            // TODO: subscribe to events here
            portalService.Connect();
            OnConnect();
            StatusBarText = portalService.LastStatusText;            
        }

        protected override async Task CloseAsync()
        {
            OnDisconnect();
            portalService.Disconnect();
            // TODO: unsubscribe from events here
            await base.CloseAsync();
        }
    }
}
