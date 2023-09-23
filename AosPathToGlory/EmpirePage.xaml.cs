namespace AosPathToGlory
{
    public partial class EmpirePage : ContentPage
    {
        private readonly AosPathToGloryDatabase _pathToGloryDatabase;
        //int count = 0;

        public EmpirePage(AosPathToGloryDatabase pathToGloryDatabase)
        {
            InitializeComponent();
            _pathToGloryDatabase = pathToGloryDatabase;
        }

        //public MainPage()
        //{
        //    InitializeComponent();
        //}

        protected override async void OnAppearing()
        {
            await UpdateAsync();
        }

        private async Task UpdateAsync()
        {
            var armies = await _pathToGloryDatabase.GetArmiesAsync();
            

            var armiesCount = await armies.CountAsync();
            var canArmyBeCreated = armiesCount == 0;
            
            ArmyName.IsEnabled = canArmyBeCreated;
            ArmyFaction.IsEnabled = canArmyBeCreated;
            ArmySubFaction.IsEnabled = canArmyBeCreated;
            ArmyStartingSize.IsEnabled = canArmyBeCreated;
            ArmyOrigin.IsEnabled = canArmyBeCreated;
            SaveBtn.IsVisible = canArmyBeCreated;
            DeleteBtn.IsVisible = !canArmyBeCreated;

            if (canArmyBeCreated)
            {
                ArmyName.Text = string.Empty;
                ArmyFaction.Text = string.Empty;
                ArmySubFaction.Text = string.Empty;
                ArmyOrigin.Text = string.Empty;
                ArmyStartingSize.Text = string.Empty;
            }
            else
            {
                var activeArmy = await armies.FirstAsync();

                ArmyName.Text = activeArmy.Name;
                ArmyFaction.Text = activeArmy.Faction;
                ArmySubFaction.Text = activeArmy.SubFaction;
                ArmyOrigin.Text = activeArmy.Origin;
                ArmyStartingSize.Text = activeArmy.StartingSize.ToString();
            }
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

            await UpdateAsync();
            //count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var armies = await _pathToGloryDatabase.GetArmiesAsync();
            var activeArmy = await armies.FirstAsync();

            await _pathToGloryDatabase.DeleteItemAsync(activeArmy);

            await UpdateAsync();
        }
    }
}