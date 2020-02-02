﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyStock.Entidades;
using SyStock.LogicaNegocio.ClasedeDominio;

namespace SyStock.LogicaNegocio
{
    public class Fachada
    {
        private static Fachada instancia;

        private int _idUsuarioLogeado;

        public ControladorUsuario _controladorUsuario = new ControladorUsuario();
        public ControladorCategoria _controladorCategoria = new ControladorCategoria();
        public ControladorInsumo _controladorInsumo = new ControladorInsumo();
        public ControladorArea _controladorArea = new ControladorArea();
        public ControladorGrupo _controladorGrupo = new ControladorGrupo();
        public ControladorPersona _controladorPersona = new ControladorPersona();
        public ControladorEntrega _controladorEntrega = new ControladorEntrega();
        public ControladorRenglones _controladorRenglones = new ControladorRenglones();

        public static Fachada Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new Fachada();
                return instancia;
            }
        }

        public int IDUsuarioLogeado
        {
            get { return _idUsuarioLogeado; }
            set { _idUsuarioLogeado = value; }
        }

        #region CONTROLADOR USUARIO
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

            if (_controladorUsuario.Agregar(_usuario) == -1)
            {
                return _usuario;
            }
            else
            {
                return null;
            }
        }

        public bool ModificarUsuario(Usuario pUsuario, string pContraseñaAntigua, string pContraseñaNueva)
        {
            Usuario _usuario = new Usuario("", "", DateTime.Now);
            if(pUsuario.IdUsuario == 0)
            {
                _usuario = _controladorUsuario.Obtener(this.IDUsuarioLogeado);
            }
            else
            {
                _usuario = _controladorUsuario.Obtener(pUsuario.Nombre);
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
                _controladorUsuario.Modificar(_usuario);
                return true;
            }
        }

        public bool EliminarUsuario(string pNombreUsuario)
        {
            Usuario _usuario = new Usuario("", "", DateTime.Now);
            _usuario = _controladorUsuario.Obtener(pNombreUsuario);
            if (_usuario.FechaAlta == _usuario.FechaBaja)
            {
                _usuario.FechaBaja = DateTime.Now;
                _controladorUsuario.Modificar(_usuario);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public int VerificarUsuario(string pNombre, string pContraseña)
        {
            if (string.IsNullOrEmpty(pNombre))
            {
                pNombre =_controladorUsuario.Obtener(this._idUsuarioLogeado).Nombre;
            }
            string hash = Utilidades.Encriptar(string.Concat(pNombre, pContraseña));
            Usuario _usuario = _controladorUsuario.Verificar(pNombre, hash); //Trae un objeto nulo si no lo encontró

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

        public bool EsAdmin()
        {
            Usuario _usuario = _controladorUsuario.Obtener(this.IDUsuarioLogeado);
            if (_usuario.IdUsuarioAdmin == 0)
            {
                return true;
    }
            else
            {
                return false;
}
        }

        public List<Usuario> ListarUsuarios()
        {
            return _controladorUsuario.Listar();
        }
        #endregion

        #region CONTROLADOR CATEGORIA
        public int AgregarCategoria(string pNombre)
        {
            Categoria _categoria = new Categoria(pNombre,true,this.IDUsuarioLogeado);
            return _controladorCategoria.Agregar(_categoria);
        }

        public List<Categoria> ListarCategorias()
        {
            return _controladorCategoria.Listar();
        }
        #endregion

        #region CONTROLADOR INSUMOS

        public int AgregarInsumo(string pNombre, string pDescripcion, string pCantidad, string pStock, string pCategoria)
        {
            int idCategoria = _controladorCategoria.Obtener(pCategoria).IdCategoria;
            Insumo _insumo = new Insumo(pNombre, pDescripcion,Convert.ToInt32(pCantidad), Convert.ToInt32(pStock), true, idCategoria);
            return _controladorInsumo.Agregar(_insumo);
        }

        public Insumo ObtenerInsumo(string pNombre)
        {
            return _controladorInsumo.Obtener(pNombre);
        }

        public bool ModificarInsumo(Insumo pInsumo)
        {
            return _controladorInsumo.Modificar(pInsumo);  
        }

        public bool SumarStock(string pNombre, int pCantidad)
        {
            Insumo _insumo = _controladorInsumo.Obtener(pNombre);
            _insumo.Cantidad += pCantidad;
            return _controladorInsumo.Modificar(_insumo);
        }

        public bool RestarStock(Insumo pIns)
        {
            Insumo _insumo = new Insumo("", "", 0, 0, true, 0);
            _insumo = _controladorInsumo.Obtener(pIns.IdInsumo);
            int cantidadActual = _insumo.Cantidad - pIns.Cantidad;
            _insumo.Cantidad = cantidadActual;
            return _controladorInsumo.Modificar(_insumo);
        }

        public List<Insumo> ListarInsumos()
        {
            return _controladorInsumo.Listar();
        }

        public List<Insumo> ListarInsumos(string pCategoria)
        {
            Categoria _categoria = new Categoria("", true, 0);
            _categoria = _controladorCategoria.Obtener(pCategoria);
            return _controladorInsumo.Listar(_categoria.IdCategoria);
        }
        #endregion

        #region CONTROLADOR AREA
        public int AgregarArea(string pNombreArea)
        {
            Area _area = new Area(pNombreArea);
            return _controladorArea.Agregar(_area);
        }

        public bool ModificarArea(string nombreAntigua, string nombreNuevo)
        {
            Area _area = new Area("");
            _area = _controladorArea.Obtener(nombreAntigua);
            _area.Nombre = nombreNuevo;
            return _controladorArea.Modificar(_area);
        }

        public List<Area> ListarArea()
        {
            return _controladorArea.Listar();
        }
        #endregion

        #region CONTROLADOR GRUPO
        public int AgregarGrupo(string pNombreGrupo, string pNombreArea)
        {
            Area _area = _controladorArea.Obtener(pNombreArea);
            Grupo _grupo = new Grupo(pNombreGrupo,true,_area.IdArea,this.IDUsuarioLogeado);
            return _controladorGrupo.Agregar(_grupo);
        }

        public bool ModificarGrupo(string nombreAntigua, string nombreNuevo)
        {
            Grupo _grupo = new Grupo("",true,0,0);
            _grupo = _controladorGrupo.Obtener(nombreAntigua);
            _grupo.Nombre = nombreNuevo;
             return _controladorGrupo.Modificar(_grupo);
        }

        public List<Grupo> ListarGrupos()
        {
            return _controladorGrupo.Listar();
        }

        public List<Grupo> ListarGrupos(string pArea)
        {
            Area _area = new Area("");
            _area = _controladorArea.Obtener(pArea);
            return _controladorGrupo.Listar(_area.IdArea);
        }
        #endregion

        #region CONTROLADOR PERSONA
        public int AgregarPersona(string pNombre, string pContraseña, string pNombreGrupo)
        {
            int _idPersona = _controladorPersona.VerificarNombre(pNombre);
            if (_idPersona == -1)
            {
                string hash = Utilidades.Encriptar(string.Concat(pNombre, pContraseña));

                int _idGrupo = _controladorGrupo.Obtener(pNombreGrupo).IdGrupo;
                PersonaAutorizada _persona = new PersonaAutorizada(pNombre, hash, DateTime.Today, DateTime.Today, _idGrupo);

                if (_controladorPersona.Agregar(_persona) == -2)
                {
                    _idPersona = -2;
                }
            }
            return _idPersona;
        }

        public int VerificarPersona(string pNombre, string pContraseña)
        {
            string hash = Utilidades.Encriptar(string.Concat(pNombre, pContraseña));
            int _idPersona = _controladorPersona.Verificar(pNombre, hash);
            return _idPersona;
        }

        public int VerificarNombre(string pNombre)
        {
            return _controladorPersona.VerificarNombre(pNombre);
        }

        public bool ModificarPersona(string pNombre, string pContraseña)
        {
            PersonaAutorizada _personaAutorizada = new PersonaAutorizada("", "", DateTime.Now, DateTime.Now, 0);
            _personaAutorizada = _controladorPersona.Obtener(pNombre);
            string hash = Utilidades.Encriptar(string.Concat(pNombre, pContraseña));
            _personaAutorizada.Contraseña = hash;
            return _controladorPersona.Modificar(_personaAutorizada);
        }

        public bool ModificarPersona(string pNombreAntiguo, string pNombreNuevo, string pContraseña)
        {
            PersonaAutorizada _personaAutorizada = new PersonaAutorizada("", "", DateTime.Now, DateTime.Now, 0);
            _personaAutorizada = _controladorPersona.Obtener(pNombreAntiguo);
            string hash = Utilidades.Encriptar(string.Concat(pNombreNuevo, pContraseña));
            _personaAutorizada.Nombre = pNombreNuevo;
            _personaAutorizada.Contraseña = hash;
            return _controladorPersona.Modificar(_personaAutorizada);
        }

        public List<PersonaAutorizada> ListarPersonas()
        {
            return _controladorPersona.Listar();
        }

        public List<PersonaAutorizada> ListarPersonas(string pGrupo)
        {
            int idGrupo = _controladorGrupo.Obtener(pGrupo).IdGrupo;
            return _controladorPersona.Listar(idGrupo);
        }

        public List<MostrarPersonas> MostrarPersonas()
        {
            List<PersonaAutorizada> _lista = new List<PersonaAutorizada>();
            List<MostrarPersonas> _listaMostrar = new List<MostrarPersonas>();

            _lista = _controladorPersona.Listar();

            for (int i = 0; i < _lista.Count(); i++)
            {
                if (_lista[i].FechaAlta == _lista[i].FechaBaja)
                {
                    Grupo grupo = _controladorGrupo.Obtener(_lista[i].IdGrupo);
                    string area = _controladorArea.Obtener(grupo.IdArea).Nombre;
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

            _lista = _controladorPersona.Listar();

            for (int i = 0; i < _lista.Count(); i++)
            {
                if (_lista[i].FechaAlta == _lista[i].FechaBaja)
                {
                    Grupo grupo = _controladorGrupo.Obtener(_lista[i].IdGrupo);
                    string area = _controladorArea.Obtener(grupo.IdArea).Nombre;
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
            _persona = _controladorPersona.Obtener(pNombre);
            if (_persona.FechaAlta == _persona.FechaBaja)
            {
                _persona.FechaBaja = DateTime.Now;
                _controladorPersona.Modificar(_persona);
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
            int _idPersona = _controladorPersona.Obtener(nombrePersona).IdPersona;
            EntregaInsumos _entrega = new EntregaInsumos(this.IDUsuarioLogeado, _idPersona, DateTime.Today);
            return _controladorEntrega.Agregar(_entrega);
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
                        _idRenglon = _controladorRenglones.Agregar(_renglon);
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