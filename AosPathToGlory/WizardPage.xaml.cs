namespace AosPathToGlory
{
    public partial class WizardPage : ContentPage
    {
        private readonly AosPathToGloryDatabase _pathToGloryDatabase;

        public WizardPage(AosPathToGloryDatabase pathToGloryDatabase)
        {
            InitializeComponent();
            _pathToGloryDatabase = pathToGloryDatabase;
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //}

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    Shell.SetTabBarIsVisible(this, true);
        //}

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (ArmyStartingSize.Text == null || ArmyStartingSize.Text == string.Empty)
                ArmyStartingSize.Text = "0";

            ArmyName.Text ??= string.Empty;
            ArmyFaction.Text ??= string.Empty;
            ArmyOrigin.Text ??= string.Empty;
            ArmySubFaction.Text ??= string.Empty;

            await _pathToGloryDatabase.SaveItemAsync(new AosArmy
            {
                Name = ArmyName.Text,
                Faction = ArmyFaction.Text,
                Origin = ArmyOrigin.Text,
                StartingSize = int.Parse(ArmyStartingSize.Text),
                SubFaction = ArmySubFaction.Text,
            });

            await Shell.Current.GoToAsync("armylist");
        }
    }
}