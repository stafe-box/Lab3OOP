// ReSharper disable All

namespace Lab3OOP.Library;

public static class DbContextTestHelper
{
    public static int AddEntities()
    {
        // Добавляем данные в БД.
        using var context = new FilmCatalogContext();
        context.Database.EnsureCreated();
        
        Director director = new Director { Name = "Robert B. Weide" };
        Genre genre = new Genre { Name = "Comedy" };
        Studio studio = new Studio { Name = "SurGU", Country = "Russia" };
        Film film = new Film { Name = "My labs", DirectorNavigation = director, GenreNavigation = genre, StudioNavigation = studio };

        context.Directors.Add(director);
        context.Genres.Add(genre);
        context.Studios.Add(studio);
        context.Films.Add(film);

        return context.SaveChanges();
    }

    public static int UpdateEntities()
    {
        // Обновляем данные в БД.
        using var context = new FilmCatalogContext();
        context.Database.EnsureCreated();

        Director director = context.Directors.FirstOrDefault(d => d.Name == "Robert B. Weide");
        Genre genre = context.Genres.FirstOrDefault(g => g.Name == "Comedy");
        Studio studio = context.Studios.FirstOrDefault(s => s.Name =="SurGU");
        Film film = context.Films.FirstOrDefault(f => f.Name == "My labs");

        if (director != null)
            director.Name = "Сергей Багиров";
        if (genre != null)
            genre.Name = "История";
        if (studio != null)
            studio.Name = "МГУ";
        if (film != null)
            film.Name = "Оборона Бакайльска";
                
        return context.SaveChanges();
    }

    public static int ReadEntities()
    {
        // Читаем данные из БД.
        using var context = new FilmCatalogContext();
        context.Database.EnsureCreated();
        List<Film> films = context.Films.ToList();

        return films.Count;
    }

    public static int RemoveEntities()
    {
        // Удаляем данные в БД.
        using var context = new FilmCatalogContext();
        context.Database.EnsureCreated();

        Director director = context.Directors.FirstOrDefault(d => d.Name == "Сергей Багиров");
        Genre genre = context.Genres.FirstOrDefault(g => g.Name == "История");
        Studio studio = context.Studios.FirstOrDefault(s => s.Name == "МГУ");
        Film film = context.Films.FirstOrDefault(f => f.Name == "Оборона Бакайльска");

        if (film != null)
            context.Films.Remove(film);
        if (director != null)
            context.Directors.Remove(director);
        if (genre != null)
            context.Genres.Remove(genre);
        if (studio != null)
            context.Studios.Remove(studio);

        return context.SaveChanges();
    }
}
