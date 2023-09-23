namespace AosPathToGlory
{
    public partial class ArmyListPage : ContentPage
    {
        private readonly AosPathToGloryDatabase _pathToGloryDatabase;
        public List<AosArmy> AosArmies = new List<AosArmy>();

        public ArmyListPage(AosPathToGloryDatabase pathToGloryDatabase)
        {
            InitializeComponent();
            _pathToGloryDatabase = pathToGloryDatabase;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var armiesQuery = await _pathToGloryDatabase.GetArmiesAsync();
            AosArmies = await armiesQuery.ToListAsync();

            ArmyList.ItemsSource = null; // Clear the items source
            ArmyList.ItemsSource = AosArmies; // Set it again to trigger a refresh}
        }

        private async void OnCreateClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("wizard");
        }
    }
}