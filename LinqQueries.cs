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

    //este forma de contar es una mala practica
    public int NumeroLibrosEntre200y500Int(){
        return BoookCollection.Where(p=> p.PageCount >= 200 && p.PageCount <= 500).Count();
    }

    public long NumeroLibrosEntre200y500(){
        return BoookCollection.Where(p=> p.PageCount >= 200 && p.PageCount <= 500).LongCount();
    }
    //Forma correcta de contar
    public int NumeroLibrosEntre200y500IntCorrecto(){
        return BoookCollection.Count(p=> p.PageCount >= 200 && p.PageCount <= 500);
    }

    public long NumeroLibrosEntre200y500Correcto(){
        return BoookCollection.LongCount(p=> p.PageCount >= 200 && p.PageCount <= 500);
    }

    public DateTime MenorFechadePublicacion(){
        return BoookCollection.Min(p => p.PublishedDate);
    }

    public int MayorCantidadDePaginas(){
        return BoookCollection.Max(p => p.PageCount);
    }

    public Book MenosCantidadDePaginasConPagMayorA0(){
        return BoookCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
    }

    public Book LibroConFechaMasReciente(){
        return BoookCollection.MaxBy(p => p.PublishedDate);
    }

    public int SumaLibrosDePag0A500(){
        return BoookCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
    }

    public string LibrosDespuesDel2015Concatenados(){
        return BoookCollection.Where(p => p.PublishedDate.Year > 2015)
                            .Aggregate("",(TitulosLibros, next) => {
                                if(TitulosLibros != string.Empty){
                                    TitulosLibros += " - " + next.Title;
                                }else{
                                    TitulosLibros += next.Title;
                                }

                                return TitulosLibros;
                            });
    }

    public double PromedioCaracteresTitulo(){
        return BoookCollection.Average(p => p.Title.Length);
    }

    public IEnumerable<IGrouping<int,Book>> LibrosDespuesDel2000AgrupadosPorAno(){
        return BoookCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p => p.PublishedDate.Year);
    }

    public ILookup<char,Book> DiccionarioDeLibrosPorLetra(){
        return BoookCollection.ToLookup(p => p.Title[0], p => p);
    }

    public IEnumerable<Book> LibrosDespuesDel2005YMasDe500Pag(){
        var LibrosDespuesDel2005 = BoookCollection.Where(p => p.PublishedDate.Year > 2005);
        var LibrosConMasDe500Pag = BoookCollection.Where(p => p.PageCount > 500);

        return LibrosDespuesDel2005.Join(LibrosConMasDe500Pag, p => p.Title, x => x.Title, (p,x) => p);
    }
}