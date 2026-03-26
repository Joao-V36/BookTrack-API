namespace BookTrack.Domain.Entities
{
   public class Book
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }   
        public string Autor {  get; private set; }
        public int TotalPages { get; private set; }

        public Book (string titulo, string autor, int totalPages)
        {
            if (string.IsNullOrWhiteSpace(titulo)) { throw new Exception("Titulo é Obrigatório"); }
            Titulo = titulo;
            Autor = autor;
            TotalPages = totalPages;
        }

        public void Update(string titulo, string autor, int totalPages) 
        {
            if(string.IsNullOrWhiteSpace(titulo))
            {
                throw new Exception("Titulo é Obrigatório");
            }
            if (totalPages <= 0)
            {
                throw new Exception("Total de paginas não pode ser menor que zero");
            }

            Titulo = titulo;
            Autor = autor;
            TotalPages = totalPages;
        }
    }
}
