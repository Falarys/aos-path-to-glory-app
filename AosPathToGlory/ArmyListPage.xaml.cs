namespace AosPathToGlory
{
    public partial class ArmyListPage : ContentPage
    {
        private readonly AosPathToGloryDatabase _pathToGloryDatabase;
        public List<AosArmy> AosArmies = new List<AosArmy>()
        {
            new AosArmy
            {
                Id = 1,
                Faction = "Fac 1",
                Name = "Name 1",
                Origin = "Origin 1",
                StartingSize = 600,
                SubFaction = "SubFac 1"
            },
            new AosArmy
            {
                Id = 1,
                Faction = "Fac 1",
                Name = "Name 1",
                Origin = "Origin 1",
                StartingSize = 600,
                SubFaction = "SubFac 1"
            },
            new AosArmy
            {
                Id = 1,
                Faction = "Fac 1",
                Name = "Name 1",
                Origin = "Origin 1",
                StartingSize = 600,
                SubFaction = "SubFac 1"
            }
        };
        //int count = 0;

        public ArmyListPage(AosPathToGloryDatabase pathToGloryDatabase)
        {
            InitializeComponent();
            _pathToGloryDatabase = pathToGloryDatabase;

            ArmyList.ItemsSource = AosArmies;
        }


        private async void OnCreateClicked(object sender, EventArgs e)
        {
            AosArmies.Add(new AosArmy
            {
                Id = 1,
                Faction = "Fac 1",
                Name = "Name 1",
                Origin = "Origin 1",
                StartingSize = 600,
                SubFaction = "SubFac 1"
            });

            // Display an input dialog to create a new item
            //string itemName = await DisplayPromptAsync("Create Item", "Enter the item name:", "Create", "Cancel", null, -1, Keyboard.Default, "");

            // Update the ListView
            ArmyList.ItemsSource = null; // Clear the items source
            ArmyList.ItemsSource = AosArmies; // Set it again to trigger a refresh}
        }
    }
}