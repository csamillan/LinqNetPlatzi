// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

LinqQueries queries = new LinqQueries();

//PrintValues(queries.TodaLaColleccion());
//PrintValues(queries.LibrosDespues2000());
//PrintValues(queries.LibroConMasde250PAGinAction());
//Console.WriteLine($"Todos los libros tienen Status? - {(queries.TodoLosLibrosTienenStatus())}");
//Console.WriteLine($"algun de los libros fue publicado en 2005? - {(queries.AlgunLibroPublicadoen2005())}");
//PrintValues(queries.LibrosdePython());
//PrintValues(queries.LibrosJavaOrdenadosxNombreAsc());
//PrintValues(queries.LibrosJavaOrdenadosxPaginasDesc());
//PrintValues(queries.TresLibrosJavaMasRecientes());
//PrintValues(queries.TerceryCuartoLibroconmas400Hojas());
//PrintValues(queries.LosPrimeros3LibrosSoloNombreyPag());
//Console.WriteLine($"Numero de paginas entre 200 y 500 Pag - {(queries.NumeroLibrosEntre200y500IntCorrecto())}");
//Console.WriteLine($"Fecha de publicacion menor - {(queries.MenorFechadePublicacion())}");
//Console.WriteLine($"Mayor cantidad de paginas - {(queries.MayorCantidadDePaginas())}");
//var LibroMenorPag = queries.MenosCantidadDePaginasConPagMayorA0();
//Console.WriteLine($"Libro con numero de paginas - {(LibroMenorPag.Title)} - {(LibroMenorPag.PageCount)}");
//var LibroMasReciente= queries.LibroConFechaMasReciente();
//Console.WriteLine($"Libro con numero de paginas - {(LibroMasReciente.Title)} - {(LibroMasReciente.PublishedDate)}");
//Console.WriteLine($"Suma de cantidad de paginas - {(queries.SumaLibrosDePag0A500())}");
//Console.WriteLine($"Titulos de libros despues del 2015 - {(queries.LibrosDespuesDel2015Concatenados())}");
//Console.WriteLine($"Promedio de caracteres del titulo de los libros - {(queries.PromedioCaracteresTitulo())}");
//PrintGroup(queries.LibrosDespuesDel2000AgrupadosPorAno());
//printDictionary(queries.DiccionarioDeLibrosPorLetra(),'A');
PrintValues(queries.LibrosDespuesDel2005YMasDe500Pag());

void PrintValues(IEnumerable<Book> ListBooks){

    Console.WriteLine("{0 , -70} {1, 7} {2 , 11} \n","Titulo", "N. Paginas", "Fecha Publicacion");

    foreach(var item in ListBooks){
    
        Console.WriteLine("{0 , -70} {1, 7} {2 , 11}",item.Title, item.PageCount,item.PublishedDate.ToShortDateString());
    }
}

void PrintGroup(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}

void printDictionary(ILookup<char, Book> listBooks, char letter)
{
    char letterUpper = Char.ToUpper(letter);
    if (listBooks[letterUpper].Count() == 0)
    {
        Console.WriteLine($"No hay libros que inicien con la letra '{letterUpper}'");
    } 
    else 
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Título", "Nro. Páginas", "Fecha de Publicación");
        foreach (var book in listBooks[letterUpper])
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }
}