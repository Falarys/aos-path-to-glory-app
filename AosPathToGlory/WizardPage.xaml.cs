namespace AosPathToGlory
{
    public partial class WizardPage : ContentPage
    {
        private readonly AosPathToGloryDatabase _pathToGloryDatabase;
        //int count = 0;

        public WizardPage(AosPathToGloryDatabase pathToGloryDatabase)
        {
            InitializeComponent();
            _pathToGloryDatabase = pathToGloryDatabase;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Shell.SetTabBarIsVisible(this, false);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Shell.SetTabBarIsVisible(this, true);
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (ArmyStartingSize.Text == string.Empty)
                ArmyStartingSize.Text = "0";

            await _pathToGloryDatabase.SaveItemAsync(new AosArmy
            {
                Name= ArmyName.Text,
                Faction = ArmyFaction.Text,
                Origin = ArmyOrigin.Text,
                StartingSize = int.Parse(ArmyStartingSize.Text),
                SubFaction = ArmySubFaction.Text,
            });

            Application.Current.MainPage = new NavigationPage(new MainPage(new AosPathToGloryDatabase()));
        }
    }
}