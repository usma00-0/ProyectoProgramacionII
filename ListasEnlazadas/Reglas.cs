public class Reglas
{
    private NodoEstudiante cabeza;
    private int contadorCodigo = 1; //Para el codigo automatico de estudiantes

    //Agrega un nuevo estudiante
    public void AgregarEstudiante(string nombre, string apellido, string direccion, string celular, string email)
    {
        NodoEstudiante nuevo = new NodoEstudiante(contadorCodigo++, nombre, apellido, direccion, celular, email);
        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            NodoEstudiante temp = cabeza;
            while (temp.Siguiente != null) temp = temp.Siguiente;
            temp.Siguiente = nuevo;
        }
        Console.WriteLine("Estudiante agregado con exito, con código: " + nuevo.Codigo);
    }

    public void ListarEstudiantes()
    {
        if (cabeza == null) { Console.WriteLine("No hay estudiantes registrados"); return; }
        NodoEstudiante temp = cabeza;
        while (temp != null)
        {
            Console.WriteLine(temp.Codigo + " - " + temp.Nombre + " " + temp.Apellido + " - Email: " + temp.Email);
            temp = temp.Siguiente;
        }
    }

    //Busca un estudiante por su código
    public NodoEstudiante BuscarEstudiante(int codigo)
    {
        NodoEstudiante temp = cabeza;
        while (temp != null)
        {
            if (temp.Codigo == codigo) return temp;
            temp = temp.Siguiente;
        }
        return null; //No encontrado
    }

    //Eliminar estudiante
    public bool EliminarEstudiante(int codigo)
    {
        if (cabeza == null) return false;
        if (cabeza.Codigo == codigo)
        {
            cabeza = cabeza.Siguiente;
            return true;
        }
        NodoEstudiante temp = cabeza;
        while (temp.Siguiente != null)
        {
            if (temp.Siguiente.Codigo == codigo)
            {
                temp.Siguiente = temp.Siguiente.Siguiente;
                return true;
            }
            temp = temp.Siguiente;
        }
        return false; //No encontrado
    }

    //Gestion de materias 
    public string AgregarMateriaEstudiante(int codigoEst, string nomMat, double nota)
    {
        NodoEstudiante est = BuscarEstudiante(codigoEst);
        if (est == null)
        {
            Console.WriteLine("Estudiante no encontrado");
            return null;
        }

        //Mirar si la materia ya existe
        NodoMateria mTemp = est.CabezaMaterias;
        while (mTemp != null)
        {
            if (mTemp.Nombre.ToLower() == nomMat.ToLower())
            {
                Console.WriteLine("La materia ya existe para este estudiante");
                return null;
            }
            mTemp = mTemp.Siguiente;
        }
        //Poner materia
        NodoMateria nuevaMat = new NodoMateria(nomMat, nota);
        nuevaMat.Siguiente = est.CabezaMaterias;
        est.CabezaMaterias = nuevaMat;
        return "Materia agregada";
    }

    //Editar nota 
    public bool EditarNota(int codigoEst, string nomMat, double nuevaNota)
    {
        NodoEstudiante est = BuscarEstudiante(codigoEst);
        if (est == null) return false;
        NodoMateria mTemp = est.CabezaMaterias;
        while (mTemp != null)
        {
            if (mTemp.Nombre.ToLower() == nomMat.ToLower())
            {
                mTemp.Nota = nuevaNota;
                return true;
            }
            mTemp = mTemp.Siguiente;
        }
        return false;
    }

    public bool EliminarMateria(int codigoEst, string nomMat)
    {
        NodoEstudiante est = BuscarEstudiante(codigoEst);
        if (est == null || est.CabezaMaterias == null) return false;
        if (est.CabezaMaterias.Nombre.ToLower() == nomMat.ToLower())
        {
            est.CabezaMaterias = est.CabezaMaterias.Siguiente;
            return true;
        }
        NodoMateria mTemp = est.CabezaMaterias;
        while (mTemp.Siguiente != null && mTemp.Siguiente.Nombre.ToLower() != nomMat.ToLower())
        {
            mTemp = mTemp.Siguiente;
        }
        if (mTemp.Siguiente != null)
        {
            mTemp.Siguiente = mTemp.Siguiente.Siguiente;
            return true;
        }
        return false;
    }
}