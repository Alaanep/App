namespace App.Infra.Initializers;

public static class AppInitializer {
    public static void Init(AppDB appDb) {
        new InstructorsInitializer(appDb).Init();
        new LessonsInitializer(appDb).Init();
        new StudentsInitializer(appDb).Init();
        new CountriesInitializer(appDb).Init();
        new CurrenciesInitializer(appDb).Init();
        new CountryCurrenciesInitializer(appDb).Init();
    }
}