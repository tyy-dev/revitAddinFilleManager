namespace RevitAddinFilleManager.Entities.Enums
{
    [Flags]
    public enum AddInType
    {
        None = 0,
        Command = 1 << 0,
        Application = 1 << 1,
        DBApplication = 1 << 2,
        ExternalApplication = Application | DBApplication,
        All = Command | Application | DBApplication
    }

}
