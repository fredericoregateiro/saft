using SolRIA.SaftAnalyser.Interfaces;
using SolRIA.SaftAnalyser.Models;
using SolRIA.SaftAnalyser.Mvvm;
using System;
using System.Linq;

namespace SolRIA.SaftAnalyser.ViewModels
{
    public class SaftErrorsViewModel : BindableBase
    {
        readonly INavigationService navService;
        readonly IMessageService messageService;
        public SaftErrorsViewModel(INavigationService navService, IMessageService messageService)
        {
            this.navService = navService;
            this.messageService = messageService;

            navService.LoadCompleted += NavService_LoadCompleted;
        }

        private void NavService_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            DoOpenViewCommand = new DelegateCommand(OpenView);

            if (OpenedFileInstance.Instance.SaftFile.SourceDocuments != null && OpenedFileInstance.Instance.SaftFile.SourceDocuments.SalesInvoices != null)
            {
                ErrorMessages = OpenedFileInstance.Instance.MensagensErro.ToArray();
                errorBackup = ErrorMessages;
            }
        }

        string numErrors;
        public string NumErros
        {
            get => numErrors;
            set => SetProperty(ref numErrors, value);
        }
        private void InitNumErrors()
        {
            if (errorMessages == null || errorMessages.Length == 0)
                NumErros = "Não existem erros.";
            else
                NumErros = string.Format("Existem {0} erros.", errorMessages.Length);
        }

        Error[] errorMessages;
        public Error[] ErrorMessages
        {
            get => errorMessages;
            set
            {
                SetProperty(ref errorMessages, value);
                InitNumErrors();
            }
        }

        Error selectedError;
        public Error SelectedError
        {
            get => selectedError;
            set => SetProperty(ref selectedError, value);
        }

        Error[] errorBackup;
        string filtro;
        public string Filtro
        {
            get { return filtro; }
            set
            {
                filtro = value;
                if (string.IsNullOrEmpty(filtro))
                    ErrorMessages = errorBackup;
                else
                {
                    ErrorMessages = (from e in ErrorMessages
                                     where e.Description.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0
                                     select e).ToArray();
                }

                SetProperty(ref filtro, value);
            }
        }

        //[MediatorMessageSink(MessageType.SAFT_HASH_RESULTS)]
        //private void LoadHashValidationResults(Error[] error)
        //{
        //    ErrorMessages = error;
        //    errorBackup = error;
        //}
        //[MediatorMessageSink(MessageType.ERROR_FOUND)]
        //private void LoadErrorResults(Error[] error)
        //{
        //    ErrorMessages = error;
        //    errorBackup = error;
        //}

        //[MediatorMessageSink(MessageType.SAFT_SCHEMA_RESULTS)]
        //private void LoadSchemaValidationResults(Error[] error)
        //{
        //    ErrorMessages = error;
        //    errorBackup = error;
        //}

        public DelegateCommand DoOpenViewCommand { get; private set; }
        private void OpenView()
        {
            //if (selectedError != null)
            //{
            //    if (selectedError.TypeofError == typeof(SourceDocumentsSalesInvoicesInvoice))
            //        Mediator.Instance.NotifyColleaguesAsync<string>(MessageType.FOCUS_INVOICES, selectedError.UID);
            //    if (selectedError.TypeofError == typeof(SourceDocumentsSalesInvoicesInvoiceLine))
            //        Mediator.Instance.NotifyColleaguesAsync<string>(MessageType.FOCUS_INVOICES_LINE, string.Format("{0};{1}", selectedError.UID, selectedError.SupUID));
            //    else if (selectedError.TypeofError == typeof(Header))
            //        Mediator.Instance.NotifyColleaguesAsync<string>(MessageType.FOCUS_HEADER, selectedError.UID);
            //    else if (selectedError.TypeofError == typeof(Customer))
            //        Mediator.Instance.NotifyColleaguesAsync<string>(MessageType.FOCUS_CUSTOMERS, selectedError.UID);
            //    else if (selectedError.TypeofError == typeof(Product))
            //        Mediator.Instance.NotifyColleaguesAsync<string>(MessageType.FOCUS_PRODUCTS, selectedError.UID);
            //    else if (selectedError.TypeofError == typeof(Supplier))
            //        Mediator.Instance.NotifyColleaguesAsync<string>(MessageType.FOCUS_SUPPLIERS, selectedError.UID);
            //    else if (selectedError.TypeofError == typeof(Tax))
            //        Mediator.Instance.NotifyColleaguesAsync<string>(MessageType.FOCUS_TAXS, selectedError.UID);
            //}
        }
    }
}
