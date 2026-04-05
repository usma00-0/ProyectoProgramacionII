public class NodoMateria
{
    public string Nombre { get; set; }
    public double Nota { get; set; }
    public NodoMateria Siguiente { get; set; }

    public NodoMateria(string nombre, double nota)
    {
        Nombre = nombre;
        Nota = nota;
        Siguiente = null;
    }
}

//Nodo para la lista de estudiantes
public class NodoEstudiante
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }

    public NodoEstudiante Siguiente { get; set; }

    //Cabeza de la lista de materias del estudiante
    public NodoMateria CabezaMaterias { get; set; }
    public NodoEstudiante(int codigo, string nombre, string apellido, string direccion, string celular, string email)
    {
        Nombre = nombre;
        Apellido = apellido;
        Direccion = direccion;
        Celular = celular;
        Email = email;
        Codigo = codigo;
        Siguiente = null;
        CabezaMaterias = null;
    }


}