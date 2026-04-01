public class NodoMateria
{
    public string Nombre {get; set;}
    public double Nota {get; set;}
    public NodoMateria Siguiente {get; set;}

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
    public string Nombre {get; set;}
    public int Codigo {get; set;}
    public NodoEstudiante Siguiente {get; set;}

//Cabeza de la lista de materias del estudiante
    public NodoMateria CabezaMaterias {get; set;}
    public NodoEstudiante(string nombre, int codigo)
    {
        Nombre = nombre;
        Codigo = codigo;
        Siguiente = null;
        CabezaMaterias = null;
    }


}