using System;
using System.Collections.Generic;
using System.Linq;
using SyStock.Entidades;
using SyStock.LogicaNegocio.ClasedeDominio;

namespace SyStock.LogicaNegocio
{
    public class ControladorFachada
    {
        private static ControladorFachada instancia;

        public static ControladorFachada Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladorFachada();
                return instancia;
            }
        }

        public int IDUsuarioLogeado { get; set; }

        #region CONTROLADOR USUARIO

        /// <summary>
        /// Método para agrega un Usuario
        /// </summary>
        /// <param name="pNombre">Nombre de Usario</param>
        /// <param name="pContraseña">Contraseña del Usuario</param>
        /// <param name="EsAdmin">True si es admin, False si no lo es</param>
        /// <returns>Usuario agregado. Null si no se puede agregar</returns>
        public Usuario AgregarUsuario(string pNombre, string pContraseña, bool EsAdmin)
        {
            string hash = Utilidades.Encriptar(string.Concat(pNombre, pContraseña));

            Usuario _usuario = new Usuario(pNombre, hash, DateTime.Now);
            if (EsAdmin)
            {
                _usuario.IdUsuarioAdmin = 0;
            }
            else
            {
                _usuario.IdUsuarioAdmin = this.IDUsuarioLogeado;
            }

            if (ControladorUsuario.Agregar(_usuario) == -1)
            {
                return _usuario;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Método para modificar un usuario
        /// </summary>
        /// <param name="pUsuario">Usuario a modificar</param>
        /// <param name="pContraseñaAntigua">Contraseña antigua</param>
        /// <param name="pContraseñaNueva">Nueva contraseña</param>
        /// <returns></returns>
        public bool ModificarUsuario(Usuario pUsuario, string pContraseñaAntigua, string pContraseñaNueva)
        {
            Usuario _usuario = new Usuario("", "", DateTime.Now);
            if (pUsuario.IdUsuario == 0)
            {
                _usuario = ControladorUsuario.Obtener(this.IDUsuarioLogeado);
            }
            else
            {
                _usuario = ControladorUsuario.Obtener(pUsuario.Nombre);
                Console.Write(pUsuario.Nombre);
            }
            
            string hash = Utilidades.Encriptar(string.Concat(_usuario.Nombre, pContraseñaAntigua));
            if (_usuario.Contraseña != hash)
            {
                return false;
            }
            else
            {
                string hash_nuevo = Utilidades.Encriptar(string.Concat(_usuario.Nombre, pContraseñaNueva));
                _usuario.Contraseña = hash_nuevo;
                ControladorUsuario.Modificar(_usuario);
                return true;
            }
        }

        /// <summary>
        /// Método para eliminar un usuario
        /// </summary>
        /// <param name="pNombreUsuario">Nombre del usuario a eliminar</param>
        /// <returns>Devuelve True si fue eliminado. False si no se pudo eliminar</returns>
        public bool EliminarUsuario(string pNombreUsuario)
        {
            Usuario _usuario = new Usuario("", "", DateTime.Now);
            _usuario = ControladorUsuario.Obtener(pNombreUsuario);
            if (_usuario.FechaAlta == _usuario.FechaBaja)
            {
                _usuario.FechaBaja = DateTime.Now;
                ControladorUsuario.Modificar(_usuario);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// Método para verificar si un usuario existe
        /// </summary>
        /// <param name="pNombre">Nombre del Usuario</param>
        /// <param name="pContraseña">Contraseña del Usuario</param>
        /// <returns>Devuelve el usuario. Null si no lo encontró</returns>
        public int VerificarUsuario(string pNombre, string pContraseña)
        {
            if (string.IsNullOrEmpty(pNombre))
            {
                pNombre = ControladorUsuario.Obtener(this.IDUsuarioLogeado).Nombre;
            }
            string hash = Utilidades.Encriptar(string.Concat(pNombre, pContraseña));
            Usuario _usuario = ControladorUsuario.Verificar(pNombre, hash); //Trae un objeto nulo si no lo encontró

            //Verifica si el usuario esta en la bd
            switch (_usuario)
            {
                case null:
                    return 1; //Devuelve 1 si no lo encuentra
                default:
                    if (_usuario.FechaBaja != DateTime.MinValue)
                    {
                        return 2; //Esta dado de baja
                    }
                    else
                    {
                        this.IDUsuarioLogeado = _usuario.IdUsuario;
                        return 3; //Puede loguearse
                    }
            }
        }

        /// <summary>
        /// Verifica si el usuario registrado es Administrador
        /// </summary>
        /// <returns>Devuelve True si es Administrado. False si no lo es</returns>
        public bool EsAdmin()
        {
            Usuario _usuario = ControladorUsuario.Obtener(this.IDUsuarioLogeado);
            if (_usuario.IdUsuarioAdmin == 0)
            {
                return true;
    }
            else
            {
                return false;
}
        }

        /// <summary>
        /// Mètodo para listar los Usuarios
        /// </summary>
        /// <returns>Devuelve una lista de Usuarios</returns>
        public List<Usuario> ListarUsuarios()
        {
            return ControladorUsuario.Listar();
        }
        #endregion

        #region CONTROLADOR CATEGORIA
        public int AgregarCategoria(string pNombre)
        {
            Categoria _categoria = new Categoria(pNombre,true,this.IDUsuarioLogeado);
            return ControladorCategoria.Agregar(_categoria);
        }

        public bool ModificarCategoria(string nombreAntigua, string nombreNuevo)
        {
            Categoria _categoria = new Categoria("",true,this.IDUsuarioLogeado);
            _categoria = ControladorCategoria.Obtener(nombreAntigua);
            _categoria.Nombre = nombreNuevo;
            return ControladorCategoria.Modificar(_categoria);
        }

        public bool EliminarCategoria(Categoria pCategoria)
        {
            return ControladorCategoria.Eliminar(pCategoria);
        }

        public List<Categoria> ListarCategorias()
        {
            return ControladorCategoria.Listar();
        }
        #endregion

        #region CONTROLADOR INSUMOS

        public int AgregarInsumo(string pNombre, string pDescripcion, string pCantidad, string pStock, string pCategoria)
        {
            int idCategoria = ControladorCategoria.Obtener(pCategoria).IdCategoria;
            Insumo _insumo = new Insumo(pNombre, pDescripcion,Convert.ToInt32(pCantidad), Convert.ToInt32(pStock), true, idCategoria);
            return ControladorInsumo.Agregar(_insumo);
        }

        public Insumo ObtenerInsumo(string pNombre)
        {
            return ControladorInsumo.Obtener(pNombre);
        }

        public bool ModificarInsumo(Insumo pInsumo)
        {
            return ControladorInsumo.Modificar(pInsumo);  
        }

        public bool SumarStock(string pNombre, int pCantidad)
        {
            Insumo _insumo = ControladorInsumo.Obtener(pNombre);
            _insumo.Cantidad += pCantidad;
            return ControladorInsumo.Modificar(_insumo);
        }

        public bool RestarStock(Insumo pIns)
        {
            Insumo _insumo = new Insumo("", "", 0, 0, true, 0);
            _insumo = ControladorInsumo.Obtener(pIns.IdInsumo);
            int cantidadActual = _insumo.Cantidad - pIns.Cantidad;
            _insumo.Cantidad = cantidadActual;
            return ControladorInsumo.Modificar(_insumo);
        }

        public List<Insumo> ListarInsumos()
        {
            return ControladorInsumo.Listar();
        }

        public List<Insumo> ListarInsumos(string pCategoria)
        {
            Categoria _categoria = new Categoria("", true, 0);
            _categoria = ControladorCategoria.Obtener(pCategoria);
            return ControladorInsumo.Listar(_categoria.IdCategoria);
        }
        #endregion

        #region CONTROLADOR AREA

        /// <summary>
        /// Método para agregar un área
        /// </summary>
        /// <param name="pNombreArea">Nómbre del área a agregar</param>
        /// <returns>Devuelve -1 si logra agregarla, o sino el ID del Área</returns>
        public int AgregarArea(string pNombreArea)
        {
            Area _area = new Area(pNombreArea);
            return ControladorArea.Agregar(_area);
        }

        /// <summary>
        /// Método para modificar un área
        /// </summary>
        /// <param name="nombreAntigua">Nombre de la área a modificar</param>
        /// <param name="nombreNuevo">Nuevo nombre del área</param>
        /// <returns>Devuelve true si o modificò. False en caso contrario</returns>
        public bool ModificarArea(string nombreAntigua, string nombreNuevo)
        {
            Area _area = new Area("");
            _area = ControladorArea.Obtener(nombreAntigua);
            _area.Nombre = nombreNuevo;
            return ControladorArea.Modificar(_area);
        }

        /// <summary>
        /// Método para listar las áreas
        /// </summary>
        /// <returns>Devuelve una lista de áreas</returns>
        public List<Area> ListarArea()
        {
            return ControladorArea.Listar();
        }
        #endregion

        #region CONTROLADOR GRUPO

        /// <summary>
        /// Método para agregar un´grupo
        /// </summary>
        /// <param name="pNombreGrupo">Nombre del grupo</param>
        /// <param name="pNombreArea">Nombre del área al q se le asignará el grupo</param>
        /// <returns>Devuelve -1 si agregó el Grupo. sino el valor del Id del grupo ya existente</returns>
        public int AgregarGrupo(string pNombreGrupo, string pNombreArea)
        {
            Area _area = ControladorArea.Obtener(pNombreArea);
            Grupo _grupo = new Grupo(pNombreGrupo,true,_area.IdArea,this.IDUsuarioLogeado);
            return ControladorGrupo.Agregar(_grupo);
        }

        /// <summary>
        /// Método para modificar un grupo
        /// </summary>
        /// <param name="nombreAntigua">Nombre del grupo</param>
        /// <param name="nombreNuevo">Nuevo nombre del grupo</param>
        /// <returns>Devuelve true si logró modificarlo</returns>
        public bool ModificarGrupo(string nombreAntigua, string nombreNuevo)
        {
            Grupo _grupo = new Grupo("",true,0,0);
            _grupo = ControladorGrupo.Obtener(nombreAntigua);
            _grupo.Nombre = nombreNuevo;
             return ControladorGrupo.Modificar(_grupo);
        }

        /// <summary>
        /// Método para listar los grupos
        /// </summary>
        /// <returns>Lista de grupos</returns>
        public List<Grupo> ListarGrupos()
        {
            return ControladorGrupo.Listar();
        }

        /// <summary>
        /// Método para listar los grupos
        /// </summary>
        /// <param name="pArea">Id del Área de os grupos a listar</param>
        /// <returns>Lista de grupos para una determinada Área</returns>
        public List<Grupo> ListarGrupos(string pArea)
        {
            Area _area = new Area("");
            _area = ControladorArea.Obtener(pArea);
            return ControladorGrupo.Listar(_area.IdArea);
        }
        #endregion

        #region CONTROLADOR PERSONA
        public int AgregarPersona(string pNombre, string pContraseña, string pNombreGrupo)
        {
            int _idPersona = ControladorPersona.VerificarNombre(pNombre);
            if (_idPersona == -1)
            {
                string hash = Utilidades.Encriptar(string.Concat(pNombre, pContraseña));

                int _idGrupo = ControladorGrupo.Obtener(pNombreGrupo).IdGrupo;
                PersonaAutorizada _persona = new PersonaAutorizada(pNombre, hash, DateTime.Today, DateTime.Today, _idGrupo);

                if (ControladorPersona.Agregar(_persona) == -2)
                {
                    _idPersona = -2;
                }
            }
            return _idPersona;
        }

        public int VerificarPersona(string pNombre, string pContraseña)
        {
            string hash = Utilidades.Encriptar(string.Concat(pNombre, pContraseña));
            int _idPersona = ControladorPersona.Verificar(pNombre, hash);
            return _idPersona;
        }

        public int VerificarNombre(string pNombre)
        {
            return ControladorPersona.VerificarNombre(pNombre);
        }

        public bool ModificarPersona(string pNombre, string pContraseña)
        {
            PersonaAutorizada _personaAutorizada = new PersonaAutorizada("", "", DateTime.Now, DateTime.Now, 0);
            _personaAutorizada = ControladorPersona.Obtener(pNombre);
            string hash = Utilidades.Encriptar(string.Concat(pNombre, pContraseña));
            _personaAutorizada.Contraseña = hash;
            return ControladorPersona.Modificar(_personaAutorizada);
        }

        public bool ModificarPersona(string pNombreAntiguo, string pNombreNuevo, string pContraseña)
        {
            PersonaAutorizada _personaAutorizada = new PersonaAutorizada("", "", DateTime.Now, DateTime.Now, 0);
            _personaAutorizada = ControladorPersona.Obtener(pNombreAntiguo);
            string hash = Utilidades.Encriptar(string.Concat(pNombreNuevo, pContraseña));
            _personaAutorizada.Nombre = pNombreNuevo;
            _personaAutorizada.Contraseña = hash;
            return ControladorPersona.Modificar(_personaAutorizada);
        }

        public List<PersonaAutorizada> ListarPersonas()
        {
            return ControladorPersona.Listar();
        }

        public List<PersonaAutorizada> ListarPersonas(string pGrupo)
        {
            int idGrupo = ControladorGrupo.Obtener(pGrupo).IdGrupo;
            return ControladorPersona.Listar(idGrupo);
        }

        public List<MostrarPersonas> MostrarPersonas()
        {
            List<PersonaAutorizada> _lista = new List<PersonaAutorizada>();
            List<MostrarPersonas> _listaMostrar = new List<MostrarPersonas>();

            _lista = ControladorPersona.Listar();

            for (int i = 0; i < _lista.Count(); i++)
            {
                if (_lista[i].FechaAlta == _lista[i].FechaBaja)
                {
                    Grupo grupo = ControladorGrupo.Obtener(_lista[i].IdGrupo);
                    string area = ControladorArea.Obtener(grupo.IdArea).Nombre;
                    MostrarPersonas _per = new MostrarPersonas(_lista[i].IdPersona, _lista[i].Nombre, grupo.Nombre, area);
                    _listaMostrar.Add(_per);
                }
            }

            return _listaMostrar;
        }

        public List<MostrarPersonas> MostrarPersonas(string pArea, string pGrupo)
        {
            List<PersonaAutorizada> _lista = new List<PersonaAutorizada>();
            List<MostrarPersonas> _listaMostrar = new List<MostrarPersonas>();

            _lista = ControladorPersona.Listar();

            for (int i = 0; i < _lista.Count(); i++)
            {
                if (_lista[i].FechaAlta == _lista[i].FechaBaja)
                {
                    Grupo grupo = ControladorGrupo.Obtener(_lista[i].IdGrupo);
                    string area = ControladorArea.Obtener(grupo.IdArea).Nombre;
                    if ((pArea != string.Empty) && (area == pArea))
                    {
                        MostrarPersonas _per = new MostrarPersonas(_lista[i].IdPersona, _lista[i].Nombre, grupo.Nombre, area);
                        _listaMostrar.Add(_per);
                    }
                    if ((pGrupo != string.Empty) && (grupo.Nombre == pGrupo))
                    {
                        MostrarPersonas _per = new MostrarPersonas(_lista[i].IdPersona, _lista[i].Nombre, grupo.Nombre, area);
                        _listaMostrar.Add(_per);
                    }
                }
            }

            return _listaMostrar;
        }

        public bool EliminarPersona(string pNombre)
        {
            PersonaAutorizada _persona = new PersonaAutorizada("", "", DateTime.Now, DateTime.Now,0);
            _persona = ControladorPersona.Obtener(pNombre);
            if (_persona.FechaAlta == _persona.FechaBaja)
            {
                _persona.FechaBaja = DateTime.Now;
                ControladorPersona.Modificar(_persona);
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region CONTROLADOR ENTREGA
        public int AgregarEntrega(string nombrePersona)
        {
            int _idPersona = ControladorPersona.Obtener(nombrePersona).IdPersona;
            EntregaInsumos _entrega = new EntregaInsumos(this.IDUsuarioLogeado, _idPersona, DateTime.Today);
            return ControladorEntrega.Agregar(_entrega);
        }
        #endregion

        #region CONTROLADOR RENGLON DE ENTREGA
        public int AgregarRenglon(int pIdEntrega, List<Insumo> _listarInsumos)
        {
            int _idRenglon = 0;
            foreach (var _ins in _listarInsumos)
            {
                if ((_ins != null) && (_idRenglon != -2))
                {
                    if (RestarStock(_ins))
                    {
                        RenglonEntrega _renglon = new RenglonEntrega(pIdEntrega, _ins.IdInsumo, _ins.Cantidad);
                        _idRenglon = ControladorRenglones.Agregar(_renglon);
                    }
                    else
                    {
                        _idRenglon = -2;
                    }
                }
            }
            return _idRenglon;
        }
        #endregion
    }
}
