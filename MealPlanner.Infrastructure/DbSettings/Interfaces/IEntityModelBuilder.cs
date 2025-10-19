namespace JGL.Infra.Globals.DbSettings.Interfaces
{
    public interface IEntityModelBuilder<TModelBuilder>
    {
        void BuildEntity(TModelBuilder modelBuilder);

        void CreateGlobalParameters(TModelBuilder modelBuilder);
    }
}
