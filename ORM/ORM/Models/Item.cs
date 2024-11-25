namespace ORM.Models
{
    public class Item
    {
            public int Id { get; set; }
            public string Nome { get; set; }
            public int CategoriaId { get; set; }
            public Categoria Categoria { get; set; }

    }
}
