namespace ORM.Models
{
    public class Categoria
    {
            public int Id { get; set; }
            public string Nome { get; set; }
            public ICollection<Item> Itens { get; set; }

    }
}
