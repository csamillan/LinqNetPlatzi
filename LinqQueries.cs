public class LinqQueries{

    private List<Book> BoookCollection = new List<Book>();

    public LinqQueries(){
        using(StreamReader reader = new StreamReader("books.json")){
            string json = reader.ReadToEnd();
            this.BoookCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        }
    }

    public IEnumerable<Book> TodaLaColleccion(){
        return BoookCollection;
    }

    public IEnumerable<Book> LibrosDespues2000(){
    
        //extension method
        //return BoookCollection.Where(p => p.PublishedDate.Year > 2000);

        //query expresion

        return from l in BoookCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> LibroConMasde250PAGinAction(){
        //extension method
        //return BoookCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

        //query expresion
        return from l in BoookCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    public bool TodoLosLibrosTienenStatus(){
        return BoookCollection.All(P => P.Status !=  string.Empty);
    }

    public bool AlgunLibroPublicadoen2005(){
        return BoookCollection.Any(p => p.PublishedDate.Year == 1950);
    }

    public IEnumerable<Book> LibrosdePython(){
        return BoookCollection.Where(p => p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> LibrosJavaOrdenadosxNombreAsc(){
        return BoookCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> LibrosJavaOrdenadosxPaginasDesc(){
        return BoookCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> TresLibrosJavaMasRecientes(){
    
        return BoookCollection.Where(p => p.Categories.Contains("Java"))
                                                    .OrderByDescending(p => p.PublishedDate)
                                                    .Take(3);
    }

    public IEnumerable<Book> TerceryCuartoLibroconmas400Hojas(){
        return BoookCollection.Where(p => p.PageCount >400).Take(4).Skip(2);
    }

    public IEnumerable<Book> LosPrimeros3LibrosSoloNombreyPag(){
        return BoookCollection.Take(3)
                            .Select(p => new Book() {Title = p.Title, PageCount = p.PageCount});

    }
}