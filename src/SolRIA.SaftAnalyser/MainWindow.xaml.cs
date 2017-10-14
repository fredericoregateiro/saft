using Prism.Commands;
using Prism.Mvvm;
using SolRIA.SaftAnalyser.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Practices.Unity;

namespace SolRIA.SaftAnalyser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            //init the navigation service
            App.ConfigureUnityContainer(navigationFrame.NavigationService, MainSnackbar, RootDialog);

            base.OnInitialized(e);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = new MainWindowViewModel();
            vm.Init();

            DataContext = vm;
        }

        private void Card_DropSAFT(object sender, DragEventArgs e)
        {

        }

        private void Card_DropStocks(object sender, DragEventArgs e)
        {

        }

        private void Card_DropTransport(object sender, DragEventArgs e)
        {

        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.solria.pt");
        }

        private void UpdateProperty(string propertyName)
        {
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class SaftPage
    {
        public string Name { get; set; }
        public string View { get; set; }
    }

    public class MainWindowViewModel : BindableBase
    {
        INavigationService navService;

        public void Init()
        {
            navService = App.container.Resolve<INavigationService>();

            NavigateCommand = new DelegateCommand<SaftPage>(OnNavigate);

            allPages = new SaftPage[]
            {
                new SaftPage{ Name = "Cabeçalho", View = PagesIds.SAFT_HEADER },
                new SaftPage{ Name = "Clientes", View = PagesIds.SAFT_CUSTOMERS },
                new SaftPage{ Name = "Produtos", View = PagesIds.SAFT_PRODUCTS },
                new SaftPage{ Name = "Impostos", View = PagesIds.SAFT_TAXES },
                new SaftPage{ Name = "Doc. Faturação", View = PagesIds.SAFT_INVOICES },
                new SaftPage{ Name = "Resumo Faturação", View = PagesIds.SAFT_INVOICES_SUMMARY },
                new SaftPage{ Name = "Erros", View = PagesIds.SAFT_ERRORS },
            };

            SaftPages = new ObservableCollection<SaftPage>();
            SaftPages.AddRange(allPages);
        }
        SaftPage[] allPages;

        private ObservableCollection<SaftPage> saftPages;
        public ObservableCollection<SaftPage> SaftPages
        {
            get => saftPages;
            set => SetProperty(ref saftPages, value);
        }

        public DelegateCommand<SaftPage> NavigateCommand { get; private set; }
        private void OnNavigate(SaftPage page)
        {
            if (OpenedFileInstance.Instance.SaftFile != null)
                navService.Navigate(page.View);
        }
    }
}
