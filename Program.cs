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
PrintValues(queries.LosPrimeros3LibrosSoloNombreyPag());

void PrintValues(IEnumerable<Book> ListBooks){

    Console.WriteLine("{0 , -70} {1, 7} {2 , 11} \n","Titulo", "N. Paginas", "Fecha Publicacion");

    foreach(var item in ListBooks){
    
        Console.WriteLine("{0 , -70} {1, 7} {2 , 11}",item.Title, item.PageCount,item.PublishedDate.ToShortDateString());
    }
}
