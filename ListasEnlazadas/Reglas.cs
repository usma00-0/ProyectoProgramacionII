using System.Security.Cryptography.X509Certificates;

public class Reglas
{
    private NodoEstudiante cabeza;

//Agrega un nuevo estudiante
    public void AgregarEstudiante(string nombre, int codigo)
    {
        NodoEstudiante nuevo = new NodoEstudiante(nombre, codigo);
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
        return false;
    }

//Gestion de materias 
    public string AgregarMateriaEstudiante(int codigoEst, string nomMat, double nota)
    {
        NodoEstudiante est = BuscarEstudiante(codigoEst);
        if (est == null) return "Estudiante no encontrado";

        //Mirar si la materia ya existe
        NodoMateria mTemp = est.CabezaMaterias;
        while (mTemp != null)
        {
            if (mTemp.Nombre.ToLower() == nomMat.ToLower) return "Materia ya registrada";
            mTemp = mTemp.Siguiente;
        }
        //Poner materia
        NodoMateria nuevaMat = new NodoMateria(nomMat, nota);
        nuevaMat.Siguiente = est.CabezaMaterias;
        est.CabezaMaterias = nuevaMat;
        return "Materia registrada con exito";
    }

//Editar nota 
    public bool EditarNota(int codigoEst, string nomMat, double nuevaNota)
        {
            NodoEstudiante est = BuscarEstudiante(codigoEst);
            if (est == null) return false;
            NodoMateria mTemp = est.CabezaMaterias;
            while (mTemp != null)            {
                if (mTemp.Nombre.ToLower() == nomMat.ToLower)
                {
                    mTemp.Nota = nuevaNota;
                    return true;
                }
                mTemp = mTemp.Siguiente;
            }
            return false;
        }
    }