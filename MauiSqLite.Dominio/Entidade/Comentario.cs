using SQLite;

public class Comentario
{
    public Comentario()
    {
        this.Data = DateTime.Now;
    }

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Texto { get; set; }
    public DateTime Data { get; set; }
    public int Id_Tarefa { get; set; }
    public int? Id_Usuario { get; set; }

}