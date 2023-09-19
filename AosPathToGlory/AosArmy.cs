namespace AosPathToGlory
{
    public class AosArmy
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Faction {  get; set; }
        public string SubFaction { get; set; }
        public string Origin { get; set; }
        public int StartingSize { get; set; }
    }
}
